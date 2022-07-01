namespace OnScreenController
{
    partial class MinimizeButtonForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MinimizeBtn = new ShapeControl.CustomControl1();
            this.ResizeMiddleLeft = new System.Windows.Forms.Panel();
            this.ResizeBottomLeft = new System.Windows.Forms.Panel();
            this.ResizeBottomCenter = new System.Windows.Forms.Panel();
            this.ResizeBottomRight = new System.Windows.Forms.Panel();
            this.ResizeMiddleRight = new System.Windows.Forms.Panel();
            this.ResizeTopRight = new System.Windows.Forms.Panel();
            this.ResizeTopCenter = new System.Windows.Forms.Panel();
            this.ResizeTopLeft = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // MinimizeBtn
            // 
            this.MinimizeBtn.AnimateBorder = false;
            this.MinimizeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.MinimizeBtn.Blink = false;
            this.MinimizeBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(202)))));
            this.MinimizeBtn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.MinimizeBtn.BorderWidth = 3;
            this.MinimizeBtn.CenterColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.MinimizeBtn.Connector = ShapeControl.ConnecterType.Center;
            this.MinimizeBtn.Direction = ShapeControl.LineDirection.None;
            this.MinimizeBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.MinimizeBtn.Location = new System.Drawing.Point(10, 10);
            this.MinimizeBtn.Name = "MinimizeBtn";
            this.MinimizeBtn.Shape = ShapeControl.ShapeType.Ellipse;
            this.MinimizeBtn.ShapeImage = null;
            this.MinimizeBtn.ShapeImageRotation = 0;
            this.MinimizeBtn.ShapeImageTexture = null;
            this.MinimizeBtn.ShapeStorageLoadFile = "";
            this.MinimizeBtn.ShapeStorageSaveFile = "";
            this.MinimizeBtn.Size = new System.Drawing.Size(350, 350);
            this.MinimizeBtn.SurroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.MinimizeBtn.TabIndex = 0;
            this.MinimizeBtn.Tag2 = "";
            this.MinimizeBtn.UseGradient = false;
            this.MinimizeBtn.Vibrate = false;
            this.MinimizeBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MinimizeBtn_MouseClick);
            this.MinimizeBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MinimizeBtn_MouseDown);
            this.MinimizeBtn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MinimizeBtn_MouseMove);
            this.MinimizeBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MinimizeBtn_MouseUp);
            // 
            // ResizeMiddleLeft
            // 
            this.ResizeMiddleLeft.BackColor = System.Drawing.Color.Black;
            this.ResizeMiddleLeft.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.ResizeMiddleLeft.Location = new System.Drawing.Point(0, 180);
            this.ResizeMiddleLeft.Margin = new System.Windows.Forms.Padding(0);
            this.ResizeMiddleLeft.Name = "ResizeMiddleLeft";
            this.ResizeMiddleLeft.Size = new System.Drawing.Size(10, 10);
            this.ResizeMiddleLeft.TabIndex = 3;
            this.ResizeMiddleLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseDown);
            this.ResizeMiddleLeft.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseMove);
            this.ResizeMiddleLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseUp);
            // 
            // ResizeBottomLeft
            // 
            this.ResizeBottomLeft.BackColor = System.Drawing.Color.Black;
            this.ResizeBottomLeft.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.ResizeBottomLeft.Location = new System.Drawing.Point(0, 360);
            this.ResizeBottomLeft.Margin = new System.Windows.Forms.Padding(0);
            this.ResizeBottomLeft.Name = "ResizeBottomLeft";
            this.ResizeBottomLeft.Size = new System.Drawing.Size(10, 10);
            this.ResizeBottomLeft.TabIndex = 4;
            this.ResizeBottomLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseDown);
            this.ResizeBottomLeft.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseMove);
            this.ResizeBottomLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseUp);
            // 
            // ResizeBottomCenter
            // 
            this.ResizeBottomCenter.BackColor = System.Drawing.Color.Black;
            this.ResizeBottomCenter.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.ResizeBottomCenter.Location = new System.Drawing.Point(180, 360);
            this.ResizeBottomCenter.Margin = new System.Windows.Forms.Padding(0);
            this.ResizeBottomCenter.Name = "ResizeBottomCenter";
            this.ResizeBottomCenter.Size = new System.Drawing.Size(10, 10);
            this.ResizeBottomCenter.TabIndex = 5;
            this.ResizeBottomCenter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseDown);
            this.ResizeBottomCenter.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseMove);
            this.ResizeBottomCenter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseUp);
            // 
            // ResizeBottomRight
            // 
            this.ResizeBottomRight.BackColor = System.Drawing.Color.Black;
            this.ResizeBottomRight.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.ResizeBottomRight.Location = new System.Drawing.Point(360, 360);
            this.ResizeBottomRight.Margin = new System.Windows.Forms.Padding(0);
            this.ResizeBottomRight.Name = "ResizeBottomRight";
            this.ResizeBottomRight.Size = new System.Drawing.Size(10, 10);
            this.ResizeBottomRight.TabIndex = 6;
            this.ResizeBottomRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseDown);
            this.ResizeBottomRight.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseMove);
            this.ResizeBottomRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseUp);
            // 
            // ResizeMiddleRight
            // 
            this.ResizeMiddleRight.BackColor = System.Drawing.Color.Black;
            this.ResizeMiddleRight.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.ResizeMiddleRight.Location = new System.Drawing.Point(360, 180);
            this.ResizeMiddleRight.Margin = new System.Windows.Forms.Padding(0);
            this.ResizeMiddleRight.Name = "ResizeMiddleRight";
            this.ResizeMiddleRight.Size = new System.Drawing.Size(10, 10);
            this.ResizeMiddleRight.TabIndex = 7;
            this.ResizeMiddleRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseDown);
            this.ResizeMiddleRight.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseMove);
            this.ResizeMiddleRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseUp);
            // 
            // ResizeTopRight
            // 
            this.ResizeTopRight.BackColor = System.Drawing.Color.Black;
            this.ResizeTopRight.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.ResizeTopRight.Location = new System.Drawing.Point(360, 0);
            this.ResizeTopRight.Margin = new System.Windows.Forms.Padding(0);
            this.ResizeTopRight.Name = "ResizeTopRight";
            this.ResizeTopRight.Size = new System.Drawing.Size(10, 10);
            this.ResizeTopRight.TabIndex = 8;
            this.ResizeTopRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseDown);
            this.ResizeTopRight.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseMove);
            this.ResizeTopRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseUp);
            // 
            // ResizeTopCenter
            // 
            this.ResizeTopCenter.BackColor = System.Drawing.Color.Black;
            this.ResizeTopCenter.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.ResizeTopCenter.Location = new System.Drawing.Point(180, 0);
            this.ResizeTopCenter.Margin = new System.Windows.Forms.Padding(0);
            this.ResizeTopCenter.Name = "ResizeTopCenter";
            this.ResizeTopCenter.Size = new System.Drawing.Size(10, 10);
            this.ResizeTopCenter.TabIndex = 9;
            this.ResizeTopCenter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseDown);
            this.ResizeTopCenter.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseMove);
            this.ResizeTopCenter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseUp);
            // 
            // ResizeTopLeft
            // 
            this.ResizeTopLeft.BackColor = System.Drawing.Color.Black;
            this.ResizeTopLeft.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.ResizeTopLeft.Location = new System.Drawing.Point(0, 0);
            this.ResizeTopLeft.Margin = new System.Windows.Forms.Padding(0);
            this.ResizeTopLeft.Name = "ResizeTopLeft";
            this.ResizeTopLeft.Size = new System.Drawing.Size(10, 10);
            this.ResizeTopLeft.TabIndex = 10;
            this.ResizeTopLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseDown);
            this.ResizeTopLeft.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseMove);
            this.ResizeTopLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseUp);
            // 
            // MinimizeButtonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(370, 370);
            this.Controls.Add(this.ResizeMiddleLeft);
            this.Controls.Add(this.ResizeBottomLeft);
            this.Controls.Add(this.ResizeBottomCenter);
            this.Controls.Add(this.ResizeBottomRight);
            this.Controls.Add(this.ResizeMiddleRight);
            this.Controls.Add(this.ResizeTopRight);
            this.Controls.Add(this.ResizeTopCenter);
            this.Controls.Add(this.ResizeTopLeft);
            this.Controls.Add(this.MinimizeBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MinimizeButtonForm";
            this.Text = "MinimizeButtonForm";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Activated += new System.EventHandler(this.MinimizeButtonForm_Activated);
            this.Deactivate += new System.EventHandler(this.MinimizeButtonForm_Deactivate);
            this.ResumeLayout(false);

        }

        #endregion

        private ShapeControl.CustomControl1 MinimizeBtn;
        private System.Windows.Forms.Panel ResizeMiddleLeft;
        private System.Windows.Forms.Panel ResizeBottomLeft;
        private System.Windows.Forms.Panel ResizeBottomCenter;
        private System.Windows.Forms.Panel ResizeBottomRight;
        private System.Windows.Forms.Panel ResizeMiddleRight;
        private System.Windows.Forms.Panel ResizeTopRight;
        private System.Windows.Forms.Panel ResizeTopCenter;
        private System.Windows.Forms.Panel ResizeTopLeft;
    }
}