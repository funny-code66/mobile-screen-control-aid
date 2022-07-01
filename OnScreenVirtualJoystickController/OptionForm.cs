using System;
using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;


namespace OnScreenController
{
    public partial class OptionForm : Form
    {
        
        public bool mGlobalExcludeMouseEnable, mGlobalDisplayRunBtn;
        public string mGlobalGameProgramPath;

        public uint mCustomMouseSensitive = 1;

        private void GlobalDisplayRunChk_CheckedChanged(object sender, EventArgs e)
        {
            GameProgameFileBrowserBtn.Enabled = GlobalDisplayRunChk.Checked;
            GameProgramPathTxt.Enabled = GlobalDisplayRunChk.Checked;
        }

        private void MouseSensitiveTracker_Scroll(object sender, EventArgs e)
        {
            
        }

        private void MouseSensitiveTxt_TextChanged(object sender, EventArgs e)
        {
            int _value = Convert.ToInt32(Convert.ToDouble(CustomControllerMouseSensitiveTxt.Text) * 10);
            CustomControllerMouseSensitiveTracker.Value = _value;
        }

        private void MouseSensitiveTracker_ValueChanged(object sender, EventArgs e)
        {
            float _text = CustomControllerMouseSensitiveTracker.Value / 10.0f;
            CustomControllerMouseSensitiveTxt.Text = String.Format("{0}", _text);
        }

        private void GameProgameFileBrowserBtn_Click(object sender, EventArgs e)
        {
            GameProgramFileDialog.Title = "Select Game Program to Run";
            GameProgramFileDialog.CheckFileExists = true;
            GameProgramFileDialog.CheckPathExists = true;

            GameProgramFileDialog.RestoreDirectory = true;
            GameProgramFileDialog.ReadOnlyChecked = true;

            if (GameProgramFileDialog.ShowDialog() == DialogResult.OK)
            {
                GameProgramPathTxt.Text = GameProgramFileDialog.FileName;
            }
        }

        private void OptionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
            else
                base.OnFormClosing(e);
        }

        MainController mMainController;
        public OptionForm(MainController mainController)
        {
            InitializeComponent();

            Dictionary<string, int> _cmbData = new Dictionary<string, int>();
            _cmbData.Add("25%", 25);
            _cmbData.Add("50%", 50);
            _cmbData.Add("75%", 75);
            _cmbData.Add("100%", 100);
            _cmbData.Add("125%", 125);
            _cmbData.Add("150%", 150);
            _cmbData.Add("175%", 175);
            _cmbData.Add("200%", 200);

            mMainController = mainController;

        }
        
        private void OkBtn_Click(object sender, EventArgs e)
        {
            //if (GlobalExcludeMouseChk.Checked)
            //{
            //    mMouse = new Microsoft.DirectX.DirectInput.Device(SystemGuid.Mouse);
            //    mMouse.Properties.AxisModeAbsolute = true;
            //    mMouse.SetCooperativeLevel(this, CooperativeLevelFlags.Background | CooperativeLevelFlags.NonExclusive);
            //    mMouse.Acquire();
            //}

            mGlobalExcludeMouseEnable = GlobalExcludeMouseChk.Checked;
            mGlobalDisplayRunBtn = GlobalDisplayRunChk.Checked;
            if (mGlobalDisplayRunBtn)
                mGlobalGameProgramPath = GameProgramPathTxt.Text;

            mCustomMouseSensitive = (uint)CustomControllerMouseSensitiveTracker.Value;

            this.Hide();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
