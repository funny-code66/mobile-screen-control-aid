namespace vJoyInterfaceWrap {
    using System;
    using System.IO;
    using System.Xml;

    public class VJoyConfPreset {
        private readonly string _name;
        public readonly byte BtnCount;
        public readonly byte PovCount;
        public readonly Pov PovType;
        public readonly bool Uaxis;
        public readonly bool Vaxis;
        public readonly bool Xaxis;
        public readonly bool Xaxisrot;
        public readonly bool Yaxis;
        public readonly bool Yaxisrot;
        public readonly bool Zaxis;
        public readonly bool Zaxisrot;

        public VJoyConfPreset() {
            _name = "Default";
            BtnCount = 8;
            PovCount = 0;
            PovType = Pov.None;
            Xaxis = true;
            Yaxis = true;
            Zaxis = true;
            Zaxisrot = true;
        }

        public VJoyConfPreset(string xmlfile): this(File.OpenRead(xmlfile), true) { }

        public VJoyConfPreset(Stream xmlfilestream, bool closeHandle = false) {
            using(var xml = XmlReader.Create(xmlfilestream)) {
                while(xml.Read()) {
                    if(!xml.IsStartElement())
                        continue;
                    switch(xml.Name.ToLower()) {
                        case "name":
                            xml.Read();
                            _name = xml.Value;
                            break;
                        case "xaxis":
                            xml.Read();
                            Xaxis = !string.IsNullOrEmpty(xml.Value) && xml.Value.Equals("true", StringComparison.CurrentCultureIgnoreCase);
                            break;
                        case "yaxis":
                            xml.Read();
                            Yaxis = !string.IsNullOrEmpty(xml.Value) && xml.Value.Equals("true", StringComparison.CurrentCultureIgnoreCase);
                            break;
                        case "zaxis":
                            xml.Read();
                            Zaxis = !string.IsNullOrEmpty(xml.Value) && xml.Value.Equals("true", StringComparison.CurrentCultureIgnoreCase);
                            break;
                        case "xaxisrot":
                            xml.Read();
                            Xaxisrot = !string.IsNullOrEmpty(xml.Value) && xml.Value.Equals("true", StringComparison.CurrentCultureIgnoreCase);
                            break;
                        case "yaxisrot":
                            xml.Read();
                            Yaxisrot = !string.IsNullOrEmpty(xml.Value) && xml.Value.Equals("true", StringComparison.CurrentCultureIgnoreCase);
                            break;
                        case "zaxisrot":
                            xml.Read();
                            Zaxisrot = !string.IsNullOrEmpty(xml.Value) && xml.Value.Equals("true", StringComparison.CurrentCultureIgnoreCase);
                            break;
                        case "uaxis":
                            xml.Read();
                            Uaxis = !string.IsNullOrEmpty(xml.Value) && xml.Value.Equals("true", StringComparison.CurrentCultureIgnoreCase);
                            break;
                        case "vaxis":
                            xml.Read();
                            Vaxis = !string.IsNullOrEmpty(xml.Value) && xml.Value.Equals("true", StringComparison.CurrentCultureIgnoreCase);
                            break;
                        case "povtype":
                            xml.Read();
                            byte tmp;
                            if(byte.TryParse(xml.Value, out tmp))
                                PovType = (Pov)tmp;
                            switch(PovType) {
                                case Pov.Cont:
                                case Pov.Dir:
                                    break;
                                default:
                                    PovType = Pov.None; // Make sure it's none if it's not a compatible value
                                    break;
                            }
                            break;
                        case "povcount":
                            xml.Read();
                            byte.TryParse(xml.Value, out PovCount);
                            break;
                        case "btncount":
                            xml.Read();
                            byte.TryParse(xml.Value, out BtnCount);
                            break;
                    }
                }
            }
            try {
                if(closeHandle)
                    xmlfilestream.Close();
            }
            catch {}
        }

        public override string ToString() { return _name; }

        public enum Pov: byte {
            None = 0,
            Cont = 1,
            Dir = 2
        }
    }
}