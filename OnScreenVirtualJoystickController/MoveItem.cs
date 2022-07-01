using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using vJoyInterfaceWrap;
using System.Drawing;
using System.Windows.Forms;
using SendInput;

namespace OnScreenController
{
    class MoveItem
    {
        vJoy mJoystickHandler;
        uint mJoystickId;

        //double mOpacity = 0.5f;
        Color mBackColor = Color.FromArgb(200, 200, 200);
        Color mForeColor = Color.FromArgb(120, 120, 120);
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

        bool mThumbEnable = false;
        uint mThumbSideIndex = 0;
        uint mThumbSideID = 0;
        uint mThumbLeftButtonIndex = 0;
        uint mThumbLeftButtonID = 0;
        uint mThumbRightButtonIndex = 0;
        uint mThumbRightButtonID = 0;

        Rectangle mMovingPart;

        TouchControl CircleBtn;
        CustomControllerForm mControllerForm;
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

        #region properties
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
                this.CircleBtn.BorderColor = mForeColor;
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
                this.CircleBtn.Left = value;
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
                this.CircleBtn.Refresh();
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
                this.CircleBtn.Refresh();
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

        public bool ThumbEnable
        {
            get
            {
                return mThumbEnable;
            }
            set
            {
                this.mThumbEnable = value;
            }
        }

        public uint ThumbSideIndex
        {
            get
            {
                return mThumbSideIndex;
            }
            set
            {
                this.mThumbSideIndex = value;
            }
        }

        public uint ThumbSideID
        {
            get
            {
                return mThumbSideID;
            }
            set
            {
                this.mThumbSideID = value;
            }
        }

        public uint ThumbLeftButtonIndex
        {
            get
            {
                return mThumbLeftButtonIndex;
            }
            set
            {
                this.mThumbLeftButtonIndex = value;
            }
        }

        public uint ThumbLeftButtonID
        {
            get
            {
                return mThumbLeftButtonID;
            }
            set
            {
                this.mThumbLeftButtonID = value;
            }
        }

        public uint ThumbRightButtonIndex
        {
            get
            {
                return mThumbRightButtonIndex;
            }
            set
            {
                this.mThumbRightButtonIndex = value;
            }
        }

        public uint ThumbRightButtonID
        {
            get
            {
                return mThumbRightButtonID;
            }
            set
            {
                this.mThumbRightButtonID = value;
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

        public MoveItem(CustomControllerForm controllerform)
        {
            mControllerForm = controllerform;
            InitializeComponent();
            //this.Opacity = mOpacity;
            this.CircleBtn.BackColor = mBackColor;
            this.CircleBtn.ForeColor = mForeColor;
            mMovingPartBrush = new SolidBrush(mMovingColor);
            this.CircleBtn.Height = mCircleHeight;
            this.CircleBtn.Width = mCircleWidth;

        }

        public void setJoystick(vJoy joystickHandler, uint joystickId, long maxvalX, long maxvalY)
        {
            mJoystickHandler = joystickHandler;
            mJoystickId = joystickId;
            this.maxvalX = maxvalX;
            this.maxvalY = maxvalY;
        }

        private void adjustResizeController()
        {
            this.mMovingPart.Width = Convert.ToInt32(CircleBtn.Width * (50.0 / 350.0));
            this.mMovingPart.Height = Convert.ToInt32(CircleBtn.Height * (50.0 / 350.0));
            this.mMovingPart.Y = (CircleBtn.Height / 2) - (mMovingPart.Height / 2);
            this.mMovingPart.X = (CircleBtn.Width / 2) - (mMovingPart.Width / 2);

            mMinXAxis = -CircleBtn.Width / 2 + mMovingPart.Width / 2 + CircleBtn.BorderWidth;
            mMaxXAxis = CircleBtn.Width / 2 - mMovingPart.Width / 2 - CircleBtn.BorderWidth;
            mMinYAxis = -CircleBtn.Height / 2 + mMovingPart.Height / 2 + CircleBtn.BorderWidth;
            mMaxYAxis = CircleBtn.Height / 2 - mMovingPart.Height / 2 - CircleBtn.BorderWidth;

        }

        void InitializeComponent()
        {
            this.CircleBtn = new TouchControl();
            
            mControllerForm.SuspendLayout();

            // 
            // CircleBtn
            // 
            this.CircleBtn.AnimateBorder = false;
            this.CircleBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.CircleBtn.Blink = false;
            this.CircleBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.CircleBtn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.CircleBtn.BorderWidth = 15;
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
            this.CircleBtn.TabIndex = 13;
            this.CircleBtn.UseGradient = false;
            this.CircleBtn.Vibrate = false;
            this.CircleBtn.Paint += new System.Windows.Forms.PaintEventHandler(this.CircleBtn_Paint);

            //this.CircleBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CircleBtn_MouseDown);
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
        int X=0, Y=0;
        //int mXTimeInterval = 0, mYTimeInterval = 0;
        //uint mHorizontoalKeycodeID = 0, mVerticalKeycodeID = 0;
        int mMinXAxis, mMaxXAxis, mMinYAxis, mMaxYAxis;
        long maxvalX, maxvalY;


        //enum THUMBSTATE
        //{
        //    NONE,
        //    OVER_THUMB,
        //    HOLDING_THUMB,
        //    READY_THUMB,
        //    BEGIN_LEFT_THUMB,
        //    BEGIN_RIGHT_THUMB,
        //    END_THUMB
        //}
        //THUMBSTATE mThumbState = THUMBSTATE.NONE;

        //private void StayTimer_Tick(object sender, EventArgs e)
        //{
        //    if (mThumbState == THUMBSTATE.OVER_THUMB)
        //    {
        //        bindRegionComponent();

        //        visibleRegionComponent(true);
        //        mThumbState = THUMBSTATE.HOLDING_THUMB;
        //    }
        //}

        //private void bindRegionComponent()
        //{
        //    int _baseX = mMovingPart.X + 25, _baseY = mMovingPart.Y + 25;
        //}

        //private void visibleRegionComponent(bool visible)
        //{
            //if (mThumbSideID == 0)
            //{
            //    CenterInRegion.Visible = visible;
            //    TopLeftOutRegion.Visible = visible;
            //    BottomRightOutRegion.Visible = visible;
            //}
            //else
            //{
            //    CenterInRegion.Visible = visible;
            //    TopRightOutRegion.Visible = visible;
            //    BottomLeftOutRegion.Visible = visible;
            //}
        //}
        #region handler of mouse and touch event

        private void setAxisOutput(int AxisX, int AxisY)
        {
            bool _res;
            int _mouseX = 0, _mouseY = 0;
            //_res = mJoystickHandler.SetAxis(this.Y, mJoystickId, mHorizontalAxis);
            //_res = mJoystickHandler.SetAxis(this.X, mJoystickId, mVerticalAxis);d

            
            switch (mHorizontalInputMode)
            {
                case (uint)CustomControllerForm.INPUT_TYPE.JOYSTICK:
                    _res = mJoystickHandler.SetAxis(this.X, mJoystickId, (HID_USAGES)mHorizontalAxisID);
                    break;
                case (uint)CustomControllerForm.INPUT_TYPE.KEYBOARD:
                    AxisX = AxisX - (int)(maxvalX / 2);
                    if (Math.Abs(AxisX) < maxvalX * 0.15)
                    {
                        _res = SendKeyboardInput.ReleaseKey(mKeycodeLeftID);
                        _res = SendKeyboardInput.ReleaseKey(mKeycodeRightID);
                    }
                    else if(AxisX < 0)
                    {
                        _res = SendKeyboardInput.PressKey(mKeycodeLeftID);
                        _res = SendKeyboardInput.ReleaseKey(mKeycodeRightID);
                    }
                    else if(AxisX > 0)
                    {
                        _res = SendKeyboardInput.ReleaseKey(mKeycodeLeftID);
                        _res = SendKeyboardInput.PressKey(mKeycodeRightID);
                    }
                    
                    break;
                case (uint)CustomControllerForm.INPUT_TYPE.MOUSE:
                    AxisX = AxisX - (int)(maxvalX / 2);
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
                    _res = mJoystickHandler.SetAxis(this.Y, mJoystickId, (HID_USAGES)mVerticalAxisID);
                    break;
                case (uint)CustomControllerForm.INPUT_TYPE.KEYBOARD:
                    AxisY = AxisY - (int)(maxvalY / 2);
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
                    AxisY = AxisY - (int)(maxvalY / 2);
                    if (mMouseYID == 1)
                    {
                        _mouseX = (int)((AxisY >> 10) * mMouseSensitive);
                    }
                    else if (mMouseYID == 2)
                    {
                        _mouseY = (int)((AxisY >> 10) * mMouseSensitive);
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
            //bool _res;
            //int _mouseX = 0, _mouseY = 0;
            //if (mThumbEnable)
            //    mThumbState = THUMBSTATE.OVER_THUMB;

            if (e.Button == MouseButtons.Left)
            {
                movingPartX = e.X - (mMovingPart.Width / 2);
                movingPartY = e.Y - (mMovingPart.Height / 2);
                cursorOriginX = e.X - (CircleBtn.Width / 2);
                cursorOriginY = e.Y - (CircleBtn.Height / 2);

                hypotenuse = Math.Sqrt(cursorOriginX * cursorOriginX + cursorOriginY * cursorOriginY);
                double _maxHypotenuse = Math.Sqrt(mMaxXAxis * mMaxXAxis + mMaxYAxis * mMaxYAxis);

                if (hypotenuse < mMaxXAxis)
                {
                    if (cursorOriginX < mMaxXAxis && cursorOriginX > mMinXAxis)//x 
                    {
                        mMovingPart.X = movingPartX;
                    }
                    if (cursorOriginY < mMaxYAxis && cursorOriginY > mMinYAxis)//y 
                    {
                        mMovingPart.Y = movingPartY;
                    }
                }
                // Set position of 4 axes
                this.X = Convert.ToInt32((cursorOriginX + mMaxXAxis) * maxvalX / (mMaxXAxis - mMinXAxis));
                this.Y = Convert.ToInt32((cursorOriginY + mMaxYAxis) * maxvalY / (mMaxYAxis - mMinYAxis));
                //this.Z = Convert.ToInt32((0 + 125) * maxvalZ / 250);
                //this.RX = Convert.ToInt32((0 + 125) * maxvalRX / 250);
                //this.RY = Convert.ToInt32((0 + 125) * maxvalRY / 250);

                setAxisOutput(this.X, this.Y);
            }
            this.CircleBtn.Refresh();
        }

        private void CircleBtn_MouseMove(object sender, MouseEventArgs e)
        {
            //bool _res;
            //int _mouseX = 0, _mouseY = 0;
            Control _control = (Control)sender;

            //if (mThumbEnable)
            //{
            //    Point _mousePoint = _control.PointToScreen(e.Location);
                //switch (mThumbState)
                //{
                //    case THUMBSTATE.OVER_THUMB:
                //        StayTimer.Stop();
                //        StayTimer.Start();
                //        break;
                //    case THUMBSTATE.HOLDING_THUMB:
                //        Console.WriteLine("THUMBSTATE.HOLDING_THUMB\n");
                //        if (CenterInRegion.Outline.IsVisible(CenterInRegion.PointToClient(_mousePoint)))
                //        {
                //            mThumbState = THUMBSTATE.READY_THUMB;
                //            bindRegionComponent();
                //        }
                //        break;
                //    case THUMBSTATE.READY_THUMB:
                //        Console.WriteLine("THUMBSTATE.READY_THUMB\n");

                //        if (mThumbSideID == 0)
                //        {
                //            if (TopLeftOutRegion.Outline.IsVisible(TopLeftOutRegion.PointToClient(_mousePoint)))
                //            {
                //                mThumbState = THUMBSTATE.BEGIN_LEFT_THUMB;
                //            }
                //            else if (BottomRightOutRegion.Outline.IsVisible(BottomRightOutRegion.PointToClient(_mousePoint)))
                //            {
                //                mThumbState = THUMBSTATE.BEGIN_RIGHT_THUMB;
                //            }
                //            else if (CenterInRegion.Outline.IsVisible(CenterInRegion.PointToClient(_mousePoint)))
                //            {
                //                mThumbState = THUMBSTATE.READY_THUMB;
                //            }
                //            else
                //            {
                //                mThumbState = THUMBSTATE.OVER_THUMB;
                //                visibleRegionComponent(false);
                //            }
                //        }
                //        else if (mThumbSideID == 1)
                //        {
                //            if (TopRightOutRegion.Outline.IsVisible(TopRightOutRegion.PointToClient(_mousePoint)))
                //            {
                //                mThumbState = THUMBSTATE.BEGIN_RIGHT_THUMB;
                //            }
                //            else if (BottomLeftOutRegion.Outline.IsVisible(BottomLeftOutRegion.PointToClient(_mousePoint)))
                //            {
                //                mThumbState = THUMBSTATE.BEGIN_LEFT_THUMB;
                //            }
                //            else if (CenterInRegion.Outline.IsVisible(CenterInRegion.PointToClient(_mousePoint)))
                //            {
                //                mThumbState = THUMBSTATE.READY_THUMB;
                //            }
                //            else
                //            {
                //                mThumbState = THUMBSTATE.OVER_THUMB;
                //                visibleRegionComponent(false);
                //            }
                //        }
                //        break;
                //    case THUMBSTATE.BEGIN_LEFT_THUMB:
                //        Console.WriteLine("THUMBSTATE.BEGIN_LEFT_THUMB\n");
                //        if (mThumbSideID == 0)
                //        {
                //            if (TopLeftOutRegion.Outline.IsVisible(TopLeftOutRegion.PointToClient(_mousePoint)))
                //            {
                //                mThumbState = THUMBSTATE.BEGIN_LEFT_THUMB;
                //            }
                //            else if (CenterInRegion.Outline.IsVisible(CenterInRegion.PointToClient(_mousePoint)))
                //            {
                //                mThumbState = THUMBSTATE.HOLDING_THUMB;
                //                _res = mJoystickHandler.SetBtn(true, mJoystickId, mThumbLeftButtonID);
                //                Thread.Sleep(10);
                //                _res = mJoystickHandler.SetBtn(false, mJoystickId, mThumbLeftButtonID);
                //            }
                //            else
                //            {
                //                mThumbState = THUMBSTATE.OVER_THUMB;
                //                visibleRegionComponent(false);
                //            }
                //        }
                //        else if (mThumbSideID == 1)
                //        {
                //            if (BottomLeftOutRegion.Outline.IsVisible(BottomLeftOutRegion.PointToClient(_mousePoint)))
                //            {
                //                mThumbState = THUMBSTATE.BEGIN_LEFT_THUMB;
                //            }
                //            else if (CenterInRegion.Outline.IsVisible(CenterInRegion.PointToClient(_mousePoint)))
                //            {
                //                mThumbState = THUMBSTATE.HOLDING_THUMB;
                //                _res = mJoystickHandler.SetBtn(true, mJoystickId, mThumbLeftButtonID);
                //                Thread.Sleep(10);
                //                _res = mJoystickHandler.SetBtn(false, mJoystickId, mThumbLeftButtonID);
                //            }
                //            else
                //            {
                //                mThumbState = THUMBSTATE.OVER_THUMB;
                //                visibleRegionComponent(false);
                //            }
                //        }
                //        break;
                //    case THUMBSTATE.BEGIN_RIGHT_THUMB:
                //        Console.WriteLine("THUMBSTATE.BEGIN_RIGHT_THUMB\n");
                //        if (mThumbSideID == 0)
                //        {
                //            if (BottomRightOutRegion.Outline.IsVisible(BottomRightOutRegion.PointToClient(_mousePoint)))
                //            {
                //                mThumbState = THUMBSTATE.BEGIN_RIGHT_THUMB;
                //            }
                //            else if (CenterInRegion.Outline.IsVisible(CenterInRegion.PointToClient(_mousePoint)))
                //            {
                //                mThumbState = THUMBSTATE.HOLDING_THUMB;
                //                _res = mJoystickHandler.SetBtn(true, mJoystickId, mThumbRightButtonID);
                //                Thread.Sleep(10);
                //                _res = mJoystickHandler.SetBtn(false, mJoystickId, mThumbRightButtonID);
                //            }
                //            else
                //            {
                //                mThumbState = THUMBSTATE.OVER_THUMB;
                //                visibleRegionComponent(false);
                //            }
                //        }
                //        else if (mThumbSideID == 1)
                //        {
                //            if (TopRightOutRegion.Outline.IsVisible(TopRightOutRegion.PointToClient(_mousePoint)))
                //            {
                //                mThumbState = THUMBSTATE.BEGIN_RIGHT_THUMB;
                //            }
                //            else if (CenterInRegion.Outline.IsVisible(CenterInRegion.PointToClient(_mousePoint)))
                //            {
                //                mThumbState = THUMBSTATE.HOLDING_THUMB;
                //                _res = mJoystickHandler.SetBtn(true, mJoystickId, mThumbRightButtonID);
                //                Thread.Sleep(10);
                //                _res = mJoystickHandler.SetBtn(false, mJoystickId, mThumbRightButtonID);
                //            }
                //            else
                //            {
                //                mThumbState = THUMBSTATE.OVER_THUMB;
                //                visibleRegionComponent(false);
                //            }
                //        }
                //        break;
                //}

                //if (mThumbState == THUMBSTATE.BEGIN_LEFT_THUMB || mThumbState == THUMBSTATE.BEGIN_RIGHT_THUMB)
                //    return;
            //}

            if (e.Button == MouseButtons.Left)
            {
                movingPartX = e.X - (mMovingPart.Width / 2);
                movingPartY = e.Y - (mMovingPart.Height / 2);
                cursorOriginX = e.X - (CircleBtn.Width / 2);
                cursorOriginY = e.Y - (CircleBtn.Height / 2);

                hypotenuse = Math.Sqrt(cursorOriginX * cursorOriginX + cursorOriginY * cursorOriginY);
                double _maxHypotenuse = Math.Sqrt(mMaxXAxis * mMaxXAxis + mMaxYAxis * mMaxYAxis);

                if (hypotenuse < mMaxXAxis)
                {
                    if (cursorOriginX < mMaxXAxis && cursorOriginX > mMinXAxis)//x 
                    {
                        mMovingPart.X = movingPartX;
                    }
                    if (cursorOriginY < mMaxYAxis && cursorOriginY > mMinYAxis)//y 
                    {
                        mMovingPart.Y = movingPartY;
                    }
                }
                // Set position of 4 axes
                this.X = Convert.ToInt32((cursorOriginX + mMaxXAxis) * maxvalX / (mMaxXAxis - mMinXAxis));
                this.Y = Convert.ToInt32((cursorOriginY + mMaxYAxis) * maxvalY / (mMaxYAxis - mMinYAxis));
                //this.Z = Convert.ToInt32((0 + 125) * maxvalZ / 250);
                //this.RX = Convert.ToInt32((0 + 125) * maxvalRX / 250);
                //this.RY = Convert.ToInt32((0 + 125) * maxvalRY / 250);

                setAxisOutput(this.X, this.Y);
            }
            this.CircleBtn.Refresh();
        }
        private void CircleBtn_MouseUp(object sender, MouseEventArgs e)
        {
            //bool _res;
            //int _mouseX = 0, _mouseY = 0;
            //mThumbState = THUMBSTATE.NONE;
            //visibleRegionComponent(false);

            if (e.Button == MouseButtons.Left)
            {
                mMovingPart.X = CircleBtn.Width / 2 - mMovingPart.Width / 2;
                mMovingPart.Y = CircleBtn.Height / 2 - mMovingPart.Height / 2;

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
