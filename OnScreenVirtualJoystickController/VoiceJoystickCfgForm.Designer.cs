namespace OnScreenController
{
    partial class VoiceJoystickCfgForm
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
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OkBtn = new System.Windows.Forms.Button();
            this.VoiceConfigGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.VoiceConfigGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(240, 424);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 5;
            this.CancelBtn.Text = "&Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // OkBtn
            // 
            this.OkBtn.Location = new System.Drawing.Point(339, 424);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(75, 23);
            this.OkBtn.TabIndex = 6;
            this.OkBtn.Text = "&Ok";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // VoiceConfigGridView
            // 
            this.VoiceConfigGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.VoiceConfigGridView.Location = new System.Drawing.Point(9, 12);
            this.VoiceConfigGridView.MultiSelect = false;
            this.VoiceConfigGridView.Name = "VoiceConfigGridView";
            this.VoiceConfigGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.VoiceConfigGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.VoiceConfigGridView.Size = new System.Drawing.Size(413, 406);
            this.VoiceConfigGridView.TabIndex = 7;
            this.VoiceConfigGridView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.VoiceConfigGridView_CellEnter);
            this.VoiceConfigGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.VoiceConfigGridView_CellValueChanged);
            
            // 
            // VoiceJoystickCfgForm
            // 
            this.AcceptButton = this.OkBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(432, 452);
            this.Controls.Add(this.VoiceConfigGridView);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.CancelBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "VoiceJoystickCfgForm";
            this.Text = "Config Voice Joystick";
            ((System.ComponentModel.ISupportInitialize)(this.VoiceConfigGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.DataGridView VoiceConfigGridView;
    }
}