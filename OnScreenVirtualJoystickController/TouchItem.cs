using System;
using System.Collections.Generic;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using vJoyInterfaceWrap;

namespace OnScreenController
{
    class TouchItem
    {
        vJoy mJoystickHandler;
        uint mJoystickId;

        //double mOpacity = 0.5f;
        Color mBackColor = Color.FromArgb(120, 120, 120);
        Color mForeColor = Color.FromArgb(160, 160, 160);
        //int mCircleWidth = 350;
        //int mCircleHeight = 350;
        //int mButtonX = 0;
        //int mButtonY = 0;
        Dictionary<string, uint> mGestureIDs = new Dictionary<string, uint>();

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
                mTrackBrush = new SolidBrush(mForeColor);
                this.CircleBtn.Refresh();
            }
        }

        public int XValue
        {
            get
            {
                return CircleBtn.Left + 10;
            }
            set
            {
                CircleBtn.Left = value - 10;
            }
        }

        public int YValue
        {
            get
            {
                return CircleBtn.Top + 10;
            }
            set
            {
                CircleBtn.Top = value - 10;
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

        public Dictionary<string, uint> GestureIDs
        {
            get
            {
                return mGestureIDs;
            }
            set
            {
                mGestureIDs = value;
            }
        }

        public string Gesture
        {
            get
            {
                return mGestureResult;
            }
            set
            {
                mGestureResult = value;
                mControllerForm.Refresh();
            }
        }
        #endregion

        public TouchItem(CustomControllerForm controllerform)
        {
            mControllerForm = controllerform;
            InitializeComponent();
            //this.Opacity = mOpacity;
            //this.CircleBtn.BackColor = mBackColor;
            //this.CircleBtn.ForeColor = mForeColor;
            //this.MovingPart.BackColor = mMovingColor;
            //this.CircleUp.Height = mCircleHeight / 2;
            //this.CircleDown.Height = mCircleHeight / 2;
            //this.CircleUp.Width = mCircleWidth;

            mTopLeft = new RectangleF(85, 85, 15, 15);
            mTopCenter = new RectangleF(165, 85, 15, 15);
            mTopRight = new RectangleF(245, 85, 15, 15);

            mMiddleLeft = new RectangleF(85, 165, 15, 15);
            mMiddleCenter = new RectangleF(165, 165, 15, 15);
            mMiddleRight = new RectangleF(245, 165, 15, 15);

            mBottomLeft = new RectangleF(85, 245, 15, 15);
            mBottomCenter = new RectangleF(165, 245, 15, 15);
            mBottomRight = new RectangleF(245, 245, 15, 15);

            mGestureRectList.Add(mTopLeft);
            mGestureRectList.Add(mTopCenter);
            mGestureRectList.Add(mTopRight);

            mGestureRectList.Add(mMiddleLeft);
            mGestureRectList.Add(mMiddleCenter);
            mGestureRectList.Add(mMiddleRight);

            mGestureRectList.Add(mBottomLeft);
            mGestureRectList.Add(mBottomCenter);
            mGestureRectList.Add(mBottomRight);

            mCurrectTrackPoint = new Point(0, 0);
            mCurrentGestureRect = new RectangleF(0, 0, 0, 0);

            mTrackLineWidth = 7;

            mTrackBrush = new SolidBrush(mForeColor);
            mTrackPen = new Pen(Color.White, mTrackLineWidth);
            mTrackPen.Alignment = System.Drawing.Drawing2D.PenAlignment.Outset;
        }

        public void setJoystick(vJoy joystickHandler, uint joystickId, long maxvalX, long maxvalY)
        {
            mJoystickHandler = joystickHandler;
            mJoystickId = joystickId;
        }


        private void adjustResizeController()
        {
            mTopLeft = new RectangleF(85 * CircleBtn.Width / 350, 85 * CircleBtn.Height / 350, 15, 15);
            mTopCenter = new RectangleF(165 * CircleBtn.Width / 350, 85 * CircleBtn.Height / 350, 15, 15);
            mTopRight = new RectangleF(245 * CircleBtn.Width / 350, 85 * CircleBtn.Height / 350, 15, 15);

            mMiddleLeft = new RectangleF(85 * CircleBtn.Width / 350, 165 * CircleBtn.Height / 350, 15, 15);
            mMiddleCenter = new RectangleF(165 * CircleBtn.Width / 350, 165 * CircleBtn.Height / 350, 15, 15);
            mMiddleRight = new RectangleF(245 * CircleBtn.Width / 350, 165 * CircleBtn.Height / 350, 15, 15);

            mBottomLeft = new RectangleF(85 * CircleBtn.Width / 350, 245 * CircleBtn.Height / 350, 15, 15);
            mBottomCenter = new RectangleF(165 * CircleBtn.Width / 350, 245 * CircleBtn.Height / 350, 15, 15);
            mBottomRight = new RectangleF(245 * CircleBtn.Width / 350, 245 * CircleBtn.Height / 350, 15, 15);
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
            this.CircleBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CircleBtn.Blink = false;
            this.CircleBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CircleBtn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.CircleBtn.BorderWidth = 3;
            this.CircleBtn.CenterColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CircleBtn.Connector = ShapeControl.ConnecterType.Center;
            this.CircleBtn.Direction = ShapeControl.LineDirection.None;
            this.CircleBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.CircleBtn.Location = new System.Drawing.Point(10, 10);
            this.CircleBtn.Name = "CircleBtn";
            this.CircleBtn.Shape = ShapeControl.ShapeType.Ellipse;
            this.CircleBtn.ShapeImage = null;
            this.CircleBtn.ShapeImageRotation = 0;
            this.CircleBtn.ShapeImageTexture = null;
            this.CircleBtn.ShapeStorageLoadFile = "";
            this.CircleBtn.ShapeStorageSaveFile = "";
            this.CircleBtn.Size = new System.Drawing.Size(350, 350);
            this.CircleBtn.SurroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CircleBtn.TabIndex = 19;
            this.CircleBtn.Tag2 = "";
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

        public void GestureToTrackList()
        {
            mTrackPointList.Clear();
            foreach (char _ch in mGestureResult.ToArray())
            {
                int _index = Convert.ToInt32(_ch) - Convert.ToInt32('1');
                RectangleF _rect = mGestureRectList[_index];
                mTrackPointList.Add(new PointF(_rect.X + _rect.Width / 2, _rect.Y + _rect.Height / 2));
            }
            CircleBtn.Refresh();
        }

        #region mouse and touch handler
        // Touch down event handler.
        // Starts a new stroke and assigns a color to it. 
        // in:
        //      sender      object that has sent the event
        //      e           touch event arguments
        private void CircleBtn_TouchDown(object sender, WMTouchEventArgs e)
        {
            // As long as the instance is alive the conversion won't occur=

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
            // To let the conversion happen again, Dispose the class.=

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
                int i = 0;
                foreach (RectangleF _rect in mGestureRectList)
                {
                    i++;
                    if (_rect.Contains(e.Location))
                    {
                        mTrackPointList.Add(new PointF(_rect.X + _rect.Width / 2, _rect.Y + _rect.Height / 2));
                        mGestureResult += i;
                        mCurrentGestureRect = _rect;
                        break;
                    }
                }
            }
        }
        private void CircleBtn_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int i = 0;
                foreach (RectangleF _rect in mGestureRectList)
                {
                    i++;
                    if (!mCurrentGestureRect.Equals(_rect) && _rect.Contains(e.Location))
                    {
                        mTrackPointList.Add(new PointF(_rect.X + _rect.Width / 2, _rect.Y + _rect.Height / 2));
                        mGestureResult += i;
                        mCurrentGestureRect = _rect;
                        break;
                    }
                }
                mCurrectTrackPoint = e.Location;
                CircleBtn.Refresh();
            }
        }
        private void CircleBtn_MouseUp(object sender, MouseEventArgs e)
        {
            //bool _res;

            if (e.Button == MouseButtons.Left)
            {
                //int i = 0;

                //foreach (RectangleF _rect in mGestureRectList)
                //{
                //    i++;
                //    if (_rect.Contains(e.Location))
                //    {
                //        mTrackPointList.Add(new PointF(_rect.X + _rect.Width / 2, _rect.Y + _rect.Height / 2));
                //        mGestureResult += i;
                //        break;
                //    }
                //}
                if (mTrackPointList.Count > 1)
                {
                    //if (mJoystickBtnId.ContainsKey(_gesture))
                    //{
                    //    _res = mJoystickHandler.SetBtn(mJoystickBtnState[btnId], mJoystickId, buttonInfo[0]);
                    //    System.Threading.Thread.Sleep(10);
                    //    _res = mJoystickHandler.SetBtn(mJoystickBtnState[btnId], mJoystickId, buttonInfo[0]);
                    //}
                }
                mCurrectTrackPoint.X = 0;
                mCurrectTrackPoint.Y = 0;

                mCurrentGestureRect = new RectangleF(0, 0, 0, 0);

                Console.WriteLine(mGestureResult);

                mGestureResult = "";
                mTrackPointList.Clear();
                CircleBtn.Refresh();
            }
        }
        #endregion

        RectangleF mTopLeft;
        RectangleF mTopCenter;
        RectangleF mTopRight;

        RectangleF mMiddleLeft;
        RectangleF mMiddleCenter;
        RectangleF mMiddleRight;

        RectangleF mBottomLeft;
        RectangleF mBottomCenter;
        RectangleF mBottomRight;

        List<RectangleF> mGestureRectList = new List<RectangleF>();
        List<PointF> mTrackPointList = new List<PointF>();
        PointF mCurrectTrackPoint;

        string mGestureResult = "";
        int mTrackLineWidth;
        SolidBrush mTrackBrush;
        Pen mTrackPen;
        RectangleF mCurrentGestureRect;

        private void CircleBtn_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //RectangleF[] rectGesture = mGestureRectList.ToArray();
            //foreach (RectangleF _rect in rectGesture)
            //{
            //    g.DrawRectangle(mTrackPen, _rect.X, _rect.Y, _rect.Width, _rect.Height);
            //}
            // Draw a line in the PictureBox.
            g.FillEllipse(mTrackBrush, mTopLeft);
            g.FillEllipse(mTrackBrush, mTopCenter);
            g.FillEllipse(mTrackBrush, mTopRight);

            g.FillEllipse(mTrackBrush, mMiddleLeft);
            g.FillEllipse(mTrackBrush, mMiddleCenter);
            g.FillEllipse(mTrackBrush, mMiddleRight);

            g.FillEllipse(mTrackBrush, mBottomLeft);
            g.FillEllipse(mTrackBrush, mBottomCenter);
            g.FillEllipse(mTrackBrush, mBottomRight);

            if (mTrackPointList.Count > 1)
            {
                g.DrawLines(mTrackPen, mTrackPointList.ToArray());
                if (mCurrectTrackPoint.X != 0 && mCurrectTrackPoint.Y != 0)
                    g.DrawLine(mTrackPen, mTrackPointList.Last(), mCurrectTrackPoint);
            }

        }
    }
}
