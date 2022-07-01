using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Drawing;
using vJoyInterfaceWrap;
using System.Windows.Forms;
using SendInput;

namespace OnScreenController
{
    class DirectionItem
    {
        vJoy mJoystickHandler;
        uint mJoystickId;

        double mOpacity = 0.5f;
        Color mBackColor = Color.FromArgb(120, 120, 120);
        Color mMovingColor = Color.FromArgb(160, 160, 160);
        int mCircleWidth = 350;
        int mCircleHeight = 350;
        //int mButtonX = 0;
        //int mButtonY = 0;

        uint mHorizontalInputMode = 0;
        uint mVerticalInputMode = 0;
        uint mHorizontalAxisID = 0;
        uint mHorizontalAxisIndex = 0;
        uint mVerticalAxisID = 0;
        uint mVerticalAxisIndex = 0;
        uint mKeycodeLeftID = 0;
        uint mKeycodeLeftIndex = 0;
        uint mKeycodeRightID = 0;
        uint mKeycodeRightIndex = 0;
        uint mKeycodeUpID = 0;
        uint mKeycodeUpIndex = 0;
        uint mKeycodeDownID = 0;
        uint mKeycodeDownIndex = 0;
        uint mMouseXID = 0;
        uint mMouseXIndex = 0;
        uint mMouseYID = 0;
        uint mMouseYIndex = 0;
        double mMouseSensitive = 3;

        bool mNeutualLeaveMouse = false;
        bool mNeutualDoubleClick = false;
        bool mNeutualReleaseMouse = false;

        Rectangle mMovingPart;

        TouchControl CircleBtn;
        CustomControllerForm mControllerForm;

        #region properties
        public int OpacityValue
        {
            get
            {
                return (int)(mOpacity * 100);
            }
            set
            {
                mOpacity = (float)value / 100.0f;
                mControllerForm.Opacity = mOpacity;
            }
        }
        public Color BackColorValue
        {
            get
            {
                return mBackColor;
            }
            set
            {
                mBackColor = value;
                this.CircleBtn.BorderColor = mBackColor;
            }
        }


        public Color MovingColorValue
        {
            get
            {
                return mMovingColor;
            }
            set
            {
                mMovingColor = value;
                mMovingPartBrush = new SolidBrush(value);
                this.CircleBtn.Refresh();
            }
        }

        public int XValue
        {
            get
            {
                return CircleBtn.Left;
            }
            set
            {
                CircleBtn.Left = value;
            }
        }

        public int YValue
        {
            get
            {
                return CircleBtn.Top;
            }
            set
            {
                CircleBtn.Top = value;
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
                adjustResizeController();
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
                adjustResizeController();
            }
        }

        public uint HorizontalInputMode
        {
            get
            {
                return mHorizontalInputMode;
            }
            set
            {
                mHorizontalInputMode = value;
            }
        }

        public uint VerticalInputMode
        {
            get
            {
                return mVerticalInputMode;
            }
            set
            {
                mVerticalInputMode = value;
            }
        }

        public uint HorizontalAxisIndex
        {
            get
            {
                return mHorizontalAxisIndex;
            }
            set
            {
                this.mHorizontalAxisIndex = value;
            }
        }

        public uint HorizontalAxisID
        {
            get
            {
                return mHorizontalAxisID;
            }
            set
            {
                this.mHorizontalAxisID = value;
            }
        }

        public uint VerticalAxisIndex
        {
            get
            {
                return mVerticalAxisIndex;
            }
            set
            {
                this.mVerticalAxisIndex = value;
            }
        }

        public uint VerticalAxisID
        {
            get
            {
                return mVerticalAxisID;
            }
            set
            {
                this.mVerticalAxisID = value;
            }
        }

        public uint KeycodeLeftIndex
        {
            get
            {
                return mKeycodeLeftIndex;
            }
            set
            {
                this.mKeycodeLeftIndex = value;
            }
        }

        public uint KeycodeLeftID
        {
            get
            {
                return mKeycodeLeftID;
            }
            set
            {
                this.mKeycodeLeftID = value;
            }
        }

        public uint KeycodeRightIndex
        {
            get
            {
                return mKeycodeRightIndex;
            }
            set
            {
                this.mKeycodeRightIndex = value;
            }
        }

        public uint KeycodeRightID
        {
            get
            {
                return mKeycodeRightID;
            }
            set
            {
                this.mKeycodeRightID = value;
            }
        }

        public uint KeycodeUpIndex
        {
            get
            {
                return mKeycodeUpIndex;
            }
            set
            {
                this.mKeycodeUpIndex = value;
            }
        }

        public uint KeycodeUpID
        {
            get
            {
                return mKeycodeUpID;
            }
            set
            {
                this.mKeycodeUpID = value;
            }
        }

        public uint KeycodeDownIndex
        {
            get
            {
                return mKeycodeDownIndex;
            }
            set
            {
                this.mKeycodeDownIndex = value;
            }
        }

        public uint KeycodeDownID
        {
            get
            {
                return mKeycodeDownID;
            }
            set
            {
                this.mKeycodeDownID = value;
            }
        }

        public uint MouseXIndex
        {
            get
            {
                return mMouseXIndex;
            }
            set
            {
                this.mMouseXIndex = value;
            }
        }

        public uint MouseXID
        {
            get
            {
                return mMouseXID;
            }
            set
            {
                this.mMouseXID = value;
            }
        }

        public uint MouseYIndex
        {
            get
            {
                return mMouseYIndex;
            }
            set
            {
                this.mMouseYIndex = value;
            }
        }

        public uint MouseYID
        {
            get
            {
                return mMouseYID;
            }
            set
            {
                this.mMouseYID = value;
            }
        }

        public bool NeutualReleaseMouse
        {
            get
            {
                return mNeutualReleaseMouse;
            }
            set
            {
                mNeutualReleaseMouse = value;
            }
        }

        public bool NeutualLeaveMouse
        {
            get
            {
                return mNeutualLeaveMouse;
            }
            set
            {
                mNeutualLeaveMouse = value;
            }
        }

        public bool NeutualDoubleClick
        {
            get
            {
                return mNeutualDoubleClick;
            }
            set
            {
                mNeutualDoubleClick = value;
            }
        }

        public double MouseSensitive
        {
            get
            {
                return mMouseSensitive;
            }
            set
            {
                this.mMouseSensitive = value;
            }
        }
        #endregion

        public DirectionItem(CustomControllerForm controllerform)
        {
            mControllerForm = controllerform;
            InitializeComponent();
            //this.Opacity = mOpacity;
            this.CircleBtn.BorderColor = mBackColor;
            //this.CircleBtn.ForeColor = mForeColor;
            mMovingPartBrush = new SolidBrush(mMovingColor);
            CircleBtn.Height = mCircleHeight;
            CircleBtn.Width = mCircleWidth;

        }

        public void setJoystick(vJoy joystickHandler, uint joystickId, long maxvalX, long maxvalY)
        {
            mJoystickHandler = joystickHandler;
            mJoystickId = joystickId;
            this.maxvalX = maxvalX;//
            this.maxvalY = maxvalY;//
        }

        private void adjustResizeController()
        {
            this.mMovingPart.Width = Convert.ToInt32(CircleBtn.Width * (30.0 / 350.0));
            this.mMovingPart.Height = Convert.ToInt32(CircleBtn.Height * (30.0 / 350.0));
            this.mMovingPart.X = (CircleBtn.Width / 2) - (mMovingPart.Width / 2);
            this.mMovingPart.Y = 5;

            mMinXAxis = -CircleBtn.Width / 2 + mMovingPart.Width / 2;
            mMaxXAxis = CircleBtn.Width / 2 - mMovingPart.Width / 2;
            mMinYAxis = -CircleBtn.Height / 2 + mMovingPart.Height / 2;
            mMaxYAxis = CircleBtn.Height / 2 - mMovingPart.Height / 2;

            this.CircleBtn.Refresh();
        }

        void InitializeComponent()
        {
            this.CircleBtn = new TouchControl();

            mControllerForm.SuspendLayout();
            // 
            // CircleBtn
            // 
            this.CircleBtn.AnimateBorder = false;
            this.CircleBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CircleBtn.Blink = false;
            this.CircleBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.CircleBtn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.CircleBtn.BorderWidth = 40;
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
            this.CircleBtn.TabIndex = 11;
            this.CircleBtn.Tag2 = "";
            this.CircleBtn.UseGradient = false;
            this.CircleBtn.Vibrate = false;
            this.CircleBtn.Paint += new System.Windows.Forms.PaintEventHandler(this.CircleBtn_Paint);
            //this.CircleBtn.DoubleClick += new System.EventHandler(this.CircleBtn_DoubleClick);
            //this.CircleBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CircleBtn_MouseDown);
            //this.CircleBtn.MouseLeave += new System.EventHandler(this.CircleBtn_MouseLeave);
            //this.CircleBtn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CircleBtn_MouseMove);
            //this.CircleBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CircleBtn_MouseUp);
            this.CircleBtn.TouchDown += CircleBtn_TouchDown;
            this.CircleBtn.TouchMove += CircleBtn_TouchMove;
            this.CircleBtn.TouchUp += CircleBtn_TouchUp;

            mControllerForm.Controls.Add(this.CircleBtn);
            
            mControllerForm.ResumeLayout(false);
        }


        //Point mBtnPrevLocation;
        //bool mStartMove = false;

        //double hypotenuse, angle;
        double hypotenuse;
        int cursorOriginX, cursorOriginY;
        int movingPartX, movingPartY;
        int X, Y;
        //int mXTimeInterval = 0, mYTimeInterval = 0;
        //uint mHorizontoalKeycodeID = 0, mVerticalKeycodeID = 0;
        int mMinXAxis, mMaxXAxis, mMinYAxis, mMaxYAxis;
        long maxvalX, maxvalY;

        private void CircleBtn_MouseLeave(object sender, EventArgs e)
        {
            //bool _res;
            if (mNeutualLeaveMouse)
            {
                // Set position of 4 axes
                this.X = Convert.ToInt32((0 + mMaxXAxis) * maxvalX / (mMaxXAxis - mMinXAxis));
                this.Y = Convert.ToInt32((0 + mMaxYAxis) * maxvalY / (mMaxYAxis - mMinYAxis));
                //this.Z = Convert.ToInt32((0 + 125) * maxvalZ / 250);
                //this.RX = Convert.ToInt32((0 + 125) * maxvalRX / 250);
                //this.RY = Convert.ToInt32((0 + 125) * maxvalRY / 250);
                //Console.WriteLine("X:{0}.Y:{1}\n", this.X, this.Y);

                // Set position of 4 axes

                //_res = mJoystickHandler.SetAxis(this.X, mJoystickId, (HID_USAGES)mHorizontalAxisID);
                //_res = mJoystickHandler.SetAxis(this.Y, mJoystickId, (HID_USAGES)mVerticalAxisID);

                setAxisOutput(this.X, this.Y);
            }
            this.CircleBtn.Refresh();
        }

        private void CircleBtn_DoubleClick(object sender, EventArgs e)
        {
            //bool _res;
            
            if (mNeutualDoubleClick)
            {
                // Set position of 4 axes
                this.X = Convert.ToInt32((0 + mMaxXAxis) * maxvalX / (mMaxXAxis - mMinXAxis));
                this.Y = Convert.ToInt32((0 + mMaxYAxis) * maxvalY / (mMaxYAxis - mMinYAxis));
                //this.Z = Convert.ToInt32((0 + 125) * maxvalZ / 250);
                //this.RX = Convert.ToInt32((0 + 125) * maxvalRX / 250);
                //this.RY = Convert.ToInt32((0 + 125) * maxvalRY / 250);
                //Console.WriteLine("X:{0}.Y:{1}\n", this.X, this.Y);

                // Set position of 4 axes

                //_res = mJoystickHandler.SetAxis(this.X, mJoystickId, (HID_USAGES)mHorizontalAxisID);
                //_res = mJoystickHandler.SetAxis(this.Y, mJoystickId, (HID_USAGES)mVerticalAxisID);

                setAxisOutput(this.X, this.Y);
            }
            this.CircleBtn.Refresh();
        }

        //double angleX, angleY;
        int mRwidth, mRheight;

        #region mouse and touch handler

        private void setAxisOutput(int AxisX, int AxisY)
        {
            bool _res;
            int _mouseX = 0, _mouseY = 0;
            //_res = mJoystickHandler.SetAxis(this.Y, mJoystickId, mHorizontalAxis);
            //_res = mJoystickHandler.SetAxis(this.X, mJoystickId, mVerticalAxis);d

            switch (mHorizontalInputMode)
            {
                case (uint)CustomControllerForm.INPUT_TYPE.JOYSTICK:
                    _res = mJoystickHandler.SetAxis(AxisX, mJoystickId, (HID_USAGES)mHorizontalAxisID);
                    break;
                case (uint)CustomControllerForm.INPUT_TYPE.KEYBOARD:
                    AxisX = AxisX - (int)(maxvalX/2);
                    if (Math.Abs(AxisX) < maxvalX * 0.15)
                    {
                        _res = SendKeyboardInput.ReleaseKey(mKeycodeLeftID);
                        _res = SendKeyboardInput.ReleaseKey(mKeycodeRightID);
                    }
                    else if (AxisX < 0)
                    {
                        _res = SendKeyboardInput.PressKey(mKeycodeLeftID);
                        _res = SendKeyboardInput.ReleaseKey(mKeycodeRightID);
                    }
                    else if (AxisX > 0)
                    {
                        _res = SendKeyboardInput.ReleaseKey(mKeycodeLeftID);
                        _res = SendKeyboardInput.PressKey(mKeycodeRightID);
                    }
                    break;
                case (uint)CustomControllerForm.INPUT_TYPE.MOUSE:
                    AxisX = AxisX - (int)(maxvalX/2);
                    if (mMouseXID == 1)
                    {
                        _mouseX = (int)((AxisX >> 10) * mMouseSensitive);
                    }
                    else if (mMouseXID == 2)
                    {
                        _mouseY = (int)((AxisX >> 10) * mMouseSensitive);
                    }
                    _res = SendMouseInput.MoveMouseXY(_mouseX, _mouseY);
                    break;
            }
            switch (mVerticalInputMode)
            {
                case (uint)CustomControllerForm.INPUT_TYPE.JOYSTICK:
                    _res = mJoystickHandler.SetAxis(AxisY, mJoystickId, (HID_USAGES)mVerticalAxisID);
                    break;
                case (uint)CustomControllerForm.INPUT_TYPE.KEYBOARD:
                    AxisY = AxisY - (int)(maxvalY/2);
                    if (Math.Abs(AxisY) < maxvalX * 0.15)
                    {
                        _res = SendKeyboardInput.ReleaseKey(mKeycodeDownID);
                        _res = SendKeyboardInput.ReleaseKey(mKeycodeUpID);
                    }
                    else if (AxisY < 0)
                    {
                        _res = SendKeyboardInput.PressKey(mKeycodeDownID);
                        _res = SendKeyboardInput.ReleaseKey(mKeycodeUpID);
                    }
                    else if (AxisY > 0)
                    {
                        _res = SendKeyboardInput.ReleaseKey(mKeycodeDownID);
                        _res = SendKeyboardInput.PressKey(mKeycodeUpID);
                    }
                    break;
                case (uint)CustomControllerForm.INPUT_TYPE.MOUSE:
                    AxisY = AxisY - (int)(maxvalY/2);
                    if (mMouseYID == 1)
                    {
                        _mouseX = (AxisY >> 10) * (int)mMouseSensitive;
                    }
                    else if (mMouseYID == 2)
                    {
                        _mouseY = (AxisY >> 10) * (int)mMouseSensitive;
                    }
                    _res = SendMouseInput.MoveMouseXY(_mouseX, _mouseY);
                    break;
            }
        }
        // Touch down event handler.
        // Starts a new stroke and assigns a color to it. 
        // in:
        //      sender      object that has sent the event
        //      e           touch event arguments
        private void CircleBtn_TouchDown(object sender, WMTouchEventArgs e)
        {
            // As long as the instance is alive the conversion won't occur

            MouseEventArgs _arg = new MouseEventArgs(MouseButtons.Left, 1, e.LocationX, e.LocationY, 0);
            CircleBtn_MouseDown(null, _arg);
        }
        // Touch up event handler.
        // Finishes the stroke and moves it to the collection of finished strokes.
        // in:
        //      sender      object that has sent the event
        //      e           touch event arguments
        private void CircleBtn_TouchUp(object sender, WMTouchEventArgs e)
        {
            // To let the conversion happen again, Dispose the class.

            MouseEventArgs _arg = new MouseEventArgs(MouseButtons.Left, 2, e.LocationX, e.LocationY, 0);
            CircleBtn_MouseUp(null, _arg);
        }
        // Touch move event handler.
        // Adds a point to the active stroke and draws new stroke segment.
        // in:
        //      sender      object that has sent the event
        //      e           touch event arguments
        private void CircleBtn_TouchMove(object sender, WMTouchEventArgs e)
        {
            MouseEventArgs _arg = new MouseEventArgs(MouseButtons.Left, 0, e.LocationX, e.LocationY, 0);
            CircleBtn_MouseMove(null, _arg);
        }
        private void CircleBtn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cursorOriginX = e.X - (CircleBtn.Width / 2);
                cursorOriginY = e.Y - (CircleBtn.Height / 2);

                hypotenuse = Math.Sqrt(cursorOriginX * cursorOriginX + cursorOriginY * cursorOriginY);

                if (hypotenuse < CircleBtn.Width / 2)
                {
                    mRwidth = CircleBtn.Width / 2 - mMovingPart.Width / 2 - CircleBtn.BorderWidth / 8;
                    mRheight = CircleBtn.Height / 2 - mMovingPart.Height / 2 - CircleBtn.BorderWidth / 8;

                    movingPartX = (int)((mRwidth) * cursorOriginX / hypotenuse + CircleBtn.Width / 2 - mMovingPart.Width / 2);
                    movingPartY = (int)((mRheight) * cursorOriginY / hypotenuse + CircleBtn.Height / 2 - mMovingPart.Height / 2);

                    mMovingPart.X = movingPartX;
                    mMovingPart.Y = movingPartY;
                }
                // Set position of 4 axes
                this.X = Convert.ToInt32((cursorOriginX + mMaxXAxis) * maxvalX / (mMaxXAxis - mMinXAxis));
                this.Y = Convert.ToInt32((cursorOriginY + mMaxYAxis) * maxvalY / (mMaxYAxis - mMinYAxis));
                //this.Z = Convert.ToInt32((0 + 125) * maxvalZ / 250);
                //this.RX = Convert.ToInt32((0 + 125) * maxvalRX / 250);
                //this.RY = Convert.ToInt32((0 + 125) * maxvalRY / 250);
                //Console.WriteLine("X:{0}.Y:{1}\n", this.X, this.Y);

                setAxisOutput(this.X, this.Y);

            }
            this.CircleBtn.Refresh();
        }
        private void CircleBtn_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cursorOriginX = e.X - (CircleBtn.Width / 2);
                cursorOriginY = e.Y - (CircleBtn.Height / 2);

                hypotenuse = Math.Sqrt(cursorOriginX * cursorOriginX + cursorOriginY * cursorOriginY);

                if (hypotenuse < CircleBtn.Width / 2)
                {
                    mRwidth = CircleBtn.Width / 2 - mMovingPart.Width / 2 - CircleBtn.BorderWidth / 8;
                    mRheight = CircleBtn.Height / 2 - mMovingPart.Height / 2 - CircleBtn.BorderWidth / 8;

                    movingPartX = (int)((mRwidth) * cursorOriginX / hypotenuse + CircleBtn.Width / 2 - mMovingPart.Width / 2);
                    movingPartY = (int)((mRheight) * cursorOriginY / hypotenuse + CircleBtn.Height / 2 - mMovingPart.Height / 2);

                    mMovingPart.X = movingPartX;
                    mMovingPart.Y = movingPartY;
                }
                // Set position of 4 axes
                this.X = Convert.ToInt32((cursorOriginX + mMaxXAxis) * maxvalX / (mMaxXAxis - mMinXAxis));
                this.Y = Convert.ToInt32((cursorOriginY + mMaxYAxis) * maxvalY / (mMaxYAxis - mMinYAxis));
                //this.Z = Convert.ToInt32((0 + 125) * maxvalZ / 250);
                //this.RX = Convert.ToInt32((0 + 125) * maxvalRX / 250);
                //this.RY = Convert.ToInt32((0 + 125) * maxvalRY / 250);
                //Console.WriteLine("X:{0}.Y:{1}\n", this.X, this.Y);

                setAxisOutput(this.X, this.Y);
            }
            this.CircleBtn.Refresh();
        }
        private void CircleBtn_MouseUp(object sender, MouseEventArgs e)
        {
            //bool _res;
            //int _mouseX = 0, _mouseY = 0;

            if(mNeutualReleaseMouse)
            {
                //mMovingPart.X = CircleBtn.Width / 2 - mMovingPart.Width / 2;
                //mMovingPart.Y = CircleBtn.Height / 2 - mMovingPart.Height / 2;

                // Set position of 4 axes
                this.X = Convert.ToInt32((0 + mMaxXAxis) * maxvalX / (mMaxXAxis - mMinXAxis));
                this.Y = Convert.ToInt32((0 + mMaxYAxis) * maxvalY / (mMaxYAxis - mMinYAxis));
                //this.Z = Convert.ToInt32((0 + 125) * maxvalZ / 250);
                //this.RX = Convert.ToInt32((0 + 125) * maxvalRX / 250);
                //this.RY = Convert.ToInt32((0 + 125) * maxvalRY / 250);
                //Console.WriteLine("X:{0}.Y:{1}\n", e.X, e.Y);

                setAxisOutput(this.X, this.Y);
            }

            this.CircleBtn.Refresh();
        }

        #endregion

        SolidBrush mMovingPartBrush;

        private void CircleBtn_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.FillEllipse(mMovingPartBrush, mMovingPart);
        }

    }
}
