using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vJoyInterfaceWrap;

namespace OnScreenController
{
    public partial class DirectionForm : Form
    {
        EditBoxForm mEditBox;
        //vJoy mJoystickHandler;
        //uint mJoystickId;

        double mOpacity = 0.5f;
        Color mBackColor = Color.FromArgb(120, 120, 120);
        Color mMovingColor = Color.FromArgb(160, 160, 160);
        //int mCircleWidth = 350;
        //int mCircleHeight = 350;
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

        bool mNeutualReleaseMouse = false;
        bool mNeutualDoubleClick = false;

        Rectangle mMovingPart = new Rectangle(150, 25, 50, 50);

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

        public DirectionForm()
        {
            InitializeComponent();
            this.Opacity = mOpacity;
            this.CircleBtn.BorderColor = mBackColor;
            this.CircleBtn.ForeColor = mMovingColor;
            mMovingPartBrush = new SolidBrush(mMovingColor);
            //this.CircleUp.Height = mCircleHeight / 2;
            //this.CircleDown.Height = mCircleHeight / 2;
            //this.CircleUp.Width = mCircleWidth;

            this.setVisibleController(false);

            adjustResizeController();
        }

        public void setEditBox(EditBoxForm editbox)
        {
            mEditBox = editbox;
        }

        public void setJoystick(vJoy joystickHandler, uint joystickId, long maxvalX, long maxvalY)
        {
        }

        private void ButtonBtn_Click(object sender, EventArgs e)
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

            this.mMovingPart.Width = Convert.ToInt32(CircleBtn.Width * (30.0 / 350.0));
            this.mMovingPart.Height = Convert.ToInt32(CircleBtn.Width * (30.0 / 350.0));
            this.mMovingPart.X = (CircleBtn.Width / 2) - (mMovingPart.Width / 2);
            this.mMovingPart.Y = 5;

            mMinXAxis = -CircleBtn.Width / 2 + mMovingPart.Width / 2;
            mMaxXAxis = CircleBtn.Width / 2 - mMovingPart.Width / 2;
            mMinYAxis = -CircleBtn.Height / 2 + mMovingPart.Height / 2;
            mMaxYAxis = CircleBtn.Height / 2 - mMovingPart.Height / 2;

            this.CircleBtn.Refresh();
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

        private void CircleBtn_MouseLeave(object sender, EventArgs e)
        {
            //bool _res;
            this.CircleBtn.Refresh();
        }

        //double angleX, angleY;
        //int mRwidth, mRheight;

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
            mStartMove = false;

            this.CircleBtn.Refresh();
        }

        SolidBrush mMovingPartBrush;

        private void CircleBtn_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.FillEllipse(mMovingPartBrush, mMovingPart);
        }

        private void DirectionForm_Activated(object sender, EventArgs e)
        {
            setVisibleController(true);
        }

        private void DirectionForm_Deactivate(object sender, EventArgs e)
        {
            setVisibleController(false);
        }
    }
}
