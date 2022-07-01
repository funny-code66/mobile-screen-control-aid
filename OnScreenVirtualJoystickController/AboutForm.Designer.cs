
namespace OnScreenController
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonBtn = new ShapeControl.CustomControl1();
            this.OkBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::OnScreenController.Properties.Resources.editbox_move;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(15, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 35);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ravie", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(408, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "Onscreen Controller 1.0.0";
            // 
            // ButtonBtn
            // 
            this.ButtonBtn.AnimateBorder = false;
            this.ButtonBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.ButtonBtn.Blink = false;
            this.ButtonBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ButtonBtn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.ButtonBtn.BorderWidth = 0;
            this.ButtonBtn.CenterColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ButtonBtn.Connector = ShapeControl.ConnecterType.Center;
            this.ButtonBtn.Direction = ShapeControl.LineDirection.None;
            this.ButtonBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.ButtonBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ButtonBtn.Location = new System.Drawing.Point(12, 55);
            this.ButtonBtn.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonBtn.Name = "ButtonBtn";
            this.ButtonBtn.Shape = ShapeControl.ShapeType.LineHorizontal;
            this.ButtonBtn.ShapeImage = null;
            this.ButtonBtn.ShapeImageRotation = 0;
            this.ButtonBtn.ShapeImageTexture = null;
            this.ButtonBtn.ShapeStorageLoadFile = "";
            this.ButtonBtn.ShapeStorageSaveFile = "";
            this.ButtonBtn.Size = new System.Drawing.Size(446, 20);
            this.ButtonBtn.SurroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ButtonBtn.TabIndex = 2;
            this.ButtonBtn.Tag2 = "";
            this.ButtonBtn.UseGradient = false;
            this.ButtonBtn.Vibrate = false;
            // 
            // OkBtn
            // 
            this.OkBtn.Location = new System.Drawing.Point(364, 212);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(94, 26);
            this.OkBtn.TabIndex = 3;
            this.OkBtn.Text = "OK";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(12, 78);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(446, 128);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // AboutForm
            // 
            this.AcceptButton = this.OkBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 250);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.ButtonBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.Text = "About Onscreen Controller";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private ShapeControl.CustomControl1 ButtonBtn;
        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.TextBox textBox1;
    }
}