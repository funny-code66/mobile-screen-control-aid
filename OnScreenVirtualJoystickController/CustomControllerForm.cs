using System;
using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
//using System.IO;
using System.Xml;
using vJoyInterfaceWrap;
//using System.Runtime.InteropServices;
//using System.Diagnostics;
//using System.Security.Permissions;
//using SharpDX;
//using SharpDX.DirectInput;

namespace OnScreenController
{
    public partial class CustomControllerForm : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        //[System.Runtime.InteropServices.DllImport("user32", EntryPoint = "SetActiveWindow", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        public static extern long SetActiveWindow(long hwnd);

        private const int WS_EX_TOOLWINDOW = 0x00000080;
        private const int WS_EX_NOACTIVATE = 0x08000000;

        public enum INPUT_TYPE
        {
            NONE = 0,
            JOYSTICK,
            KEYBOARD,
            MOUSE
        };

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= (WS_EX_NOACTIVATE | WS_EX_TOOLWINDOW);
                cp.Parent = IntPtr.Zero; // Keep this line only if you used UserControl
                return cp;
                //return base.CreateParams;
            }
        }

        List<object> mCustomController = new List<object>();
        
        //Form mMinimizeBtn;

        long maxvalX, maxvalY, maxvalZ, maxvalRX, maxvalRY;
        vJoy mJoystickHandler;
        //vJoy.JoystickState iReport;
        uint mJoystickId;
        double mMouseSensitive = 3;

        DisableTouchConversionToMouse disableTouchMouse;

        private void CustomControllerForm_Load(object sender, EventArgs e)
        {
            disableTouchMouse = new DisableTouchConversionToMouse();
            //mCustomController.Clear();
        }

        private void CustomControllerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (object obj in mCustomController)
            {
                if (obj.GetType().ToString().Contains("MinimizeButtonForm"))
                {
                    ((MinimizeButtonForm)obj).Close();
                }
            }
            mCustomController.Clear();
            disableTouchMouse.Dispose();
        }

        public void setJoystick(vJoy joystick, uint joystickId)
        {
            mJoystickHandler = joystick;
            mJoystickId = joystickId;
        }

        public void setJoystickParameter(long mX, long mY, long mZ, long mRX, long mRY)
        {
            maxvalX = mX;
            maxvalY = mY;
            maxvalZ = mZ;
            maxvalRX = mRX;
            maxvalRY = mRY;
        }

        public CustomControllerForm()
        {
            InitializeComponent();
            this.TransparencyKey = this.BackColor;
        }

        public void initializeController()
        {
            this.Left = 0; this.Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Refresh();
            //to initialize joystick driver

        }

        #region load controller
        public void loadController(string controllername)
        {
            string _path = "./controllers/" + controllername + ".xml";
            XmlTextReader _xmlReader = new XmlTextReader(_path);
            this.SuspendLayout();
            mCustomController.Clear();
            this.Controls.Clear();
            this.ResumeLayout(false);

            string _currentTagName = "";
            while (_xmlReader.Read())
            {
                switch (_xmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (_xmlReader.Name == "Button")
                        {
                            loadButtonComponent(_xmlReader);
                        }
                        else if (_xmlReader.Name == "Move")
                        {
                            loadMoveComponent(_xmlReader);
                        }
                        else if (_xmlReader.Name == "Direction")
                        {
                            loadDirectionComponent(_xmlReader);
                        }
                        else if (_xmlReader.Name == "Touch")
                        {
                            loadTouchComponent(_xmlReader);
                        }
                        else if (_xmlReader.Name == "minBtn")
                        {
                            loadMinBtnComponent(_xmlReader);
                        }
                        else if (_xmlReader.Name == "MSensitive")
                        {
                            loadMouseSensitiveComponent(_xmlReader);
                        }
                        _currentTagName = _xmlReader.Name;
                        break;
                    case XmlNodeType.Text:
                        if (_currentTagName == "Name" && _xmlReader.Value != controllername)
                        {
                            return;
                        }
                        break;
                    case XmlNodeType.EndElement:
                        _currentTagName = "";
                        break;
                }
            }
            
        }

        private ButtonItem loadButtonComponent(XmlTextReader xmlReader)
        {
            ButtonItem _component = new ButtonItem(this);
            _component.setJoystick(mJoystickHandler, mJoystickId, maxvalX, maxvalY);
            mCustomController.Add(_component);

            string _currentTagName = "";
            while (xmlReader.Read())
            {
                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        _currentTagName = xmlReader.Name;
                        break;
                    case XmlNodeType.Text:
                        if (_currentTagName == "XValue")
                        {
                            _component.XValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "YValue")
                        {
                            _component.YValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "WidthValue")
                        {
                            _component.WidthValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "HeightValue")
                        {
                            _component.HeightValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "TextValue")
                        {
                            _component.TextValue = xmlReader.Value;
                        }
                        else if (_currentTagName == "BackColorValue")
                        {
                            _component.BackColorValue = Color.FromArgb(Convert.ToInt32(xmlReader.Value));
                        }
                        else if (_currentTagName == "ForeColorValue")
                        {
                            _component.ForeColorValue = Color.FromArgb(Convert.ToInt32(xmlReader.Value));
                        }
                        else if (_currentTagName == "OpacityValue")
                        {
                            //_component.OpacityValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "InputMode")
                        {
                            _component.InputMode = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "JoystickType")
                        {
                            _component.JoystickType = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "KeyboardType")
                        {
                            _component.KeyboardType = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "JoystickBtnName")
                        {
                            _component.JoystickBtnIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "JoystickBtnID")
                        {
                            _component.JoystickBtnID = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "KeycodeBtnName")
                        {
                            _component.KeycodeBtnIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "KeycodeBtnID")
                        {
                            _component.KeycodeBtnID = Convert.ToUInt32(xmlReader.Value);
                        }

                        break;
                    case XmlNodeType.EndElement:
                        _currentTagName = "";
                        if (xmlReader.Name == "Button")
                        {
                            _component.setJoystick(mJoystickHandler, mJoystickId, maxvalX, maxvalY);
                            return _component;
                        }
                        break;
                }
            }

            return _component;
        }

        private MoveItem loadMoveComponent(XmlTextReader xmlReader)
        {
            MoveItem _component = new MoveItem(this);
            _component.setJoystick(mJoystickHandler, mJoystickId, maxvalX, maxvalY);
            mCustomController.Add(_component);

            _component.MouseSensitive = mMouseSensitive;

            string _currentTagName = "";
            while (xmlReader.Read())
            {
                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        _currentTagName = xmlReader.Name;
                        break;
                    case XmlNodeType.Text:
                        if (_currentTagName == "MouseXName")
                        {
                            _component.MouseXIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "MouseXID")
                        {
                            _component.MouseXID = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "MouseYName")
                        {
                            _component.MouseYIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "MouseYID")
                        {
                            _component.MouseYID = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "XValue")
                        {
                            _component.XValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "YValue")
                        {
                            _component.YValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "WidthValue")
                        {
                            _component.WidthValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "HeightValue")
                        {
                            _component.HeightValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "BackColorValue")
                        {
                            _component.BackColorValue = Color.FromArgb(Convert.ToInt32(xmlReader.Value));
                        }
                        else if (_currentTagName == "ForeColorValue")
                        {
                            _component.ForeColorValue = Color.FromArgb(Convert.ToInt32(xmlReader.Value));
                        }
                        else if (_currentTagName == "MovingColorValue")
                        {
                            _component.MovingColorValue = Color.FromArgb(Convert.ToInt32(xmlReader.Value));
                        }
                        else if (_currentTagName == "OpacityValue")
                        {
                            //_component.OpacityValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "HorizontalInputMode")
                        {
                            _component.HorizontalInputMode = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "VerticalInputMode")
                        {
                            _component.VerticalInputMode = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "HorizontalAxisName")
                        {
                            _component.HorizontalAxisIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "HorizontalAxisID")
                        {
                            _component.HorizontalAxisID = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "VerticalAxisName")
                        {
                            _component.VerticalAxisIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "VerticalAxisID")
                        {
                            _component.VerticalAxisID = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "KeycodeLeftName")
                        {
                            _component.KeycodeLeftIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "KeycodeLeftID")
                        {
                            _component.KeycodeLeftID = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "KeycodeRightName")
                        {
                            _component.KeycodeRightIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "KeycodeRightID")
                        {
                            _component.KeycodeRightID = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "KeycodeUpName")
                        {
                            _component.KeycodeUpIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "KeycodeUpID")
                        {
                            _component.KeycodeUpID = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "KeycodeDownName")
                        {
                            _component.KeycodeDownIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "KeycodeDownID")
                        {
                            _component.KeycodeDownID = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "ThumbEnable")
                        {
                            _component.ThumbEnable = Convert.ToBoolean(xmlReader.Value);
                        }
                        else if (_currentTagName == "ThumbSideName")
                        {
                            _component.ThumbSideIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "ThumbSideID")
                        {
                            _component.ThumbSideID = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "ThumbLeftButtonName")
                        {
                            _component.ThumbLeftButtonIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "ThumbLeftButtonID")
                        {
                            _component.ThumbLeftButtonID = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "ThumbRightButtonName")
                        {
                            _component.ThumbRightButtonIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "ThumbRightButtonID")
                        {
                            _component.ThumbRightButtonID = Convert.ToUInt32(xmlReader.Value);
                        }
                        break;
                    case XmlNodeType.EndElement:
                        if (xmlReader.Name == "Move")
                        {
                            _component.setJoystick(mJoystickHandler, mJoystickId, maxvalX, maxvalY);
                            return _component;
                        }
                        break;
                }
            }
            
            return _component;
        }

        private DirectionItem loadDirectionComponent(XmlTextReader xmlReader)
        {
            DirectionItem _component = new DirectionItem(this);
            _component.setJoystick(mJoystickHandler, mJoystickId, maxvalX, maxvalY);
            mCustomController.Add(_component);

            _component.MouseSensitive = mMouseSensitive;

            string _currentTagName = "";
            while (xmlReader.Read())
            {
                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        _currentTagName = xmlReader.Name;
                        break;
                    case XmlNodeType.Text:
                        if (_currentTagName == "MouseXName")
                        {
                            _component.MouseXIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "MouseXID")
                        {
                            _component.MouseXID = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "MouseYName")
                        {
                            _component.MouseYIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "MouseYID")
                        {
                            _component.MouseYID = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "NeutualReleaseMouse")
                        {
                            _component.NeutualReleaseMouse = Convert.ToBoolean(xmlReader.Value);
                        }
                        else if (_currentTagName == "NeutualDoubleClick")
                        {
                            _component.NeutualDoubleClick = Convert.ToBoolean(xmlReader.Value);
                        }
                        else if (_currentTagName == "XValue")
                        {
                            _component.XValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "YValue")
                        {
                            _component.YValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "WidthValue")
                        {
                            _component.WidthValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "HeightValue")
                        {
                            _component.HeightValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "BackColorValue")
                        {
                            _component.BackColorValue = Color.FromArgb(Convert.ToInt32(xmlReader.Value));
                        }
                        else if (_currentTagName == "OpacityValue")
                        {
                            _component.OpacityValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "MovingColorValue")
                        {
                            _component.MovingColorValue = Color.FromArgb(Convert.ToInt32(xmlReader.Value));
                        }
                        else if (_currentTagName == "HorizontalInputMode")
                        {
                            _component.HorizontalInputMode = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "VerticalInputMode")
                        {
                            _component.VerticalInputMode = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "HorizontalAxisName")
                        {
                            _component.HorizontalAxisIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "HorizontalAxisID")
                        {
                            _component.HorizontalAxisID = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "VerticalAxisName")
                        {
                            _component.VerticalAxisIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "VerticalAxisID")
                        {
                            _component.VerticalAxisID = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "KeycodeLeftName")
                        {
                            _component.KeycodeLeftIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "KeycodeLeftID")
                        {
                            _component.KeycodeLeftID = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "KeycodeRightName")
                        {
                            _component.KeycodeRightIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "KeycodeRightID")
                        {
                            _component.KeycodeRightID = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "KeycodeUpName")
                        {
                            _component.KeycodeUpIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "KeycodeUpID")
                        {
                            _component.KeycodeUpID = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "KeycodeDownName")
                        {
                            _component.KeycodeDownIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "KeycodeDownID")
                        {
                            _component.KeycodeDownID = Convert.ToUInt32(xmlReader.Value);
                        }
                        break;
                    case XmlNodeType.EndElement:
                        if (xmlReader.Name == "Direction")
                        {
                            _component.setJoystick(mJoystickHandler, mJoystickId, maxvalX, maxvalY);
                            return _component;
                        }
                        break;
                }
            }

            return _component;
        }

        private TouchItem loadTouchComponent(XmlTextReader xmlReader)
        {
            TouchItem _component = new TouchItem(this);
            _component.setJoystick(mJoystickHandler, mJoystickId, maxvalX, maxvalY);
            mCustomController.Add(_component);

            string _currentTagName = "";
            while (xmlReader.Read())
            {
                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        _currentTagName = xmlReader.Name;
                        break;
                    case XmlNodeType.Text:
                        if (_currentTagName == "XValue")
                        {
                            _component.XValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "YValue")
                        {
                            _component.YValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "WidthValue")
                        {
                            _component.WidthValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "HeightValue")
                        {
                            _component.HeightValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "BackColorValue")
                        {
                            _component.BackColorValue = Color.FromArgb(Convert.ToInt32(xmlReader.Value));
                        }
                        else if (_currentTagName == "ForeColorValue")
                        {
                            _component.ForeColorValue = Color.FromArgb(Convert.ToInt32(xmlReader.Value));
                        }
                        else if (_currentTagName == "OpacityValue")
                        {
                            //_component.OpacityValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "GestureIDs")
                        {
                            Dictionary<string, uint> _gestureIDs = new Dictionary<string, uint>();
                            string[] _pairs = xmlReader.Value.Split(':');
                            foreach (string _pair in _pairs)
                            {
                                string[] _gesture = _pair.Split(',');
                                _gestureIDs.Add(_gesture[0], Convert.ToUInt32(_gesture[1]));
                            }
                        }
                        break;
                    case XmlNodeType.EndElement:
                        if (xmlReader.Name == "Touch")
                        {
                            _component.setJoystick(mJoystickHandler, mJoystickId, maxvalX, maxvalY);
                            return _component;
                        }
                        break;
                }
            }

            return _component;
        }

        private MinimizeButtonForm loadMinBtnComponent(XmlTextReader xmlReader)
        {
            MinimizeButtonForm _component = new MinimizeButtonForm(MinimizeButtonForm.COMPONENTMODE.RUN_MODE);
            _component.Show();
            mCustomController.Add(_component);

            string _currentTagName = "";
            while (xmlReader.Read())
            {
                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        _currentTagName = xmlReader.Name;
                        break;
                    case XmlNodeType.Text:
                        if (_currentTagName == "XValue")
                        {
                            _component.XValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "YValue")
                        {
                            _component.YValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "WidthValue")
                        {
                            _component.WidthValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "HeightValue")
                        {
                            _component.HeightValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "BackColorValue")
                        {
                            _component.BackColorValue = Color.FromArgb(Convert.ToInt32(xmlReader.Value));
                        }
                        else if (_currentTagName == "BorderColorValue")
                        {
                            _component.BorderColorValue = Color.FromArgb(Convert.ToInt32(xmlReader.Value));
                        }
                        else if (_currentTagName == "OpacityValue")
                        {
                            _component.OpacityValue = Convert.ToInt32(xmlReader.Value);
                        }
                        break;
                    case XmlNodeType.EndElement:
                        if (xmlReader.Name == "minBtn")
                        {
                            _component.setComponentList(this);
                            return _component;
                        }
                        break;
                }
            }

            return _component;
        }

        private void loadMouseSensitiveComponent(XmlTextReader xmlReader)
        {
            string _currentTagName = "";
            while (xmlReader.Read())
            {
                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        _currentTagName = xmlReader.Name;
                        break;
                    case XmlNodeType.Text:
                        if (_currentTagName == "Value")
                        {
                            mMouseSensitive = Convert.ToDouble(xmlReader.Value);
                        }
                        break;
                    case XmlNodeType.EndElement:
                        if (xmlReader.Name == "MSensitive")
                        {
                            //_component.setJoystick(mJoystickHandler, mJoystickId);
                            return;
                        }
                        break;
                }
            }
        }
        #endregion
    }
}
