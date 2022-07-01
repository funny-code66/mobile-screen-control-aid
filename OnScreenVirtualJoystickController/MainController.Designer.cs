using System;
using System.Collections.Generic;
using System.Windows.Forms;
using vJoyInterfaceWrap;
using System.Management;
using System.Drawing;
using System.ComponentModel;
using System.IO;
using System.Xml;

namespace OnScreenController
{
    partial class MainController
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainController));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.customToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controllersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createEditToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.voiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defineToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.turnOnOffToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.defineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.turnOnoffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.controllersToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.createEditToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.defineToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.turnOnOffToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllControllerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutControllerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sssToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VoiceControllerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editControllerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadControllerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customToolStripMenuItem,
            this.voiceToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(362, 24);
            this.MainMenu.TabIndex = 10;
            this.MainMenu.Text = "menuStrip1";
            // 
            // customToolStripMenuItem
            // 
            this.customToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controllersToolStripMenuItem,
            this.createEditToolStripMenuItem1,
            this.reloadToolStripMenuItem});
            this.customToolStripMenuItem.Name = "customToolStripMenuItem";
            this.customToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.customToolStripMenuItem.Text = "Touch";
            // 
            // controllersToolStripMenuItem
            // 
            this.controllersToolStripMenuItem.Name = "controllersToolStripMenuItem";
            this.controllersToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.controllersToolStripMenuItem.Text = "Controllers";
            // 
            // createEditToolStripMenuItem1
            // 
            this.createEditToolStripMenuItem1.Name = "createEditToolStripMenuItem1";
            this.createEditToolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
            this.createEditToolStripMenuItem1.Text = "Create/Edit";
            this.createEditToolStripMenuItem1.Click += new System.EventHandler(this.editControllerToolStripMenuItem_Click);
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.reloadToolStripMenuItem.Text = "Reload";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.reloadControllerToolStripMenuItem_Click);
            // 
            // voiceToolStripMenuItem
            // 
            this.voiceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sourceToolStripMenuItem,
            this.defineToolStripMenuItem1,
            this.turnOnOffToolStripMenuItem1});
            this.voiceToolStripMenuItem.Name = "voiceToolStripMenuItem";
            this.voiceToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.voiceToolStripMenuItem.Text = "Voice";
            // 
            // sourceToolStripMenuItem
            // 
            this.sourceToolStripMenuItem.Name = "sourceToolStripMenuItem";
            this.sourceToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.sourceToolStripMenuItem.Text = "Source";
            // 
            // defineToolStripMenuItem1
            // 
            this.defineToolStripMenuItem1.Name = "defineToolStripMenuItem1";
            this.defineToolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
            this.defineToolStripMenuItem1.Text = "Define";
            this.defineToolStripMenuItem1.Click += new System.EventHandler(this.VoiceJoyStickToolStripMenuItem_Click);
            // 
            // turnOnOffToolStripMenuItem1
            // 
            this.turnOnOffToolStripMenuItem1.Name = "turnOnOffToolStripMenuItem1";
            this.turnOnOffToolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
            this.turnOnOffToolStripMenuItem1.Text = "Turn On/Off";
            this.turnOnOffToolStripMenuItem1.Click += new System.EventHandler(this.voiceControllerToolStripMenuItem_Click);
            // 
            // defineToolStripMenuItem
            // 
            this.defineToolStripMenuItem.Name = "defineToolStripMenuItem";
            this.defineToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // turnOnoffToolStripMenuItem
            // 
            this.turnOnoffToolStripMenuItem.Name = "turnOnoffToolStripMenuItem";
            this.turnOnoffToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // createEditToolStripMenuItem
            // 
            this.createEditToolStripMenuItem.Name = "createEditToolStripMenuItem";
            this.createEditToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Onscreen Controller with Voice Command.";
            this.notifyIcon1.BalloonTipTitle = "Onscreen Controller";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Onscreen Controller";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.closeAllControllerToolStripMenuItem,
            this.aboutControllerToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 114);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controllersToolStripMenuItem1,
            this.createEditToolStripMenuItem2,
            this.reloadToolStripMenuItem1});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.toolStripMenuItem1.Text = "&Touch";
            // 
            // controllersToolStripMenuItem1
            // 
            this.controllersToolStripMenuItem1.Name = "controllersToolStripMenuItem1";
            this.controllersToolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
            this.controllersToolStripMenuItem1.Text = "&Controllers";
            // 
            // createEditToolStripMenuItem2
            // 
            this.createEditToolStripMenuItem2.Name = "createEditToolStripMenuItem2";
            this.createEditToolStripMenuItem2.Size = new System.Drawing.Size(133, 22);
            this.createEditToolStripMenuItem2.Text = "Create/&Edit";
            this.createEditToolStripMenuItem2.Click += new System.EventHandler(this.editControllerToolStripMenuItem_Click);
            // 
            // reloadToolStripMenuItem1
            // 
            this.reloadToolStripMenuItem1.Name = "reloadToolStripMenuItem1";
            this.reloadToolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
            this.reloadToolStripMenuItem1.Text = "&Reload";
            this.reloadToolStripMenuItem1.Click += new System.EventHandler(this.reloadControllerToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sourceToolStripMenuItem1,
            this.defineToolStripMenuItem2,
            this.turnOnOffToolStripMenuItem2});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(107, 22);
            this.toolStripMenuItem2.Text = "&Voice";
            // 
            // sourceToolStripMenuItem1
            // 
            this.sourceToolStripMenuItem1.Name = "sourceToolStripMenuItem1";
            this.sourceToolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
            this.sourceToolStripMenuItem1.Text = "&Source";
            // 
            // defineToolStripMenuItem2
            // 
            this.defineToolStripMenuItem2.Name = "defineToolStripMenuItem2";
            this.defineToolStripMenuItem2.Size = new System.Drawing.Size(139, 22);
            this.defineToolStripMenuItem2.Text = "&Define";
            this.defineToolStripMenuItem2.Click += new System.EventHandler(this.VoiceJoyStickToolStripMenuItem_Click);
            // 
            // turnOnOffToolStripMenuItem2
            // 
            this.turnOnOffToolStripMenuItem2.Name = "turnOnOffToolStripMenuItem2";
            this.turnOnOffToolStripMenuItem2.Size = new System.Drawing.Size(139, 22);
            this.turnOnOffToolStripMenuItem2.Text = "&Turn On/Off";
            // 
            // closeAllControllerToolStripMenuItem
            // 
            this.closeAllControllerToolStripMenuItem.Name = "closeAllControllerToolStripMenuItem";
            this.closeAllControllerToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.closeAllControllerToolStripMenuItem.Text = "&Close";
            this.closeAllControllerToolStripMenuItem.Click += new System.EventHandler(this.closeAllControllerToolStripMenuItem_Click);
            // 
            // aboutControllerToolStripMenuItem
            // 
            this.aboutControllerToolStripMenuItem.Name = "aboutControllerToolStripMenuItem";
            this.aboutControllerToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutControllerToolStripMenuItem.Text = "&About";
            this.aboutControllerToolStripMenuItem.Click += new System.EventHandler(this.aboutControllerToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // sssToolStripMenuItem
            // 
            this.sssToolStripMenuItem.Name = "sssToolStripMenuItem";
            this.sssToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // VoiceControllerToolStripMenuItem
            // 
            this.VoiceControllerToolStripMenuItem.Name = "VoiceControllerToolStripMenuItem";
            this.VoiceControllerToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // editControllerToolStripMenuItem
            // 
            this.editControllerToolStripMenuItem.Name = "editControllerToolStripMenuItem";
            this.editControllerToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // reloadControllerToolStripMenuItem
            // 
            this.reloadControllerToolStripMenuItem.Name = "reloadControllerToolStripMenuItem";
            this.reloadControllerToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // MainController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(362, 49);
            this.Controls.Add(this.MainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainController";
            this.Text = "Onscreen Controller with Voice Commands";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        /*pooh*/
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        //private System.Windows.Forms.ToolStripMenuItem voiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem turnOnoffToolStripMenuItem;
       // private System.Windows.Forms.ToolStripMenuItem customToolStripMenuItem;
//        private System.Windows.Forms.ToolStripMenuItem controllerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem createEditToolStripMenuItem;
      //  private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sssToolStripMenuItem;
        private ToolStripMenuItem VoiceControllerToolStripMenuItem;
        private ToolStripMenuItem editControllerToolStripMenuItem;
        private ToolStripMenuItem reloadControllerToolStripMenuItem;
        private ToolStripMenuItem voiceToolStripMenuItem;
        private ToolStripMenuItem sourceToolStripMenuItem;
        private ToolStripMenuItem defineToolStripMenuItem1;
        private ToolStripMenuItem turnOnOffToolStripMenuItem1;
        private ToolStripMenuItem customToolStripMenuItem;
        private ToolStripMenuItem controllersToolStripMenuItem;
        private ToolStripMenuItem createEditToolStripMenuItem1;
        private ToolStripMenuItem reloadToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem sourceToolStripMenuItem1;
        private ToolStripMenuItem defineToolStripMenuItem2;
        private ToolStripMenuItem turnOnOffToolStripMenuItem2;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem closeAllControllerToolStripMenuItem;
        private ToolStripMenuItem aboutControllerToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem controllersToolStripMenuItem1;
        private ToolStripMenuItem createEditToolStripMenuItem2;
        private ToolStripMenuItem reloadToolStripMenuItem1;
        //private ToolStripMenuItem ToolsToolStripMenuItem;
        //private ToolStripMenuItem CustomControllerStripMenuItem;
    }
}

