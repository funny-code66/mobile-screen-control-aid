using System;
using System.Collections.Generic;
using System.Windows.Forms;
using vJoyInterfaceWrap;
using System.Management;
//using System.Drawing;
//using System.ComponentModel;
//using SharpDX;
using System.IO;
using SharpDX.DirectInput;
using System.Diagnostics;
using System.Threading;

namespace OnScreenController
{
    public partial class MainController : Form
    {
        public enum JOYSTICK_BUTTON_TYPE
        {
            NONE = 0,
            PRESS,
            RELEASE,
            CLICK,
            TOGGLE
        }

        public enum KEYBOARD_BUTTON_TYPE
        {
            NONE = 0,
            PRESS,
            RELEASE,
            CLICK,
            TOGGLE
        }

        public MappingData[] KeycodeMapping
        {
            get
            {
                return VirtualMappingData.mComboToKeycodeMapping;
            }
        }

        public MappingData[] JoystickButtonMapping
        {
            get
            {
                return VirtualMappingData.mComboToJoystickButtonMapping;
            }
        }

        public MappingData[] JoystickAxisMapping
        {
            get
            {
                return VirtualMappingData.mComboToJoystickAxisMapping;
            }
        }

        public MappingData[] MouseMapping
        {
            get
            {
                return VirtualMappingData.mComboToMouseAxisMapping;
            }
        }

        public MappingData[] InputMapping
        {
            get
            {
                return VirtualMappingData.mComboToInputMapping;
            }
        }

        public MappingData[] OptionMapping
        {
            get
            {
                return VirtualMappingData.mComboToOptionMapping;
            }
        }

        // Create one joystick object and a position structure.
        vJoy mJoystickHandler;
        //bool mVirtualJoystickState = false;
        //vJoy.JoystickState  iReport;
        uint mJoystickId;
        //Dictionary<string, uint> mComboToVirtualKeycodeMapping = VirtualKeycode.mComboToVirtualKeycodeMapping;
        //Dictionary<string, uint> mComboToJoystickButtonMapping = new Dictionary<string, uint>();
        //Dictionary<string, uint> mComboToJoystickAxisMapping = new Dictionary<string, uint>();

        DirectInput mDirectInput;

        //bool mVoiceState = false;
        //bool mJoystickState = false;

        //Controller Form
        CustomControllerForm mCustomControllerForm = new CustomControllerForm();
        VoiceController mVoiceController = new VoiceController();
        public List<ToolStripMenuItem> mCustomControllerMenuList = new List<ToolStripMenuItem>();


        EditBoxForm mEditBoxForm;

        OptionForm mOptionForm;
        
        //Controller Configuration form

        VoiceJoystickCfgForm mVoiceJoystickCfgForm;

        bool Exist_AxisX;
        bool Exist_AxisY;
        bool Exist_AxisZ;
        bool Exist_AxisRX;
        bool Exist_AxisRZ;
        long maxvalX, maxvalY, maxvalZ, maxvalRX, maxvalRY;

        private void PopulateSource()
        {
            ToolStripMenuItem sm = new ToolStripMenuItem("Source");

            ManagementObjectSearcher objSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_SoundDevice");
            ManagementObjectCollection objCollection = objSearcher.Get();

            foreach (ManagementObject obj in objCollection)
            {
                foreach (PropertyData property in obj.Properties)
                {
                    // Console.Out.WriteLine(String.Format("{0}:{1}", property.Name, property.Value));
                    if(property.Name.Equals("Caption"))
                    {
                        ToolStripMenuItem sm1 = new ToolStripMenuItem((string)property.Value, null);
                        sm.DropDownItems.Add(sm1);
                    }
                }
            }


            if (sm.DropDownItems.Count > 0)
                (sm.DropDownItems[0] as ToolStripMenuItem).Checked = true;

            ToolStripMenuItem _sourceMenu = toolStripMenuItem2;
            _sourceMenu.DropDownItems.RemoveAt(0);
            _sourceMenu.DropDownItems.Insert(0, sm);
            
        }

        private void initVJoyStick()
        {
            mJoystickHandler = new vJoy();
            //iReport = new vJoy.JoystickState();
            mJoystickId = 1;

            if (!mJoystickHandler.IsvJoyInstalled())
            {
                Process _installer = new Process();
                _installer.StartInfo.FileName = "vJoyInstall.exe";
                _installer.StartInfo.Arguments = "I";
                _installer.Start();
                _installer.WaitForExit();
            }
            #region configure JoyStick Parameter
            VJoyConf vJoyConf = new VJoyConf();

            try
            {
                byte[] conf;
                bool[] _axes = { true, true, true, true, true, true, true, true };
                int _btnnumber = 100;
                //if (povcon.Checked)
                //    conf = _vJoyConf.CreateHidReportDesc((byte)(i + 1), GetAxes(), (byte)povnum.Value, 0, (byte)btnnum.Value);
                //else if (povdir.Checked)
                //    conf = _vJoyConf.CreateHidReportDesc((byte)(i + 1), GetAxes(), 0, (byte)povnum.Value, (byte)btnnum.Value);
                //else //if (povnone.Checked)
                conf = vJoyConf.CreateHidReportDesc((byte)(1), _axes, 0, 0, (byte)_btnnumber);
                vJoyConf.WriteHidReportDescToReg(1, ref conf);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("{0}", e.ToString());
            }
            mJoystickHandler.RefreshvJoy();
            //var bw = new BackgroundWorker();
            //bw.RunWorkerCompleted += BwOnRunWorkerCompleted;
            //bw.DoWork += (o, args) => _vJoyInstall.RefreshvJoy();
            //bw.RunWorkerAsync();

            #endregion

            Exist_AxisX = false;
            Exist_AxisY = false;
            Exist_AxisZ = false;
            Exist_AxisRX = false;
            Exist_AxisRZ = false;

            // Get the driver attributes (Vendor ID, Product ID, Version Number)
            if (!mJoystickHandler.vJoyEnabled())
            {
                Console.WriteLine("vJoy driver not enabled: Failed Getting vJoy attributes.\n");
                return;
            }
            else
                Console.WriteLine("Vendor: {0}\nProduct :{1}\nVersion Number:{2}\n", mJoystickHandler.GetvJoyManufacturerString(), mJoystickHandler.GetvJoyProductString(), mJoystickHandler.GetvJoySerialNumberString());
            // Get the state of the requested device
            VjdStat status = mJoystickHandler.GetVJDStatus(mJoystickId);
            switch (status)
            {
                case VjdStat.VJD_STAT_OWN:
                    Console.WriteLine("vJoy Device {0} is already owned by this feeder\n", mJoystickId);
                    break;
                case VjdStat.VJD_STAT_FREE:
                    Console.WriteLine("vJoy Device {0} is free\n", mJoystickId);
                    break;
                case VjdStat.VJD_STAT_BUSY:
                    Console.WriteLine("vJoy Device {0} is already owned by another feeder\nCannot continue\n", mJoystickId);
                    return;
                case VjdStat.VJD_STAT_MISS:
                    Console.WriteLine("vJoy Device {0} is not installed or disabled\nCannot continue\n", mJoystickId);
                    return;
                default:
                    Console.WriteLine("vJoy Device {0} general error\nCannot continue\n", mJoystickId);
                    return;
            };
            // Check which axes are supported
            Exist_AxisX = mJoystickHandler.GetVJDAxisExist(mJoystickId, HID_USAGES.HID_USAGE_X);
            Exist_AxisY = mJoystickHandler.GetVJDAxisExist(mJoystickId, HID_USAGES.HID_USAGE_Y);
            Exist_AxisZ = mJoystickHandler.GetVJDAxisExist(mJoystickId, HID_USAGES.HID_USAGE_Z);
            Exist_AxisRX = mJoystickHandler.GetVJDAxisExist(mJoystickId, HID_USAGES.HID_USAGE_RX);
            Exist_AxisRZ = mJoystickHandler.GetVJDAxisExist(mJoystickId, HID_USAGES.HID_USAGE_RZ);

            Console.WriteLine("Axis X\t\t{0}\n", Exist_AxisX ? "Yes" : "No");
            Console.WriteLine("Axis Y\t\t{0}\n", Exist_AxisY ? "Yes" : "No");
            Console.WriteLine("Axis Z\t\t{0}\n", Exist_AxisZ ? "Yes" : "No");
            Console.WriteLine("Axis Rx\t\t{0}\n", Exist_AxisRX ? "Yes" : "No");
            Console.WriteLine("Axis Rz\t\t{0}\n", Exist_AxisRZ ? "Yes" : "No");

            // Test if DLL matches the driver
            UInt32 DllVer = 0, DrvVer = 0;
            bool match = mJoystickHandler.DriverMatch(ref DllVer, ref DrvVer);
            if (match)
                Console.WriteLine("Version of Driver Matches DLL Version ({0:X})\n", DllVer);
            else
                Console.WriteLine("Version of Driver ({0:X}) does NOT match DLL Version ({1:X})\n", DrvVer, DllVer);

            // Acquire the target
            if ((status == VjdStat.VJD_STAT_OWN) || ((status == VjdStat.VJD_STAT_FREE) && (!mJoystickHandler.AcquireVJD(mJoystickId))))
            {
                Console.WriteLine("Failed to acquire vJoy device number {0}.\n", mJoystickId);
                return;
            }
            else
                Console.WriteLine("Acquired: vJoy device number {0}.\n", mJoystickId);

            mJoystickHandler.GetVJDAxisMax(mJoystickId, HID_USAGES.HID_USAGE_X, ref maxvalX);
            mJoystickHandler.GetVJDAxisMax(mJoystickId, HID_USAGES.HID_USAGE_Y, ref maxvalY);
            mJoystickHandler.GetVJDAxisMax(mJoystickId, HID_USAGES.HID_USAGE_Z, ref maxvalZ);
            mJoystickHandler.GetVJDAxisMax(mJoystickId, HID_USAGES.HID_USAGE_RX, ref maxvalRX);
            mJoystickHandler.GetVJDAxisMax(mJoystickId, HID_USAGES.HID_USAGE_RY, ref maxvalRY);

            // Reset this device to default values
            mJoystickHandler.ResetVJD(mJoystickId);

            //mJoystickState = true;
        }

        #region Touch Context Menu
        private void ControllerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllController();

            ToolStripMenuItem _controllersMenu = (ToolStripMenuItem)sender;
            string _controllerName = _controllersMenu.Text;

            mCustomControllerForm = new CustomControllerForm();
            initializeCustomController();
            mCustomControllerForm.loadController(_controllerName);
            mCustomControllerForm.Show();

            if (mCustomControllerMenuList.Count > 0)
            {
                foreach (ToolStripMenuItem _component in mCustomControllerMenuList)
                    _component.Checked = false;
            }
            _controllersMenu.Checked = true;
        }
        private void editControllerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllController();

            mEditBoxForm = new EditBoxForm(this);
            mEditBoxForm.Show();
        }
        private void reloadControllerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadCustomControllerMenu();
        }
        #endregion

        #region Voice Context Menu
        private void voiceControllerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuStart = ((ToolStripMenuItem)sender);

            if (menuStart.Checked)
            {
                menuStart.Checked = false;
                mVoiceController.StopController();
            }
            else
            {
                menuStart.Checked = mVoiceController.StartController();
            }
        }
        private void VoiceJoyStickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mVoiceJoystickCfgForm.ShowDialog();
        }
        #endregion

        private void aboutControllerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm _aboutForm = new AboutForm();

            _aboutForm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            notifyIcon1.Dispose();

            Thread.Sleep(120);

            System.Windows.Forms.Application.Exit();
        }
        

        #region Initialize Controller
        
        void initializeVoiceController()
        {
            mVoiceController.setJoystick(mJoystickHandler, mJoystickId);
            mVoiceController.setJoystickParameter(maxvalX, maxvalY, maxvalZ, maxvalRX, maxvalRY);
            mVoiceController.initializeController();
        }
        void initializeCustomController()
        {
            mCustomControllerForm.setJoystick(mJoystickHandler, mJoystickId);
            mCustomControllerForm.setJoystickParameter(maxvalX, maxvalY, maxvalZ, maxvalRX, maxvalRY);
            //mCustomControllerForm.setDirectInputMouse(mDirectInput);
            mCustomControllerForm.initializeController();
        }

        #endregion

        public void loadCustomControllerMenu()
        {
            ToolStripMenuItem _controllersMenu = new ToolStripMenuItem("Controllers");

            mCustomControllerMenuList.Clear();

            string _path = Path.GetDirectoryName(Application.ExecutablePath) + "\\controllers";
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }

            foreach (string _filename in Directory.EnumerateFiles(".\\controllers\\", "*.xml", SearchOption.TopDirectoryOnly))
            {
                string _menuName = Path.GetFileNameWithoutExtension(_filename); //_filename.Substring(_filename.LastIndexOf("/") + 1, _filename.Length - _filename.LastIndexOf("/") - 5);
                ToolStripMenuItem _controllerMenu = new ToolStripMenuItem(_menuName, null);
                mCustomControllerMenuList.Add(_controllerMenu);

                _controllerMenu.Click += new EventHandler(ControllerToolStripMenuItem_Click);
                _controllersMenu.DropDownItems.Add(_controllerMenu);
            }

            ToolStripMenuItem _customControllerMenu = toolStripMenuItem1;
            _customControllerMenu.DropDownItems.RemoveAt(0);
            _customControllerMenu.DropDownItems.Insert(0, _controllersMenu);
        }

        private void closeAllControllerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllController();
        }

        public MainController()
        {
            InitializeComponent();

            PopulateSource();

            initVJoyStick();

            mDirectInput = new DirectInput();

            initializeCustomController();
            initializeVoiceController();


            mVoiceJoystickCfgForm = new VoiceJoystickCfgForm(this);
            mVoiceJoystickCfgForm.setController(mVoiceController);
            //mVoiceJoystickCfgForm.loadConfigFromFile();
            mVoiceJoystickCfgForm.setConfigToButtons();

            mOptionForm = new OptionForm(this);

            loadCustomControllerMenu();

            notifyIcon1.Visible = true;

            this.ShowInTaskbar = false;
            
            this.Hide();
        }

        private void CloseAllController()
        {
            mCustomControllerForm.Close();
        }
    }
}
