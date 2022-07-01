//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using vJoyInterfaceWrap;
using SendInput;
//using System.Diagnostics;

namespace OnScreenController
{
    class ButtonItem
    {
        uint mJoystickId;
        vJoy mJoystickHandler;
        bool mJoystickBtnState = false;

        //double mOpacity = 0.5f;
        Color mBackColor = Color.FromArgb(200, 200, 200);
        Color mForeColor = Color.FromArgb(120, 120, 120);
        string mText = "";
        float mTextSize = 30.0f;
        int mCircleWidth = 350;
        int mCircleHeight = 350;
        //int mButtonX = 0;
        //int mButtonY = 0;

        uint mInputMode = 0;
        uint mJoystickType = (uint)MainController.JOYSTICK_BUTTON_TYPE.NONE;
        uint mKeyboardType = (uint)MainController.KEYBOARD_BUTTON_TYPE.NONE;
        uint mJoystickBtnID = 0;
        uint mJoystickBtnIndex = 0;
        uint mKeycodeBtnID = 0;
        uint mKeycodeBtnIndex = 0;

        TouchControl CircleBtn;
        CustomControllerForm mControllerForm;

        #region Properties

        //public int OpacityValue
        //{
        //    get
        //    {
        //        return (int)(mOpacity * 100);
        //    }
        //    set
        //    {
        //        mOpacity = (float)value / 100.0f;
        //        this.Opacity = mOpacity;
        //    }
        //}

        public Color BackColorValue
        {
            get
            {
                return mBackColor;
            }
            set
            {
                mBackColor = value;
                this.CircleBtn.BackColor = mBackColor;
            }
        }

        public Color ForeColorValue
        {
            get
            {
                return mForeColor;
            }
            set
            {
                mForeColor = value;
                this.CircleBtn.ForeColor = mForeColor;
            }
        }

        public int XValue
        {
            get
            {
                return this.CircleBtn.Left + 10;
            }
            set
            {
                this.CircleBtn.Left = value - 10;
                this.CircleBtn.Refresh();
            }
        }

        public int YValue
        {
            get
            {
                return this.CircleBtn.Top + 10;
            }
            set
            {
                this.CircleBtn.Top = value - 10;
                this.CircleBtn.Refresh();
            }
        }

        public int HeightValue
        {
            get
            {
                return this.CircleBtn.Height;
            }
            set
            {
                this.CircleBtn.Height = value;
            }
        }

        public int WidthValue
        {
            get
            {
                return this.CircleBtn.Width;
            }
            set
            {
                this.CircleBtn.Width = value;
            }
        }

        public string TextValue
        {
            get
            {
                return mText;
            }
            set
            {
                mText = value;
                this.CircleBtn.Text = mText;
            }
        }

        public float TextSizeValue
        {
            get
            {
                return this.CircleBtn.Font.Size;
            }
            set
            {
                mTextSize = value;
                this.CircleBtn.Font = new Font(CircleBtn.Font.FontFamily, mTextSize);
            }
        }

        public uint InputMode
        {
            get
            {
                return mInputMode;
            }
            set
            {
                mInputMode = value;
            }
        }

        public uint JoystickType
        {
            get
            {
                return mJoystickType;
            }
            set
            {
                mJoystickType = value;
            }
        }

        public uint KeyboardType
        {
            get
            {
                return mKeyboardType;
            }
            set
            {
                mKeyboardType = value;
            }
        }

        public uint JoystickBtnID
        {
            get
            {
                return mJoystickBtnID;
            }
            set
            {
                mJoystickBtnID = value;
            }
        }

        public uint JoystickBtnIndex
        {
            get
            {
                return mJoystickBtnIndex;
            }
            set
            {
                mJoystickBtnIndex = value;
            }
        }

        public uint KeycodeBtnID
        {
            get
            {
                return mKeycodeBtnID;
            }
            set
            {
                mKeycodeBtnID = value;
            }
        }

        public uint KeycodeBtnIndex
        {
            get
            {
                return mKeycodeBtnIndex;
            }
            set
            {
                mKeycodeBtnIndex = value;
            }
        }

        #endregion

        public ButtonItem(CustomControllerForm controllerform)
        {
            mControllerForm = controllerform;
            InitializeComponent();
            //this.Opacity = mOpacity;
            this.CircleBtn.BackColor = mBackColor;
            this.CircleBtn.ForeColor = mForeColor;
            this.CircleBtn.Height = mCircleHeight;
            this.CircleBtn.Width = mCircleWidth;
            this.CircleBtn.Font = new Font(CircleBtn.Font.FontFamily, mTextSize);
            this.CircleBtn.Text = mText;
        }

        public void setJoystick(vJoy joystickHandler, uint joystickId, long maxvalX, long maxvalY)
        {
            mJoystickHandler = joystickHandler;
            mJoystickId = joystickId;
            //this.maxvalX = maxvalX;
            //this.maxvalY = maxvalY;
        }

        private void adjustResizeController()
        {
            
        }

        void InitializeComponent()
        {
            this.CircleBtn = new TouchControl();
            mControllerForm.SuspendLayout();
            // 
            // CircleBtn
            // 
            this.CircleBtn.AnimateBorder = false;
            this.CircleBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.CircleBtn.Blink = false;
            this.CircleBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CircleBtn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.CircleBtn.BorderWidth = 0;
            this.CircleBtn.CenterColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CircleBtn.Connector = ShapeControl.ConnecterType.Center;
            this.CircleBtn.Direction = ShapeControl.LineDirection.None;
            this.CircleBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.CircleBtn.Location = new System.Drawing.Point(10, 10);
            this.CircleBtn.Margin = new System.Windows.Forms.Padding(0);
            this.CircleBtn.Name = "CircleBtn";
            this.CircleBtn.Shape = ShapeControl.ShapeType.Ellipse;
            this.CircleBtn.ShapeImage = null;
            this.CircleBtn.ShapeImageRotation = 0;
            this.CircleBtn.ShapeImageTexture = null;
            this.CircleBtn.ShapeStorageLoadFile = "";
            this.CircleBtn.ShapeStorageSaveFile = "";
            this.CircleBtn.Size = new System.Drawing.Size(350, 350);
            this.CircleBtn.SurroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CircleBtn.TabIndex = 1;
            this.CircleBtn.Tag2 = "";
            this.CircleBtn.UseGradient = false;
            this.CircleBtn.Vibrate = false;
            //this.CircleBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CircleBtn_MouseDown);
            //this.CircleBtn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CircleBtn_MouseMove);
            //this.CircleBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CircleBtn_MouseUp);
            this.CircleBtn.TouchDown += CircleBtn_TouchDown;
            this.CircleBtn.TouchMove += CircleBtn_TouchMove;
            this.CircleBtn.TouchUp += CircleBtn_TouchUp;


            mControllerForm.Controls.Add(this.CircleBtn);
            mControllerForm.ResumeLayout(false);
        }

        #region handler of mouse and touch event
        // Touch down event handler.
        // Starts a new stroke and assigns a color to it. 
        // in:
        //      sender      object that has sent the event
        //      e           touch event arguments
        private void CircleBtn_TouchDown(object sender, WMTouchEventArgs e)
        {
            // As long as the instance is alive the conversion won't occur

            CircleBtn_MouseDown(null, null);
        }
        // Touch up event handler.
        // Finishes the stroke and moves it to the collection of finished strokes.
        // in:
        //      sender      object that has sent the event
        //      e           touch event arguments
        private void CircleBtn_TouchUp(object sender, WMTouchEventArgs e)
        {
            // To let the conversion happen again, Dispose the class.

            CircleBtn_MouseMove(null, null);
        }
        // Touch move event handler.
        // Adds a point to the active stroke and draws new stroke segment.
        // in:
        //      sender      object that has sent the event
        //      e           touch event arguments
        private void CircleBtn_TouchMove(object sender, WMTouchEventArgs e)
        {
            CircleBtn_MouseUp(null, null);
        }
        private void CircleBtn_MouseDown(object sender, MouseEventArgs e)
        {
            //bool _res;
            pressControllerBtn();
        }
        private void CircleBtn_MouseMove(object sender, MouseEventArgs e)
        {
            //bool _res;

        }
        private void CircleBtn_MouseUp(object sender, MouseEventArgs e)
        {
            //bool _res;
            releaseControllerBtn();
        }


        private void pressControllerBtn()
        {
            bool _res;

            switch (mInputMode)
            {
                case 1:
                    switch (mJoystickType)
                    {
                        case (uint)MainController.JOYSTICK_BUTTON_TYPE.PRESS:
                            mJoystickBtnState = true;
                            break;
                        case (uint)MainController.JOYSTICK_BUTTON_TYPE.RELEASE:
                            mJoystickBtnState = false;
                            break;
                        case (uint)MainController.JOYSTICK_BUTTON_TYPE.CLICK:
                            mJoystickBtnState = true;
                            break;
                        case (uint)MainController.JOYSTICK_BUTTON_TYPE.TOGGLE:
                            mJoystickBtnState = !mJoystickBtnState;
                            break;
                    }

                    _res = mJoystickHandler.SetBtn(mJoystickBtnState, mJoystickId, mJoystickBtnID);
                    break;
                case 2:
                    switch (mKeyboardType)
                    {
                        case (uint)MainController.KEYBOARD_BUTTON_TYPE.PRESS:
                            mJoystickBtnState = true;
                            _res = SendKeyboardInput.PressKey(mKeycodeBtnID);
                            break;
                        case (uint)MainController.KEYBOARD_BUTTON_TYPE.RELEASE:
                            mJoystickBtnState = false;
                            _res = SendKeyboardInput.ReleaseKey(mKeycodeBtnID);
                            break;
                        case (uint)MainController.KEYBOARD_BUTTON_TYPE.CLICK:
                            mJoystickBtnState = true;
                            _res = SendKeyboardInput.PressKey(mKeycodeBtnID);
                            break;
                        case (uint)MainController.KEYBOARD_BUTTON_TYPE.TOGGLE:
                            mJoystickBtnState = !mJoystickBtnState;
                            if (mJoystickBtnState)
                                _res = SendKeyboardInput.PressKey(mKeycodeBtnID);
                            else
                                _res = SendKeyboardInput.ReleaseKey(mKeycodeBtnID);
                            break;
                    }
                    break;
            }
        }

        private void releaseControllerBtn()
        {
            bool _res;

            switch (mInputMode)
            {
                case 1:
                    switch (mJoystickType)
                    {
                        case (uint)MainController.JOYSTICK_BUTTON_TYPE.PRESS:
                            break;
                        case (uint)MainController.JOYSTICK_BUTTON_TYPE.RELEASE:
                            break;
                        case (uint)MainController.JOYSTICK_BUTTON_TYPE.CLICK:
                            mJoystickBtnState = false;
                            break;
                        case (uint)MainController.JOYSTICK_BUTTON_TYPE.TOGGLE:
                            break;
                    }

                    _res = mJoystickHandler.SetBtn(mJoystickBtnState, mJoystickId, mJoystickBtnID);
                    break;
                case 2:
                    switch (mKeyboardType)
                    {
                        case (uint)MainController.KEYBOARD_BUTTON_TYPE.PRESS:
                            break;
                        case (uint)MainController.KEYBOARD_BUTTON_TYPE.RELEASE:
                            break;
                        case (uint)MainController.KEYBOARD_BUTTON_TYPE.CLICK:
                            mJoystickBtnState = false;
                            _res = SendKeyboardInput.ReleaseKey(mKeycodeBtnID);
                            break;
                        case (uint)MainController.KEYBOARD_BUTTON_TYPE.TOGGLE:
                            break;
                    }
                    break;
            }
        }
        #endregion
    }
}
