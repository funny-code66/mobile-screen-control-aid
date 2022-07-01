using System;
using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OnScreenController
{
    public partial class VoiceJoystickCfgForm : Form
    {
        VoiceController mController;
        MainController mMain;

        Dictionary<string, uint[]> mVoiceToOutputMapping = new Dictionary<string, uint[]>();
        //Dictionary<string, string[]> mVoiceToOutputTempMapping;

        //Dictionary<uint, string> mComboToJoystickMapping = new Dictionary<uint, string>();

        //DataGridViewTextBoxColumn _column1;
        //DataGridViewComboBoxColumn _column2;
        //DataGridViewComboBoxColumn _column3;
        //DataGridViewComboBoxColumn _column4;

        public VoiceJoystickCfgForm(MainController main)
        {
            InitializeComponent();

            this.mMain = main;

            VoiceConfigGridView.ColumnCount = 4;
            VoiceConfigGridView.Columns[0].Name = "Command";
            VoiceConfigGridView.Columns[0].Width = 130;
            VoiceConfigGridView.Columns[1].Name = "Input";
            VoiceConfigGridView.Columns[1].Width = 70;
            VoiceConfigGridView.Columns[2].Name = "Option";
            VoiceConfigGridView.Columns[2].Width = 70;
            VoiceConfigGridView.Columns[3].Name = "Code";
            VoiceConfigGridView.Columns[3].Width = 100;

            loadConfigFromFile();
        }
        

        public void setController(VoiceController controller)
        {
            mController = controller;
        }

        public bool loadConfigFromFile()
        {

            if (!File.Exists("voice.list"))
            {
                saveConfigFromFile();

                return true;
            }
            mVoiceToOutputMapping.Clear();

            StreamReader _readfile = new StreamReader("voice.list");

            try
            {
                string line, _command;
                string[] _datas;

                DataGridViewRowCollection _rowColllection = VoiceConfigGridView.Rows;
                while ((line = _readfile.ReadLine()) != null)
                {
                    if (line.Trim(' ').Equals(""))
                        continue;
                    _command = line.Split('=')[0];
                    _datas = (line.Split('=')[1]).Split(',');

                    DataGridViewTextBoxCell _commandTextCell = new DataGridViewTextBoxCell();
                    _commandTextCell.Value = _command;

                    DataGridViewComboBoxCell _inputComboCell = new DataGridViewComboBoxCell();
                    _inputComboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                    _inputComboCell.DataSource = new BindingSource(mMain.InputMapping, null);
                    _inputComboCell.DisplayMember = "Name";
                    _inputComboCell.ValueMember = "Code";
                    _inputComboCell.Value = Convert.ToUInt32(_datas[0]);

                    DataGridViewComboBoxCell _optionComboCell = new DataGridViewComboBoxCell();
                    _optionComboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                    _optionComboCell.DataSource = new BindingSource(mMain.OptionMapping, null);
                    _optionComboCell.DisplayMember = "Name";
                    _optionComboCell.ValueMember = "Code";
                    _optionComboCell.Value = Convert.ToUInt32(_datas[1]);

                    DataGridViewComboBoxCell _codeComboCell = new DataGridViewComboBoxCell();
                    _codeComboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                    if (_datas[0].Equals("0"))
                    {
                        _codeComboCell.DataSource = new BindingSource(mMain.JoystickButtonMapping, null);
                        _codeComboCell.DisplayMember = "Name";
                        _codeComboCell.ValueMember = "Code";
                        _codeComboCell.Value = Convert.ToUInt32(_datas[2]);
                    }
                    else if (_datas[0].Equals("1"))
                    {
                        _codeComboCell.DataSource = new BindingSource(mMain.KeycodeMapping, null);
                        _codeComboCell.DisplayMember = "Name";
                        _codeComboCell.ValueMember = "Code";
                        _codeComboCell.Value = Convert.ToUInt32(_datas[2]);
                    }

                    DataGridViewRow _newRow = VoiceConfigGridView.Rows[VoiceConfigGridView.Rows.Add()];
                    _newRow.Cells[0] = _commandTextCell;
                    _newRow.Cells[1] = _inputComboCell;
                    _newRow.Cells[2] = _optionComboCell;
                    _newRow.Cells[3] = _codeComboCell;
                }

                //mVoiceToOutputTempMapping = new Dictionary<string, string[]>(mVoiceToOutputMapping);

                _readfile.Close();
            }
            catch
            {
                // MessageBox.Show("Grammar file reading failed.");
                _readfile.Close();
                return false;
            }
            return true;
        }

        public bool saveConfigFromFile()
        {
            StreamWriter _file = new StreamWriter("voice.list");

            try
            {
                foreach (KeyValuePair<string, uint[]> _row in mVoiceToOutputMapping)
                {                    
                    _file.WriteLine("{0}={1},{2},{3}", _row.Key, _row.Value[0].ToString(), _row.Value[1].ToString(), _row.Value[2].ToString());
                }

                _file.Close();
            }
            catch
            {
                _file.Close();
                return false;
            }
            return true;
        }
        #region DataGridView Operation
        private void VoiceConfigGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (VoiceConfigGridView.Columns["Command"].Index == e.ColumnIndex)
            {
            }
            else if (VoiceConfigGridView.Columns["Input"].Index == e.ColumnIndex)
            {
                string _input = VoiceConfigGridView.Rows[e.RowIndex].Cells[1].Value.ToString();

                DataGridViewComboBoxCell _codeComboCell = new DataGridViewComboBoxCell();
                _codeComboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                if (_input.Equals("0"))
                {
                    _codeComboCell.DataSource = new BindingSource(mMain.JoystickButtonMapping, null);
                    _codeComboCell.DisplayMember = "Name";
                    _codeComboCell.ValueMember = "Code";
                }
                else if (_input.Equals("1"))
                {
                    _codeComboCell.DataSource = new BindingSource(mMain.KeycodeMapping, null);
                    _codeComboCell.DisplayMember = "Name";
                    _codeComboCell.ValueMember = "Code";
                }
                VoiceConfigGridView.Rows[e.RowIndex].Cells["Code"] = _codeComboCell;
            }
            else if (VoiceConfigGridView.Columns["Option"].Index == e.ColumnIndex)
            {
            }
            else if (VoiceConfigGridView.Columns["Code"].Index == e.ColumnIndex)
            {
            }

        }

        delegate void ComboBoxCellType(int iRowIndex);
        bool bIsComboBox = false;
        private void VoiceConfigGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == VoiceConfigGridView.Columns["Input"].Index
                //|| e.ColumnIndex == VoiceConfigGridView.Columns["Option"].Index
                //|| e.ColumnIndex == VoiceConfigGridView.Columns["Code"].Index
                )
            {
                ComboBoxCellType objChangeCellType = new ComboBoxCellType(ChangeCellToComboBox);
                this.VoiceConfigGridView.BeginInvoke(objChangeCellType, e.RowIndex);
                bIsComboBox = false;
            }
                    
        }
        private void ChangeCellToComboBox(int iRowIndex)
        {
            if (bIsComboBox == false)
            {
                if (VoiceConfigGridView.Columns["Input"].Index == VoiceConfigGridView.CurrentCell.ColumnIndex)
                {
                    if (VoiceConfigGridView.Rows[iRowIndex].Cells[VoiceConfigGridView.CurrentCell.ColumnIndex].GetType().Name != "DataGridViewComboBoxCell")
                    {
                        DataGridViewComboBoxCell _inputComboCell = new DataGridViewComboBoxCell();
                        _inputComboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        _inputComboCell.DataSource = new BindingSource(mMain.InputMapping, null);
                        _inputComboCell.DisplayMember = "Name";
                        _inputComboCell.ValueMember = "Code";
                        //_inputComboCell.Value = Convert.ToUInt32(0);

                        DataGridViewComboBoxCell _optionComboCell = new DataGridViewComboBoxCell();
                        _optionComboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        _optionComboCell.DataSource = new BindingSource(mMain.OptionMapping, null);
                        _optionComboCell.DisplayMember = "Name";
                        _optionComboCell.ValueMember = "Code";
                        //_optionComboCell.Value = Convert.ToUInt32(0);

                        DataGridViewComboBoxCell _codeComboCell = new DataGridViewComboBoxCell();
                        _codeComboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        _codeComboCell.DataSource = new BindingSource(mMain.JoystickAxisMapping, null);
                        _codeComboCell.DisplayMember = "Name";
                        _codeComboCell.ValueMember = "Code";
                        //_codeComboCell.Value = Convert.ToUInt32(0);

                        VoiceConfigGridView.Rows[iRowIndex].Cells["Input"] = _inputComboCell;
                        VoiceConfigGridView.Rows[iRowIndex].Cells["Option"] = _optionComboCell;
                        VoiceConfigGridView.Rows[iRowIndex].Cells["Code"] = _codeComboCell;
                    }
                }
                else if (VoiceConfigGridView.Columns["Option"].Index == VoiceConfigGridView.CurrentCell.ColumnIndex)
                {
                        
                }
                else if (VoiceConfigGridView.Columns["Code"].Index == VoiceConfigGridView.CurrentCell.ColumnIndex)
                {

                }
                bIsComboBox = true;
            }
        }
        #endregion

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            mVoiceToOutputMapping.Clear();
            foreach(DataGridViewRow _row in VoiceConfigGridView.Rows)
            {
                if (_row.IsNewRow) continue;
                string _command = _row.Cells[0].Value.ToString();
                uint _input = Convert.ToUInt32(_row.Cells[1].Value);
                uint _option = Convert.ToUInt32(_row.Cells[2].Value);
                uint _code = Convert.ToUInt32(_row.Cells[3].Value);
                mVoiceToOutputMapping.Add(_command, new uint[] { _input, _option, _code });
            }
            setConfigToButtons();
            saveConfigFromFile();
            this.Hide();
        }

        public bool setConfigToButtons()
        {
            mController.setJoystickBtnId(mVoiceToOutputMapping);
            return true;
        }
    }
}
