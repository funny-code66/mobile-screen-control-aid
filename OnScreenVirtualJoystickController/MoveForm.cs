using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using vJoyInterfaceWrap;
//using System.Threading;

namespace OnScreenController
{
    public partial class MoveForm : Form
    {


        EditBoxForm mEditBox;
        //vJoy mJoystickHandler;
        //uint mJoystickId;

        double mOpacity = 0.5f;
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

        bool mThumbEnable = false;
        uint mThumbSideIndex = 0;
        uint mThumbSideID = 0;
        uint mThumbLeftButtonIndex = 0;
        uint mThumbLeftButtonID = 0;
        uint mThumbRightButtonIndex = 0;
        uint mThumbRightButtonID = 0;

        Rectangle mMovingPart;// = new Rectangle(150,150,50,50);//?

        public int OpacityValue
        {
            get
            {
                return (int)(mOpacity * 100);
            }
            set
            {
                mOpacity = (float)value / 100.0f;
                this.Opacity = mOpacity;
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
                return this.Left;
            }
            set
            {
                this.Left = value;
            }
        }

        public int YValue
        {
            get
            {
                return this.Top;
            }
            set
            {
                this.Top = value;
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

        public bool Sizeable
        {
            get
            {
                return ResizeTopLeft.Visible;
            }
            set
            {
                setVisibleController(value);
            }
        }

        public MoveForm()
        {
            InitializeComponent();
            this.Opacity = mOpacity;
            this.CircleBtn.BackColor = mBackColor;
            this.CircleBtn.ForeColor = mForeColor;
            mMovingPartBrush = new SolidBrush(mMovingColor);
            this.CircleBtn.Height = mCircleHeight;
            this.CircleBtn.Width = mCircleWidth;

            this.setVisibleController(false);

            //CenterInRegion.Visible = false;
            //TopLeftOutRegion.Visible = false;b
            //BottomRightOutRegion.Visible = false;
            //TopRightOutRegion.Visible = false;
            //BottomLeftOutRegion.Visible = false;
            
            adjustResizeController();
        }

        public void setEditBox(EditBoxForm editbox)
        {
            mEditBox = editbox;
        }

        public void setJoystick(vJoy joystickHandler, uint joystickId, long maxvalX, long maxvalY)
        {
           
        }

        Point mPrevLocation;
        string mResizeName = "";
        //Panel mSelectedController = null;

        private void setVisibleController(bool visible)
        {
            ResizeTopLeft.Visible = visible;
            ResizeTopCenter.Visible = visible;
            ResizeTopRight.Visible = visible;
            ResizeMiddleLeft.Visible = visible;
            ResizeMiddleRight.Visible = visible;
            ResizeBottomLeft.Visible = visible;
            ResizeBottomCenter.Visible = visible;
            ResizeBottomRight.Visible = visible;
        }

        private void adjustResizeController()
        {
            ResizeTopLeft.Left = 0;
            ResizeTopLeft.Top = 0;

            ResizeTopCenter.Left = 5 + CircleBtn.Width / 2;
            ResizeTopCenter.Top = 0;

            ResizeTopRight.Left = 10 + CircleBtn.Width;
            ResizeTopRight.Top = 0;

            ResizeMiddleLeft.Left = 0;
            ResizeMiddleLeft.Top = 5 + CircleBtn.Height / 2;

            ResizeMiddleRight.Left = 10 + CircleBtn.Width;
            ResizeMiddleRight.Top = 5 + CircleBtn.Height / 2;

            ResizeBottomLeft.Left = 0;
            ResizeBottomLeft.Top = 10 + CircleBtn.Height;

            ResizeBottomCenter.Left = 5 + CircleBtn.Width / 2;
            ResizeBottomCenter.Top = 10 + CircleBtn.Height;

            ResizeBottomRight.Left = 10 + CircleBtn.Width;
            ResizeBottomRight.Top = 10 + CircleBtn.Height;

            this.mMovingPart.Width = Convert.ToInt32(CircleBtn.Width * (50.0 / 350.0));
            this.mMovingPart.Height = Convert.ToInt32(CircleBtn.Height * (50.0 / 350.0));
            this.mMovingPart.X = (CircleBtn.Width / 2) - (mMovingPart.Width / 2);
            this.mMovingPart.Y = (CircleBtn.Height / 2) - (mMovingPart.Height / 2);

            mMinXAxis = -CircleBtn.Width / 2 + mMovingPart.Width / 2 + CircleBtn.BorderWidth;
            mMaxXAxis = CircleBtn.Width / 2 - mMovingPart.Width / 2- CircleBtn.BorderWidth;
            mMinYAxis = -CircleBtn.Height / 2 + mMovingPart.Height / 2 + CircleBtn.BorderWidth;
            mMaxYAxis = CircleBtn.Height / 2 - mMovingPart.Height / 2 - CircleBtn.BorderWidth;

        }

        private void resetPropertyWindows()
        {
            mEditBox.resetProperties();
        }

        private void Resize_MouseDown(object sender, MouseEventArgs e)
        {
            Panel _resizeController = (Panel)sender;

            mResizeName = _resizeController.Name;
            mPrevLocation = _resizeController.PointToScreen(e.Location);
        }

        private void Resize_MouseMove(object sender, MouseEventArgs e)
        {
            if (mResizeName == "")
                return;
            Panel _resizeController = (Panel)sender;

            Point _curLocation = _resizeController.PointToScreen(e.Location);
            int _diffX = (_curLocation.X - mPrevLocation.X);
            int _diffY = (_curLocation.Y - mPrevLocation.Y);

            switch (mResizeName)
            {
                case "ResizeTopLeft":
                    this.Left += _diffX;
                    CircleBtn.Width -= _diffX;
                    this.Top += _diffY;
                    CircleBtn.Height -= _diffY;
                    break;
                case "ResizeTopCenter":
                    this.Top += _diffY;
                    CircleBtn.Height -= _diffY;
                    break;
                case "ResizeTopRight":
                    CircleBtn.Width += _diffX;
                    this.Top += _diffY;
                    CircleBtn.Height -= _diffY;
                    break;
                case "ResizeMiddleLeft":
                    this.Left += _diffX;
                    CircleBtn.Width -= _diffX;
                    break;
                case "ResizeMiddleRight":
                    CircleBtn.Width += _diffX;
                    break;
                case "ResizeBottomLeft":
                    //ButtonBtn.Left += _diffX;
                    this.Left += _diffX;
                    CircleBtn.Width -= _diffX;
                    CircleBtn.Height += _diffY;
                    break;
                case "ResizeBottomCenter":
                    CircleBtn.Height += _diffY;
                    break;
                case "ResizeBottomRight":
                    CircleBtn.Width += _diffX;
                    CircleBtn.Height += _diffY;
                    break;
            }

            adjustResizeController();
            resetPropertyWindows();
            mPrevLocation = _curLocation;
        }

        private void Resize_MouseUp(object sender, MouseEventArgs e)
        {
            Panel _resizeController = (Panel)sender;
            switch (mResizeName)
            {
                case "ResizeTopLeft":
                    break;
                case "ResizeTopCenter":
                    break;
                case "ResizeTopRight":
                    break;
                case "ResizeMiddleLeft":
                    break;
                case "ResizeMiddleRight":
                    break;
                case "ResizeBottomLeft":
                    break;
                case "ResizeBottomCenter":
                    break;
                case "ResizeBottomRight":
                    break;
            }
            mResizeName = "";
        }

        Point mBtnPrevLocation;
        bool mStartMove = false;

        //double hypotenuse, angle;
        //int cursorOriginX, cursorOriginY;
        //int movingPartX, movingPartY;
        //int X, Y;
        int mMinXAxis, mMaxXAxis, mMinYAxis, mMaxYAxis;
        //long maxvalX, maxvalY;


        enum THUMBSTATE
        {
            NONE,
            OVER_THUMB,
            HOLDING_THUMB,
            READY_THUMB,
            BEGIN_LEFT_THUMB,
            BEGIN_RIGHT_THUMB,
            END_THUMB
        }
        THUMBSTATE mThumbState = THUMBSTATE.NONE;



        private void StayTimer_Tick(object sender, EventArgs e)
        {
            if (mThumbState == THUMBSTATE.OVER_THUMB)
            {
                bindRegionComponent();

                visibleRegionComponent(true);
                mThumbState = THUMBSTATE.HOLDING_THUMB;
            }
        }

        private void bindRegionComponent()
        {
            int _baseX = mMovingPart.Left + 25, _baseY = mMovingPart.Top + 25;

            //CenterInRegion.Left = _baseX - 12;
            //CenterInRegion.Top = _baseY - 12;

            //TopLeftOutRegion.Left = _baseX - 24;
            //TopLeftOutRegion.Top = _baseY - 24;

            //TopRightOutRegion.Left = _baseX;
            //TopRightOutRegion.Top = _baseY - 24;

            //BottomLeftOutRegion.Left = _baseX - 24;
            //BottomLeftOutRegion.Top = _baseY;

            //BottomRightOutRegion.Left = _baseX;
            //BottomRightOutRegion.Top = _baseY;
        }

        private void visibleRegionComponent(bool visible)
        {
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
        }

        private void CircleBtn_MouseDown(object sender, MouseEventArgs e)
        {
            //bool _res;

            mEditBox.setCurrentComponent(this);
            setVisibleController(true);
            mBtnPrevLocation = CircleBtn.PointToScreen(e.Location);
            mStartMove = true;
                
            this.CircleBtn.Refresh();
        }

        private void CircleBtn_MouseMove(object sender, MouseEventArgs e)
        {
            //bool _res;
            Control _control = (Control)sender;

            if (mStartMove == false)
                return;
            Point _curLocation = CircleBtn.PointToScreen(e.Location);
            this.Left += (_curLocation.X - mBtnPrevLocation.X);
            this.Top += (_curLocation.Y - mBtnPrevLocation.Y);
            resetPropertyWindows();
            mBtnPrevLocation = _curLocation;
                    
            this.CircleBtn.Refresh();
        }

        private void CircleBtn_MouseUp(object sender, MouseEventArgs e)
        {
            //bool _res;

            mStartMove = false;
                    
            this.CircleBtn.Refresh();
        }
        SolidBrush mMovingPartBrush;

        private void CircleBtn_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.FillEllipse(mMovingPartBrush, mMovingPart);
        }

        private void MoveForm_Activated(object sender, EventArgs e)
        {
            setVisibleController(true);
        }

        private void MoveForm_Deactivate(object sender, EventArgs e)
        {
            setVisibleController(false);
        }
    }
}
