namespace OnScreenController
{
    partial class OptionForm
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
            this.GameProgramFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.GlobalExcludeMouseChk = new System.Windows.Forms.CheckBox();
            this.GlobalDisplayRunChk = new System.Windows.Forms.CheckBox();
            this.GameProgramPathTxt = new System.Windows.Forms.TextBox();
            this.GameProgameFileBrowserBtn = new System.Windows.Forms.Button();
            this.CustomControllerMouseSensitiveTracker = new System.Windows.Forms.TrackBar();
            this.CustomControllerMouseSensitiveTxt = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.NormalControllerMouseMoveChk = new System.Windows.Forms.CheckBox();
            this.NormalControllerFollowMouseChk = new System.Windows.Forms.CheckBox();
            this.NormalControllerFollowMouseDelayChk = new System.Windows.Forms.CheckBox();
            this.NormalControllerShowBorderChk = new System.Windows.Forms.CheckBox();
            this.NormalControllerFixedMouseChk = new System.Windows.Forms.CheckBox();
            this.NormalControllerMouseButtonCmb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NormalControllerRatioResizeCmb = new System.Windows.Forms.ComboBox();
            this.NormalControllerCustomSizeChk = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.NormalControllerRatioNumUD = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.NormalControllerOpacityTBar = new System.Windows.Forms.TrackBar();
            this.label10 = new System.Windows.Forms.Label();
            this.NormalControllerOpacityTxt = new System.Windows.Forms.TextBox();
            this.NormalDisplayMimumChk = new System.Windows.Forms.CheckBox();
            this.NormalThumbSensitiveTBar = new System.Windows.Forms.TrackBar();
            this.NormalControllerThumbChk = new System.Windows.Forms.CheckBox();
            this.label21 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.tab = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.CustomControllerMouseSensitiveTracker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NormalControllerRatioNumUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NormalControllerOpacityTBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NormalThumbSensitiveTBar)).BeginInit();
            this.tabPage6.SuspendLayout();
            this.tab.SuspendLayout();
            this.SuspendLayout();
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(268, 510);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 1;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // OkBtn
            // 
            this.OkBtn.Location = new System.Drawing.Point(362, 510);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(75, 23);
            this.OkBtn.TabIndex = 1;
            this.OkBtn.Text = "Ok";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // GameProgramFileDialog
            // 
            this.GameProgramFileDialog.FileName = "openFileDialog1";
            // 
            // GlobalExcludeMouseChk
            // 
            this.GlobalExcludeMouseChk.AutoSize = true;
            this.GlobalExcludeMouseChk.Location = new System.Drawing.Point(18, 19);
            this.GlobalExcludeMouseChk.Name = "GlobalExcludeMouseChk";
            this.GlobalExcludeMouseChk.Size = new System.Drawing.Size(142, 17);
            this.GlobalExcludeMouseChk.TabIndex = 0;
            this.GlobalExcludeMouseChk.Text = "Enable excluded mouse.";
            this.GlobalExcludeMouseChk.UseVisualStyleBackColor = true;
            // 
            // GlobalDisplayRunChk
            // 
            this.GlobalDisplayRunChk.AutoSize = true;
            this.GlobalDisplayRunChk.Location = new System.Drawing.Point(18, 44);
            this.GlobalDisplayRunChk.Name = "GlobalDisplayRunChk";
            this.GlobalDisplayRunChk.Size = new System.Drawing.Size(115, 17);
            this.GlobalDisplayRunChk.TabIndex = 1;
            this.GlobalDisplayRunChk.Text = "Dispay Run Button";
            this.GlobalDisplayRunChk.UseVisualStyleBackColor = true;
            this.GlobalDisplayRunChk.CheckedChanged += new System.EventHandler(this.GlobalDisplayRunChk_CheckedChanged);
            // 
            // GameProgramPathTxt
            // 
            this.GameProgramPathTxt.Enabled = false;
            this.GameProgramPathTxt.Location = new System.Drawing.Point(38, 65);
            this.GameProgramPathTxt.Name = "GameProgramPathTxt";
            this.GameProgramPathTxt.Size = new System.Drawing.Size(358, 20);
            this.GameProgramPathTxt.TabIndex = 2;
            // 
            // GameProgameFileBrowserBtn
            // 
            this.GameProgameFileBrowserBtn.Enabled = false;
            this.GameProgameFileBrowserBtn.Location = new System.Drawing.Point(396, 64);
            this.GameProgameFileBrowserBtn.Name = "GameProgameFileBrowserBtn";
            this.GameProgameFileBrowserBtn.Size = new System.Drawing.Size(24, 23);
            this.GameProgameFileBrowserBtn.TabIndex = 3;
            this.GameProgameFileBrowserBtn.Text = "...";
            this.GameProgameFileBrowserBtn.UseVisualStyleBackColor = true;
            this.GameProgameFileBrowserBtn.Click += new System.EventHandler(this.GameProgameFileBrowserBtn_Click);
            // 
            // CustomControllerMouseSensitiveTracker
            // 
            this.CustomControllerMouseSensitiveTracker.BackColor = System.Drawing.Color.White;
            this.CustomControllerMouseSensitiveTracker.Location = new System.Drawing.Point(101, 19);
            this.CustomControllerMouseSensitiveTracker.Maximum = 100;
            this.CustomControllerMouseSensitiveTracker.Minimum = 1;
            this.CustomControllerMouseSensitiveTracker.Name = "CustomControllerMouseSensitiveTracker";
            this.CustomControllerMouseSensitiveTracker.Size = new System.Drawing.Size(282, 45);
            this.CustomControllerMouseSensitiveTracker.TabIndex = 0;
            this.CustomControllerMouseSensitiveTracker.TickStyle = System.Windows.Forms.TickStyle.None;
            this.CustomControllerMouseSensitiveTracker.Value = 1;
            this.CustomControllerMouseSensitiveTracker.Scroll += new System.EventHandler(this.MouseSensitiveTracker_Scroll);
            this.CustomControllerMouseSensitiveTracker.ValueChanged += new System.EventHandler(this.MouseSensitiveTracker_ValueChanged);
            // 
            // CustomControllerMouseSensitiveTxt
            // 
            this.CustomControllerMouseSensitiveTxt.Location = new System.Drawing.Point(385, 19);
            this.CustomControllerMouseSensitiveTxt.Name = "CustomControllerMouseSensitiveTxt";
            this.CustomControllerMouseSensitiveTxt.Size = new System.Drawing.Size(32, 20);
            this.CustomControllerMouseSensitiveTxt.TabIndex = 1;
            this.CustomControllerMouseSensitiveTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CustomControllerMouseSensitiveTxt.TextChanged += new System.EventHandler(this.MouseSensitiveTxt_TextChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 22);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(89, 13);
            this.label22.TabIndex = 2;
            
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(300, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 12;
            // 
            // NormalControllerRatioNumUD
            // 
            this.NormalControllerRatioNumUD.Enabled = false;
            this.NormalControllerRatioNumUD.Location = new System.Drawing.Point(165, 73);
            this.NormalControllerRatioNumUD.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.NormalControllerRatioNumUD.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.NormalControllerRatioNumUD.Name = "NormalControllerRatioNumUD";
            this.NormalControllerRatioNumUD.Size = new System.Drawing.Size(100, 20);
            this.NormalControllerRatioNumUD.TabIndex = 15;
            this.NormalControllerRatioNumUD.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 0;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(162, 20);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(50, 13);
            this.label21.TabIndex = 11;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.groupBox21);
            this.tabPage6.Controls.Add(this.groupBox16);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(440, 466);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Global";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // groupBox16
            // 
            this.groupBox16.Location = new System.Drawing.Point(4, 4);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(433, 107);
            this.groupBox16.TabIndex = 0;
            this.groupBox16.TabStop = false;
            // 
            // groupBox21
            // 
            this.groupBox21.Location = new System.Drawing.Point(4, 117);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(433, 70);
            this.groupBox21.TabIndex = 0;
            this.groupBox21.TabStop = false;
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabPage6);
            this.tab.Location = new System.Drawing.Point(12, 12);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(448, 492);
            this.tab.TabIndex = 0;
            // 
            // OptionForm
            // 
            this.AcceptButton = this.OkBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(475, 545);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.tab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OptionForm";
            this.Text = "Option";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.CustomControllerMouseSensitiveTracker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NormalControllerRatioNumUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NormalControllerOpacityTBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NormalThumbSensitiveTBar)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.tab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.OpenFileDialog GameProgramFileDialog;
        private System.Windows.Forms.CheckBox GlobalExcludeMouseChk;
        private System.Windows.Forms.CheckBox GlobalDisplayRunChk;
        private System.Windows.Forms.TextBox GameProgramPathTxt;
        private System.Windows.Forms.Button GameProgameFileBrowserBtn;
        private System.Windows.Forms.TrackBar CustomControllerMouseSensitiveTracker;
        private System.Windows.Forms.TextBox CustomControllerMouseSensitiveTxt;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.CheckBox NormalControllerMouseMoveChk;
        private System.Windows.Forms.CheckBox NormalControllerFollowMouseChk;
        private System.Windows.Forms.CheckBox NormalControllerFollowMouseDelayChk;
        private System.Windows.Forms.CheckBox NormalControllerShowBorderChk;
        private System.Windows.Forms.CheckBox NormalControllerFixedMouseChk;
        private System.Windows.Forms.ComboBox NormalControllerMouseButtonCmb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox NormalControllerRatioResizeCmb;
        private System.Windows.Forms.CheckBox NormalControllerCustomSizeChk;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown NormalControllerRatioNumUD;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TrackBar NormalControllerOpacityTBar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox NormalControllerOpacityTxt;
        private System.Windows.Forms.CheckBox NormalDisplayMimumChk;
        private System.Windows.Forms.TrackBar NormalThumbSensitiveTBar;
        private System.Windows.Forms.CheckBox NormalControllerThumbChk;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.TabControl tab;
    }
}