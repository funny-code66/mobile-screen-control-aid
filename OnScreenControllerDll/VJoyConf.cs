namespace vJoyInterfaceWrap {
    using System;
    using System.Collections.Generic;
    using Microsoft.Win32;

    public class VJoyConf {
        private const byte MaxButtons = 128;
        private const byte MinAxes = 8;
        private readonly RegistryKey _regKey;

        public VJoyConf() {
            _regKey = Registry.LocalMachine.CreateSubKey("SYSTEM");
            if(_regKey == null)
                throw new InvalidOperationException();
            _regKey = _regKey.CreateSubKey("CurrentControlSet");
            if(_regKey == null)
                throw new InvalidOperationException();
            _regKey = _regKey.CreateSubKey("services");
            if(_regKey == null)
                throw new InvalidOperationException();
            _regKey = _regKey.CreateSubKey("vjoy");
            if(_regKey == null)
                throw new InvalidOperationException();
            _regKey = _regKey.CreateSubKey("Parameters");
            if(_regKey == null)
                throw new InvalidOperationException();
        }

        public byte[] CreateHidReportDesc(byte reportID, bool[] axes, byte nPovHatsCont, byte nPovHatsDir, byte nButtons) {
            var ret = new List<byte>();

            #region Header + Collection 1

            ret.AddRange(new byte[] {
                                        0x05, 0x01, 0x15, 0x00, 0x09, 0x04, 0xA1, 0x01, 0x05, 0x01, 0x85, reportID, 0x09, 0x01, 0x15, 0x00, 0x26, 0xFF, 0x7F, 0x75, 0x20, 0x95, 0x01, 0xA1, 0x00
                                    });

            #endregion

            #region Axes

            for(var i = 0; i < axes.Length; i++) { // Loop axes
                if(axes[i]) {
                    ret.Add(0x09);
                    ret.Add((byte)(0x30 + i));
                    ret.Add(0x81);
                    ret.Add(0x02);
                }
                else {
                    ret.Add(0x81);
                    ret.Add(0x01);
                }
            }
            if(axes.Length < MinAxes) { // Assume the remaining axes are not implemented
                for(var i = 0; i < MinAxes - axes.Length; i++) {
                    ret.Add(0x81);
                    ret.Add(0x01);
                }
            }
            ret.Add(0xC0); // End collection

            #endregion

            #region POV

            #region Dir POV

            if(nPovHatsDir > 0) {
                ret.AddRange(new byte[] {
                                            0x15, 0x00, 0x25, 0x03, 0x35, 0x00, 0x46, 0x0E, 0x01, 0x65, 0x14, 0x75, 0x04, 0x95, 0x01
                                        });
                // Insert 1-4 5-state POVs
                for(var i = 0; i < nPovHatsDir; i++) {
                    ret.AddRange(new byte[] {
                                                0x09, 0x39, 0x81, 0x02
                                            });
                }
                //Insert 5-state POV place holders
                ret.AddRange(new byte[] {
                                            0x95, (byte)(0x20 - nPovHatsDir), 0x81, 0x01
                                        });
            }
                #endregion
                #region Cont POV

            else if(nPovHatsCont > 0) {
                ret.AddRange(new byte[] {
                                            0x15, 0x00, 0x27, 0x3c, 0x8c, 0x00, 0x00, 0x35, 0x00, 0x47, 0x3c, 0x8c, 0x00, 0x00, 0x65, 0x14, 0x75, 0x20, 0x95, 0x01
                                        });
                // Insert 1-4 continuous POVs
                for(var i = 0; i < nPovHatsCont; i++) {
                    ret.AddRange(new byte[] {
                                                0x09, 0x39, 0x81, 0x02
                                            });
                }
                // Insert 1-3 continuous POV place holders
                ret.AddRange(new byte[] {
                                            0x95, 0x03, 0x81, 0x01
                                        });
            }
                #endregion
                #region No POV Padding

            else {
                ret.AddRange(new byte[] {
                                            0x75, 0x20, 0x95, 0x04, 0x81, 0x01
                                        });
            }

            #endregion

            #endregion

            #region Buttons

            ret.AddRange(new byte[] {
                                        0x05, 0x09, 0x15, 0x00, 0x25, 0x01, 0x55, 0x00, 0x65, 0x00, 0x19, 0x01, 0x29, nButtons, 0x75, 0x01, 0x95, nButtons, 0x81, 0x02
                                    });
            // Padding, if there are less than 32 buttons
            if(nButtons < MaxButtons) {
                ret.AddRange(new byte[] {
                                            0x75, (byte)(MaxButtons - nButtons), 0x95, 0x01, 0x81, 0x01
                                        });
            }
            ret.Add(0xC0); // End collection

            #endregion

            return ret.ToArray();
        }

        public void WriteHidReportDescToReg(int target, byte[] hidReportDesc) { WriteHidReportDescToReg(target, ref hidReportDesc); }

        public void WriteHidReportDescToReg(int target, ref byte[] hidReportDesc) {
            if(_regKey == null)
                throw new InvalidOperationException();
            var key = _regKey.CreateSubKey(string.Format("Device{0:D2}", target));
            if(key == null)
                throw new InvalidOperationException();
            key.SetValue("HidReportDesctiptor", hidReportDesc);
            key.SetValue("HidReportDesctiptorSize", hidReportDesc.Length);
            key.Close();
        }

        public void DeleteHidReportDescFromReg(int target) {
            if(_regKey == null)
                throw new InvalidOperationException();
            int max, i;
            if(target != 0 || target > 16)
                i = max = target;
            else {
                i = 1;
                max = 16;
            }
            for(; i <= max; i++) {
                try {
                    _regKey.DeleteSubKey(string.Format("Device{0:D2}", i));
                }
                catch {}
            }
        }
    }
}