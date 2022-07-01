//using System;
//using System.Collections;
//using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
//using System.Linq;
//using System.Threading;
using System.Diagnostics;

namespace OnScreenController
{
    [RunInstaller(true)]
    public partial class ControllerInstaller : System.Configuration.Install.Installer
    {
        public ControllerInstaller()
        {
            InitializeComponent();
        }

        private void ControllerInstaller_AfterInstall(object sender, InstallEventArgs e)
        {
            Process _installer = new Process();
            _installer.StartInfo.FileName = "vJoyInstall.exe";
            _installer.StartInfo.Arguments = "I";
            _installer.Start();
            _installer.WaitForExit();
        }

        private void ControllerInstaller_BeforeUninstall(object sender, InstallEventArgs e)
        {
            Process _application = null;

            foreach (var _process in Process.GetProcesses())
            {
                if (!_process.ProcessName.ToLower().Contains("onscreencontroller")) continue;
                _application = _process;
                break;
            }

            if (_application != null && _application.Responding)
            {
                _application.Kill();
            }

            Process _installer = new Process();
            _installer.StartInfo.FileName = "vJoyInstall.exe";
            _installer.StartInfo.Arguments = "U";
            _installer.Start();
            _installer.WaitForExit();
        }
    }
}
