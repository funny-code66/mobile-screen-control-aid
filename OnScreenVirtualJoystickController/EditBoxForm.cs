using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;


namespace OnScreenController
{
    public partial class EditBoxForm : Form
    {
        List<Form> mComponentList = new List<Form>();
        Form mMinButton = null;
        Form mCurrentComponent = null;
        int mCurrentController = -1;
        TOOLTYPE mCurrentTool;
        MainController mMain;

        enum TOOLTYPE
        {
            BUTTON,
            MOVE,
            DIRECTION,
            TOUCH,
            MINBUTTON
        }

        //Dictionary<string, uint> mComboToJoystickButtonMapping;
        //Dictionary<string, uint> mComboToJoystickAxisMapping;

        public EditBoxForm(MainController main)
        {
            InitializeComponent();
            ButtonXNum.Maximum = Screen.PrimaryScreen.WorkingArea.Width;
            ButtonYNum.Maximum = Screen.PrimaryScreen.WorkingArea.Height;
            ButtonWidthNum.Maximum = Screen.PrimaryScreen.WorkingArea.Width;
            ButtonHeightNum.Maximum = Screen.PrimaryScreen.WorkingArea.Height;

            MoveXNum.Maximum = Screen.PrimaryScreen.WorkingArea.Width;
            MoveYNum.Maximum = Screen.PrimaryScreen.WorkingArea.Height;
            MoveWidthNum.Maximum = Screen.PrimaryScreen.WorkingArea.Width;
            MoveHeightNum.Maximum = Screen.PrimaryScreen.WorkingArea.Height;

            DirectionXNum.Maximum = Screen.PrimaryScreen.WorkingArea.Width;
            DirectionYNum.Maximum = Screen.PrimaryScreen.WorkingArea.Height;
            DirectionWidthNum.Maximum = Screen.PrimaryScreen.WorkingArea.Width;
            DirectionHeightNum.Maximum = Screen.PrimaryScreen.WorkingArea.Height;

            TouchXNum.Maximum = Screen.PrimaryScreen.WorkingArea.Width;
            TouchYNum.Maximum = Screen.PrimaryScreen.WorkingArea.Height;
            TouchWidthNum.Maximum = Screen.PrimaryScreen.WorkingArea.Width;
            TouchHeightNum.Maximum = Screen.PrimaryScreen.WorkingArea.Height;

            mMain = main;

            ButtonJoystickIDCmb.DataSource = new BindingSource(mMain.JoystickButtonMapping, null);
            ButtonJoystickIDCmb.DisplayMember = "Name";
            ButtonJoystickIDCmb.ValueMember = "Code";
            ButtonKeycodeIDCmb.DataSource = new BindingSource(mMain.KeycodeMapping, null);
            ButtonKeycodeIDCmb.DisplayMember = "Name";
            ButtonKeycodeIDCmb.ValueMember = "Code";
            ButtonJoystickIDCmb.Visible = true;
            ButtonKeycodeIDCmb.Visible = false;

            MoveHorizontalAxisCmb.DataSource = new BindingSource(mMain.JoystickAxisMapping, null);
            MoveHorizontalAxisCmb.DisplayMember = "Name";
            MoveHorizontalAxisCmb.ValueMember = "Code";
            MoveHorizontalAxisLeftCmb.DataSource = new BindingSource(mMain.KeycodeMapping, null);
            MoveHorizontalAxisLeftCmb.DisplayMember = "Name";
            MoveHorizontalAxisLeftCmb.ValueMember = "Code";
            MoveHorizontalAxisRightCmb.DataSource = new BindingSource(mMain.KeycodeMapping, null);
            MoveHorizontalAxisRightCmb.DisplayMember = "Name";
            MoveHorizontalAxisRightCmb.ValueMember = "Code";
            MoveVerticalAxisCmb.DataSource = new BindingSource(mMain.JoystickAxisMapping, null);
            MoveVerticalAxisCmb.DisplayMember = "Name";
            MoveVerticalAxisCmb.ValueMember = "Code";
            MoveVerticalAxisUpCmb.DataSource = new BindingSource(mMain.KeycodeMapping, null);
            MoveVerticalAxisUpCmb.DisplayMember = "Name";
            MoveVerticalAxisUpCmb.ValueMember = "Code";
            MoveVerticalAxisDownCmb.DataSource = new BindingSource(mMain.KeycodeMapping, null);
            MoveVerticalAxisDownCmb.DisplayMember = "Name";
            MoveVerticalAxisDownCmb.ValueMember = "Code";
            MoveHorizontalXCmb.DataSource = new BindingSource(mMain.MouseMapping, null);
            MoveHorizontalXCmb.DisplayMember = "Name";
            MoveHorizontalXCmb.ValueMember = "Code";
            MoveVerticalYCmb.DataSource = new BindingSource(mMain.MouseMapping, null);
            MoveVerticalYCmb.DisplayMember = "Name";
            MoveVerticalYCmb.ValueMember = "Code";

            MoveHorizontalAxisCmb.Visible = true;
            MoveVerticalAxisCmb.Visible = true;
            MoveHorizontalAxisLeftCmb.Visible = false;
            MoveHorizontalAxisRightCmb.Visible = false;
            MoveVerticalAxisUpCmb.Visible = false;
            MoveVerticalAxisDownCmb.Visible = false;
            MoveHorizontalXCmb.Visible = false;
            MoveVerticalYCmb.Visible = false;

            DirectionHorizontalAxisCmb.DataSource = new BindingSource(mMain.JoystickAxisMapping, null);
            DirectionHorizontalAxisCmb.DisplayMember = "Name";
            DirectionHorizontalAxisCmb.ValueMember = "Code";
            DirectionHorizontalAxisLeftCmb.DataSource = new BindingSource(mMain.KeycodeMapping, null);
            DirectionHorizontalAxisLeftCmb.DisplayMember = "Name";
            DirectionHorizontalAxisLeftCmb.ValueMember = "Code";
            DirectionHorizontalAxisRightCmb.DataSource = new BindingSource(mMain.KeycodeMapping, null);
            DirectionHorizontalAxisRightCmb.DisplayMember = "Name";
            DirectionHorizontalAxisRightCmb.ValueMember = "Code";
            DirectionVerticalAxisCmb.DataSource = new BindingSource(mMain.JoystickAxisMapping, null);
            DirectionVerticalAxisCmb.DisplayMember = "Name";
            DirectionVerticalAxisCmb.ValueMember = "Code";
            DirectionVerticalAxisUpCmb.DataSource = new BindingSource(mMain.KeycodeMapping, null);
            DirectionVerticalAxisUpCmb.DisplayMember = "Name";
            DirectionVerticalAxisUpCmb.ValueMember = "Code";
            DirectionVerticalAxisDownCmb.DataSource = new BindingSource(mMain.KeycodeMapping, null);
            DirectionVerticalAxisDownCmb.DisplayMember = "Name";
            DirectionVerticalAxisDownCmb.ValueMember = "Code";
            DirectionHorizontalXCmb.DataSource = new BindingSource(mMain.MouseMapping, null);
            DirectionHorizontalXCmb.DisplayMember = "Name";
            DirectionHorizontalXCmb.ValueMember = "Code";
            DirectionVerticalYCmb.DataSource = new BindingSource(mMain.MouseMapping, null);
            DirectionVerticalYCmb.DisplayMember = "Name";
            DirectionVerticalYCmb.ValueMember = "Code";
            DirectionHorizontalAxisCmb.Visible = true;
            DirectionVerticalAxisCmb.Visible = true;
            DirectionHorizontalAxisLeftCmb.Visible = false;
            DirectionHorizontalAxisRightCmb.Visible = false;
            DirectionVerticalAxisUpCmb.Visible = false;
            DirectionVerticalAxisDownCmb.Visible = false;
            DirectionHorizontalXCmb.Visible = false;
            DirectionVerticalYCmb.Visible = false;


            TouchJoystickIDCmb.DataSource = new BindingSource(mMain.JoystickButtonMapping, null);
            TouchJoystickIDCmb.DisplayMember = "Name";
            TouchJoystickIDCmb.ValueMember = "Code";
            TouchKeycodeIDCmb.DataSource = new BindingSource(mMain.KeycodeMapping, null);
            TouchKeycodeIDCmb.DisplayMember = "Name";
            TouchKeycodeIDCmb.ValueMember = "Code";
            TouchJoystickIDCmb.Visible = true;
            TouchKeycodeIDCmb.Visible = false;

            ButtonPropertyPnl.Visible = false;
            MovePropertyPnl.Visible = false;
            DirectionPropertyPnl.Visible = false;
            TouchPropertyPnl.Visible = false;
            MinBtnPropertyPnl.Visible = false;
        }

        private void EditBoxForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (saveController())
            {
                closeAllComponent();
                this.Hide();
            }
        }

        public void setCurrentComponent(Form component)
        {
            mCurrentComponent = component;

            switch (mCurrentComponent.Name)
            {
                case "ButtonForm":
                    ((ButtonForm)mCurrentComponent).Sizeable = true;
                    toolButtonReset(TOOLTYPE.BUTTON, true);
                    RemoveBtn.Enabled = true;
                    break;
                case "MoveForm":
                    ((MoveForm)mCurrentComponent).Sizeable = true;
                    toolButtonReset(TOOLTYPE.MOVE, true);
                    RemoveBtn.Enabled = true;
                    break;
                case "DirectionForm":
                    ((DirectionForm)mCurrentComponent).Sizeable = true;
                    toolButtonReset(TOOLTYPE.DIRECTION, true);
                    RemoveBtn.Enabled = true;
                    break;
                case "TouchForm":
                    ((TouchForm)mCurrentComponent).Sizeable = true;
                    Dictionary<string, uint> _ids = ((TouchForm)mCurrentComponent).GestureIDs;
                    if (_ids.Count > 0)
                    {
                        TouchGestureIDCmb.DataSource = new BindingSource(_ids, null);
                        TouchGestureIDCmb.DisplayMember = "Key";
                        TouchGestureIDCmb.ValueMember = "Value";
                        TouchGestureIDCmb.Text = "";
                    }
                    TouchGestureIDCmb.Text = ((TouchForm)mCurrentComponent).Gesture;
                    toolButtonReset(TOOLTYPE.TOUCH, true);
                    RemoveBtn.Enabled = true;
                    break;
                case "MinimizeButtonForm":
                    ((MinimizeButtonForm)mCurrentComponent).Sizeable = true;
                    toolButtonReset(TOOLTYPE.MINBUTTON, true);
                    break;
            }

            resetProperties();
        }

        public void resetProperties()
        {
            if (mCurrentComponent == null)
                return;

            switch (mCurrentComponent.Name)
            {
                case "ButtonForm":
                    ButtonForm _button = (ButtonForm)mCurrentComponent;
                    ButtonXNum.Value = _button.XValue;
                    ButtonYNum.Value = _button.YValue;
                    ButtonWidthNum.Value = _button.WidthValue;
                    ButtonHeightNum.Value = _button.HeightValue;
                    ButtonTextTxt.Text = _button.TextValue;
                    ButtonBackColor.BackColor = _button.BackColorValue;
                    ButtonForeColor.BackColor = _button.ForeColorValue;
                    ButtonOpacityTBar.Value = _button.OpacityValue;
                    ActionPressRdo.Checked = false;
                    ActionReleaseRdo.Checked = false;
                    ActionClickRdo.Checked = false;
                    ActionToggleRdo.Checked = false;
                    switch (_button.InputMode)
                    {
                        case 0:
                            ButtonJoystickChk.Checked = ButtonJoystickIDCmb.Visible = true;
                            ButtonJoystickIDCmb.SelectedIndex = 0;
                            break;
                        case 1:
                            ButtonJoystickChk.Checked = ButtonJoystickIDCmb.Visible = true;
                            ButtonKeycodeChk.Checked = ButtonKeycodeIDCmb.Visible = false;
                            ButtonJoystickIDCmb.SelectedIndex = (int)_button.JoystickBtnIndex;

                            switch (_button.JoystickType)
                            {
                                case MainController.JOYSTICK_BUTTON_TYPE.PRESS:
                                    ActionPressRdo.Checked = true;
                                    break;
                                case MainController.JOYSTICK_BUTTON_TYPE.RELEASE:
                                    ActionReleaseRdo.Checked = true;
                                    break;
                                case MainController.JOYSTICK_BUTTON_TYPE.CLICK:
                                    ActionClickRdo.Checked = true;
                                    break;
                                case MainController.JOYSTICK_BUTTON_TYPE.TOGGLE:
                                    ActionToggleRdo.Checked = true;
                                    break;
                            }
                            break;
                        case 2:
                            ButtonJoystickChk.Checked = ButtonJoystickIDCmb.Visible = false;
                            ButtonKeycodeChk.Checked = ButtonKeycodeIDCmb.Visible = true;
                            ButtonKeycodeIDCmb.SelectedIndex = (int)_button.KeycodeBtnIndex;
                            switch (_button.KeyboardType)
                            {
                                case MainController.KEYBOARD_BUTTON_TYPE.PRESS:
                                    ActionPressRdo.Checked = true;
                                    break;
                                case MainController.KEYBOARD_BUTTON_TYPE.RELEASE:
                                    ActionReleaseRdo.Checked = true;
                                    break;
                                case MainController.KEYBOARD_BUTTON_TYPE.CLICK:
                                    ActionClickRdo.Checked = true;
                                    break;
                                case MainController.KEYBOARD_BUTTON_TYPE.TOGGLE:
                                    ActionToggleRdo.Checked = true;
                                    break;
                            }
                            break;
                    }
                    
                    break;
                case "MoveForm":
                    MoveForm _move = (MoveForm)mCurrentComponent;
                    MoveXNum.Value = _move.XValue;
                    MoveYNum.Value = _move.YValue;
                    MoveWidthNum.Value = _move.WidthValue;
                    MoveHeightNum.Value = _move.HeightValue;
                    MoveBackColor.BackColor = _move.BackColorValue;
                    MoveForeColor.BackColor = _move.ForeColorValue;
                    MoveOpacityTBar.Value = _move.OpacityValue;
                    MoveMovingColor.BackColor = _move.MovingColorValue;

                    switch (_move.HorizontalInputMode)
                    {
                        case 0:
                            MoveHorizontalAxisCmb.SelectedIndex = (int)0;

                            MoveHorizontalAxisCmb.Visible = true;
                            MoveHorizontalAxisLeftCmb.Visible = false;
                            MoveHorizontalAxisRightCmb.Visible = false;
                            MoveHorizontalXCmb.Visible = false;

                            MoveHJoystickChk.Checked = true;
                            MoveHKeycodeChk.Checked = false;
                            MoveHMouseChk.Checked = false;
                            break;
                        case 1:
                            MoveHorizontalAxisCmb.SelectedIndex = (int)_move.HorizontalAxisIndex;

                            MoveHorizontalAxisCmb.Visible = true;
                            MoveHorizontalAxisLeftCmb.Visible = false;
                            MoveHorizontalAxisRightCmb.Visible = false;
                            MoveHorizontalXCmb.Visible = false;

                            MoveHJoystickChk.Checked = true;
                            MoveHKeycodeChk.Checked = false;
                            MoveHMouseChk.Checked = false;
                            break;
                        case 2:
                            MoveHorizontalAxisLeftCmb.SelectedIndex = (int)_move.KeycodeLeftIndex;
                            MoveHorizontalAxisRightCmb.SelectedIndex = (int)_move.KeycodeRightIndex;

                            MoveHorizontalAxisLeftCmb.Visible = true;
                            MoveHorizontalAxisRightCmb.Visible = true;
                            MoveHorizontalAxisCmb.Visible = false;
                            MoveHorizontalXCmb.Visible = false;

                            MoveHKeycodeChk.Checked = true;
                            MoveHJoystickChk.Checked = false;
                            MoveHMouseChk.Checked = false;
                            break;
                        case 3:
                            MoveHorizontalXCmb.SelectedIndex = (int)_move.MouseXIndex;

                            MoveHorizontalXCmb.Visible = true;
                            MoveHorizontalAxisCmb.Visible = false;
                            MoveHorizontalAxisLeftCmb.Visible = false;
                            MoveHorizontalAxisRightCmb.Visible = false;

                            MoveHMouseChk.Checked = true; 
                            MoveHJoystickChk.Checked = false;
                            MoveHKeycodeChk.Checked = false;
                            break;
                    }
                    switch (_move.VerticalInputMode)
                    {
                        case 0:
                            MoveVerticalAxisCmb.SelectedIndex = (int)0;

                            MoveVerticalAxisCmb.Visible = true;
                            MoveVerticalAxisDownCmb.Visible = false;
                            MoveVerticalAxisUpCmb.Visible = false;
                            MoveVerticalYCmb.Visible = false;

                            MoveVJoystickChk.Checked = true;
                            MoveVKeycodeChk.Checked = false;
                            MoveVMouseChk.Checked = false;
                            break;
                        case 1:
                            MoveVerticalAxisCmb.SelectedIndex = (int)_move.VerticalAxisIndex;

                            MoveVerticalAxisCmb.Visible = true;
                            MoveVerticalAxisDownCmb.Visible = false;
                            MoveVerticalAxisUpCmb.Visible = false;
                            MoveVerticalYCmb.Visible = false;

                            MoveVJoystickChk.Checked = true;
                            MoveVKeycodeChk.Checked = false;
                            MoveVMouseChk.Checked = false;
                            break;
                        case 2:
                            MoveVerticalAxisDownCmb.SelectedIndex = (int)_move.KeycodeDownIndex;
                            MoveVerticalAxisUpCmb.SelectedIndex = (int)_move.KeycodeUpIndex;

                            MoveVerticalAxisDownCmb.Visible = true;
                            MoveVerticalAxisUpCmb.Visible = true;
                            MoveVerticalAxisCmb.Visible = false;
                            MoveVerticalYCmb.Visible = false;

                            MoveVKeycodeChk.Checked = true;
                            MoveVJoystickChk.Checked = false;
                            MoveVMouseChk.Checked = false;
                            break;
                        case 3:
                            MoveVerticalYCmb.SelectedIndex = (int)_move.MouseYIndex;

                            MoveVerticalYCmb.Visible = true;
                            MoveVerticalAxisCmb.Visible = false;
                            MoveVerticalAxisDownCmb.Visible = false;
                            MoveVerticalAxisUpCmb.Visible = false;

                            MoveVMouseChk.Checked = true;
                            MoveVJoystickChk.Checked = false;
                            MoveVKeycodeChk.Checked = false;
                            break;
                    }

                    break;
                case "DirectionForm":
                    DirectionForm _direction = (DirectionForm)mCurrentComponent;
                    DirectionXNum.Value = _direction.XValue;
                    DirectionYNum.Value = _direction.YValue;
                    DirectionWidthNum.Value = _direction.WidthValue;
                    DirectionHeightNum.Value = _direction.HeightValue;
                    DirectionBackColor.BackColor = _direction.BackColorValue;
                    DirectionForeColor.BackColor = _direction.MovingColorValue;
                    DirectionOpacityTBar.Value = _direction.OpacityValue;
                    DirectionNeutualReleaseMouse.Checked = _direction.NeutualReleaseMouse;
                    DirectionNeutualDoubleclick.Checked = _direction.NeutualDoubleClick;

                    switch (_direction.HorizontalInputMode)
                    {
                        case 0:
                            DirectionHorizontalAxisCmb.SelectedIndex = (int)0;

                            DirectionHorizontalAxisCmb.Visible = true;
                            DirectionHorizontalAxisLeftCmb.Visible = false;
                            DirectionHorizontalAxisRightCmb.Visible = false;
                            DirectionHorizontalXCmb.Visible = false;

                            DirectionHJoystickChk.Checked = true;
                            DirectionHKeycodeChk.Checked = false;
                            DirectionHMouseChk.Checked = false;
                            break;
                        case 1:
                            DirectionHorizontalAxisCmb.SelectedIndex = (int)_direction.HorizontalAxisIndex;

                            DirectionHorizontalAxisCmb.Visible = true;
                            DirectionHorizontalAxisLeftCmb.Visible = false;
                            DirectionHorizontalAxisRightCmb.Visible = false;
                            DirectionHorizontalXCmb.Visible = false;

                            DirectionHJoystickChk.Checked = true;
                            DirectionHKeycodeChk.Checked = false;
                            DirectionHMouseChk.Checked = false;
                            break;
                        case 2:
                            DirectionHorizontalAxisLeftCmb.SelectedIndex = (int)_direction.KeycodeLeftIndex;
                            DirectionHorizontalAxisRightCmb.SelectedIndex = (int)_direction.KeycodeRightIndex;

                            DirectionHorizontalAxisLeftCmb.Visible = true;
                            DirectionHorizontalAxisRightCmb.Visible = true;
                            DirectionHorizontalAxisCmb.Visible = false;
                            DirectionHorizontalXCmb.Visible = false;

                            DirectionHKeycodeChk.Checked = true;
                            DirectionHJoystickChk.Checked = false;
                            DirectionHMouseChk.Checked = false;
                            break;
                        case 3:
                            DirectionHorizontalXCmb.SelectedIndex = (int)_direction.MouseXIndex;

                            DirectionHorizontalXCmb.Visible = true;
                            DirectionHorizontalAxisCmb.Visible = false;
                            DirectionHorizontalAxisLeftCmb.Visible = false;
                            DirectionHorizontalAxisRightCmb.Visible = false;

                            DirectionHMouseChk.Checked = true;
                            DirectionHJoystickChk.Checked = false;
                            DirectionHKeycodeChk.Checked = false;
                            break;
                    }
                    switch (_direction.VerticalInputMode)
                    {
                        case 0:
                            DirectionVerticalAxisCmb.SelectedIndex = (int)0;

                            DirectionVerticalAxisCmb.Visible = true;
                            DirectionVerticalAxisDownCmb.Visible = false;
                            DirectionVerticalAxisUpCmb.Visible = false;
                            DirectionVerticalYCmb.Visible = false;

                            DirectionVJoystickChk.Checked = true;
                            DirectionVKeycodeChk.Checked = false;
                            DirectionVMouseChk.Checked = false;
                            break;
                        case 1:
                            DirectionVerticalAxisCmb.SelectedIndex = (int)_direction.VerticalAxisIndex;

                            DirectionVerticalAxisCmb.Visible = true;
                            DirectionVerticalAxisDownCmb.Visible = false;
                            DirectionVerticalAxisUpCmb.Visible = false;
                            DirectionVerticalYCmb.Visible = false;

                            DirectionVJoystickChk.Checked = true;
                            DirectionVKeycodeChk.Checked = false;
                            DirectionVMouseChk.Checked = false;
                            break;
                        case 2:
                            DirectionVerticalAxisDownCmb.SelectedIndex = (int)_direction.KeycodeDownIndex;
                            DirectionVerticalAxisUpCmb.SelectedIndex = (int)_direction.KeycodeUpIndex;

                            DirectionVerticalAxisDownCmb.Visible = true;
                            DirectionVerticalAxisUpCmb.Visible = true;
                            DirectionVerticalAxisCmb.Visible = false;
                            DirectionVerticalYCmb.Visible = false;

                            DirectionVKeycodeChk.Checked = true;
                            DirectionVJoystickChk.Checked = false;
                            DirectionVMouseChk.Checked = false;
                            break;
                        case 3:
                            DirectionVerticalYCmb.SelectedIndex = (int)_direction.MouseYIndex;

                            DirectionVerticalYCmb.Visible = true;
                            DirectionVerticalAxisCmb.Visible = false;
                            DirectionVerticalAxisDownCmb.Visible = false;
                            DirectionVerticalAxisUpCmb.Visible = false;

                            DirectionVMouseChk.Checked = true;
                            DirectionVJoystickChk.Checked = false;
                            DirectionVKeycodeChk.Checked = false;
                            break;
                    }
                    break;
                case "TouchForm":
                    TouchForm _touch = (TouchForm)mCurrentComponent;
                    TouchXNum.Value = _touch.XValue;
                    TouchYNum.Value = _touch.YValue;
                    TouchWidthNum.Value = _touch.WidthValue;
                    TouchHeightNum.Value = _touch.HeightValue;
                    //TouchBackColor.BackColor = _touch.BackColorValue;
                    //TouchForeColor.ForeColor = _touch.ForeColorValue;
                    //TouchOpacityTBar.Value = _touch.OpacityValue;
                    TouchGestureIDCmb.Text = _touch.Gesture;
                    if (_touch.GestureIDs.ContainsKey(_touch.Gesture))
                    {
                        TouchJoystickIDCmb.SelectedIndex = (int)_touch.GestureIDs[_touch.Gesture];
                    }
                    else
                    {
                        TouchJoystickIDCmb.SelectedIndex = 0;
                    }
                    break;
                case "MinimizeButtonForm":
                    MinimizeButtonForm _minBtn = (MinimizeButtonForm)mCurrentComponent;
                    MinBtnXNum.Value = _minBtn.XValue;
                    MinBtnYNum.Value = _minBtn.YValue;
                    MinBtnWidthNum.Value = _minBtn.WidthValue;
                    MinBtnHeightNum.Value = _minBtn.HeightValue;
                    //MinBtnBackColor.BackColor = _minBtn.BackColorValue;
                    //MinBtnBorderColor.BackColor = _minBtn.BorderColorValue;
                    //MinBtnOpacityTBar.Value = _minBtn.OpacityValue;
                    break;
            }

        }

        private void ButtonTextTxt_TextChanged(object sender, EventArgs e)
        {
            if (mCurrentComponent == null)
                return;
            if (mCurrentComponent.Name == "ButtonForm")
            {
                ButtonForm _button = (ButtonForm)mCurrentComponent;
                _button.TextValue = ButtonTextTxt.Text;
            }
        }

        #region Location and Size Property code

        private void XNum_ValueChanged(object sender, EventArgs e)
        {
            if (mCurrentComponent == null)
                return;
            switch(mCurrentComponent.Name)
            {
                case "ButtonForm":
                    ButtonForm _button = (ButtonForm)mCurrentComponent;
                    _button.XValue = Convert.ToInt32(ButtonXNum.Value);
                    break;
                case "MoveForm":
                    MoveForm _move = (MoveForm)mCurrentComponent;
                    _move.XValue = Convert.ToInt32(MoveXNum.Value);
                    break;
                case "DirectionForm":
                    DirectionForm _direction = (DirectionForm)mCurrentComponent;
                    _direction.XValue = Convert.ToInt32(DirectionXNum.Value);
                    break;
                case "TouchForm":
                    TouchForm _touch = (TouchForm)mCurrentComponent;
                    _touch.XValue = Convert.ToInt32(TouchXNum.Value);
                    break;
                case "MinimizeButtonForm":
                    MinimizeButtonForm _minBtn = (MinimizeButtonForm)mCurrentComponent;
                    _minBtn.XValue = Convert.ToInt32(MinBtnXNum.Value);
                    break;
            }
        }

        private void YNum_ValueChanged(object sender, EventArgs e)
        {
            if (mCurrentComponent == null)
                return;
            switch (mCurrentComponent.Name)
            {
                case "ButtonForm":
                    ButtonForm _button = (ButtonForm)mCurrentComponent;
                    _button.YValue = Convert.ToInt32(ButtonYNum.Value);
                    break;
                case "MoveForm":
                    MoveForm _move = (MoveForm)mCurrentComponent;
                    _move.YValue = Convert.ToInt32(MoveYNum.Value);
                    break;
                case "DirectionForm":
                    DirectionForm _direction = (DirectionForm)mCurrentComponent;
                    _direction.YValue = Convert.ToInt32(DirectionYNum.Value);
                    break;
                case "TouchForm":
                    TouchForm _touch = (TouchForm)mCurrentComponent;
                    _touch.YValue = Convert.ToInt32(TouchYNum.Value);
                    break;
                case "MinimizeButtonForm":
                    MinimizeButtonForm _minBtn = (MinimizeButtonForm)mCurrentComponent;
                    _minBtn.YValue = Convert.ToInt32(MinBtnYNum.Value);
                    break;
            }
        }

        private void WidthNum_ValueChanged(object sender, EventArgs e)
        {
            if (mCurrentComponent == null)
                return;
            switch (mCurrentComponent.Name)
            {
                case "ButtonForm":
                    ButtonForm _button = (ButtonForm)mCurrentComponent;
                    _button.WidthValue = Convert.ToInt32(ButtonWidthNum.Value);
                    break;
                case "MoveForm":
                    MoveForm _move = (MoveForm)mCurrentComponent;
                    _move.WidthValue = Convert.ToInt32(MoveWidthNum.Value);
                    break;
                case "DirectionForm":
                    DirectionForm _direction = (DirectionForm)mCurrentComponent;
                    _direction.WidthValue = Convert.ToInt32(DirectionWidthNum.Value);
                    break;
                case "TouchForm":
                    TouchForm _touch = (TouchForm)mCurrentComponent;
                    _touch.WidthValue = Convert.ToInt32(TouchWidthNum.Value);
                    break;
                case "MinimizeButtonForm":
                    MinimizeButtonForm _minBtn = (MinimizeButtonForm)mCurrentComponent;
                    _minBtn.WidthValue = Convert.ToInt32(MinBtnWidthNum.Value);
                    break;
            }
        }

        private void HeightNum_ValueChanged(object sender, EventArgs e)
        {
            if (mCurrentComponent == null)
                return;
            switch (mCurrentComponent.Name)
            {
                case "ButtonForm":
                    ButtonForm _button = (ButtonForm)mCurrentComponent;
                    _button.WidthValue = Convert.ToInt32(ButtonHeightNum.Value);
                    break;
                case "MoveForm":
                    MoveForm _move = (MoveForm)mCurrentComponent;
                    _move.WidthValue = Convert.ToInt32(MoveHeightNum.Value);
                    break;
                case "DirectionForm":
                    DirectionForm _direction = (DirectionForm)mCurrentComponent;
                    _direction.WidthValue = Convert.ToInt32(DirectionHeightNum.Value);
                    break;
                case "TouchForm":
                    TouchForm _touch = (TouchForm)mCurrentComponent;
                    _touch.HeightValue = Convert.ToInt32(TouchHeightNum.Value);
                    break;
                case "MinimizeButtonForm":
                    MinimizeButtonForm _minBtn = (MinimizeButtonForm)mCurrentComponent;
                    _minBtn.HeightValue = Convert.ToInt32(MinBtnHeightNum.Value);
                    break;
            }
        }
        #endregion
        #region Color Property code

        private void ForeColorBtn_Click(object sender, EventArgs e)
        {
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                switch (mCurrentComponent.Name)
                {
                    case "ButtonForm":
                        ButtonForeColor.BackColor = colorDlg.Color;
                        ButtonForm _button = (ButtonForm)mCurrentComponent;
                        _button.ForeColorValue = colorDlg.Color;
                        break;
                    case "MoveForm":
                        MoveForeColor.BackColor = colorDlg.Color;
                        MoveForm _move = (MoveForm)mCurrentComponent;
                        _move.ForeColorValue = colorDlg.Color;
                        break;
                    case "DirectionForm":
                        DirectionForeColor.BackColor = colorDlg.Color;
                        DirectionForm _direction = (DirectionForm)mCurrentComponent;
                        _direction.MovingColorValue = colorDlg.Color;
                        break;
                    case "TouchForm":
                        TouchForeColor.BackColor = colorDlg.Color;
                        TouchForm _touch = (TouchForm)mCurrentComponent;
                        _touch.ForeColorValue = colorDlg.Color;
                        break;

                }
            }
        }

        private void BackColorBtn_Click(object sender, EventArgs e)
        {
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                switch (mCurrentComponent.Name)
                {
                    case "ButtonForm":
                        ButtonBackColor.BackColor = colorDlg.Color;
                        ButtonForm _button = (ButtonForm)mCurrentComponent;
                        _button.BackColorValue = colorDlg.Color;
                        break;
                    case "MoveForm":
                        MoveBackColor.BackColor = colorDlg.Color;
                        MoveForm _move = (MoveForm)mCurrentComponent;
                        _move.BackColorValue = colorDlg.Color;
                        break;
                    case "DirectionForm":
                        DirectionBackColor.BackColor = colorDlg.Color;
                        DirectionForm _direction = (DirectionForm)mCurrentComponent;
                        _direction.BackColorValue = colorDlg.Color;
                        break;
                    case "TouchForm":
                        TouchBackColor.BackColor = colorDlg.Color;
                        TouchForm _touch = (TouchForm)mCurrentComponent;
                        _touch.BackColorValue = colorDlg.Color;
                        break;
                    case "MinimizeButtonForm":
                        MinBtnBackColor.BackColor = colorDlg.Color;
                        MinimizeButtonForm _minBtn = (MinimizeButtonForm)mCurrentComponent;
                        _minBtn.BackColorValue = colorDlg.Color;
                        break;
                }
            }
        }

        private void BorderColorBtn_Click(object sender, EventArgs e)
        {
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                switch (mCurrentComponent.Name)
                {
                    case "MinimizeButtonForm":
                        MinBtnBorderColor.BackColor = colorDlg.Color;
                        MinimizeButtonForm _minBtn = (MinimizeButtonForm)mCurrentComponent;
                        _minBtn.BorderColorValue = colorDlg.Color;
                        break;
                }
            }
        }

        private void OpacityTBar_Scroll(object sender, EventArgs e)
        {
            switch (mCurrentComponent.Name)
            {
                case "ButtonForm":
                    ButtonForm _button = (ButtonForm)mCurrentComponent;
                    _button.OpacityValue = ButtonOpacityTBar.Value;
                    break;
                case "MoveForm":
                    MoveForm _move = (MoveForm)mCurrentComponent;
                    _move.OpacityValue = MoveOpacityTBar.Value;
                    break;
                case "DirectionForm":
                    DirectionForm _direction = (DirectionForm)mCurrentComponent;
                    _direction.OpacityValue = DirectionOpacityTBar.Value;
                    break;
                case "TouchForm":
                    TouchForm _touch = (TouchForm)mCurrentComponent;
                    _touch.OpacityValue = TouchOpacityTBar.Value;
                    break;
                case "MinimizeButtonForm":
                    MinimizeButtonForm _minBtn = (MinimizeButtonForm)mCurrentComponent;
                    _minBtn.OpacityValue = MinBtnOpacityTBar.Value;
                    break;
            }
        }

        private void MovingColorBtn_Click(object sender, EventArgs e)
        {
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                switch (mCurrentComponent.Name)
                {
                    case "MoveForm":
                        MoveMovingColor.BackColor = colorDlg.Color;
                        MoveForm _move = (MoveForm)mCurrentComponent;
                        _move.MovingColorValue = colorDlg.Color;
                        break;
                    //case "DirectionForm":
                    //    DirectionMovingColor.BackColor = colorDlg.Color;
                    //    DirectionForm _direction = (DirectionForm)mCurrentComponent;
                    //    _direction.MovingColorValue = colorDlg.Color;
                    //    break;
                }
            }
        }
        #endregion
        #region Optional Property code
        

        private void DirectionNeutualLeaveMouse_CheckedChanged(object sender, EventArgs e)
        {
            switch (mCurrentComponent.Name)
            {
                case "DirectionForm":
                    DirectionForm _direction = (DirectionForm)mCurrentComponent;
                    _direction.NeutualReleaseMouse = DirectionNeutualReleaseMouse.Checked;
                    break;
            }
        }

        private void DirectionNeutualDoubleclick_CheckedChanged(object sender, EventArgs e)
        {
            switch (mCurrentComponent.Name)
            {
                case "DirectionForm":
                    DirectionForm _direction = (DirectionForm)mCurrentComponent;
                    _direction.NeutualDoubleClick = DirectionNeutualDoubleclick.Checked;
                    break;
            }
        }
        #endregion

        #region Component CheckBox
        private void JoystickChk_Click(object sender, EventArgs e)
        {
            //ComboBox _combo;
            CheckBox _chk;

            if (mCurrentComponent == null)
                return;

            switch (mCurrentComponent.Name)
            {
                case "ButtonForm":
                    ButtonForm _button = (ButtonForm)mCurrentComponent;
                    ButtonJoystickChk.Checked = true;
                    ButtonKeycodeChk.Checked = false;

                    ButtonJoystickIDCmb.Visible = true;
                    ButtonKeycodeIDCmb.Visible = false;
                    _button.InputMode = 1;
                    break;
                case "MoveForm":
                    MoveForm _move = (MoveForm)mCurrentComponent;
                    _chk = (CheckBox)sender;
                    if (_chk.Name == "MoveHJoystickChk")
                    {
                        MoveHJoystickChk.Checked = true;
                        MoveHKeycodeChk.Checked = false;
                        MoveHMouseChk.Checked = false;

                        MoveHorizontalAxisCmb.Visible = true;

                        MoveHorizontalAxisLeftCmb.Visible = false;
                        MoveHorizontalAxisRightCmb.Visible = false;
                        MoveHorizontalXCmb.Visible = false;

                        _move.HorizontalInputMode = 1;
                    }
                    else if (_chk.Name == "MoveVJoystickChk")
                    {
                        MoveVJoystickChk.Checked = true;
                        MoveVKeycodeChk.Checked = false;
                        MoveVMouseChk.Checked = false;

                        MoveVerticalAxisCmb.Visible = true;

                        MoveVerticalAxisUpCmb.Visible = false;
                        MoveVerticalAxisDownCmb.Visible = false;
                        MoveVerticalYCmb.Visible = false;

                        _move.VerticalInputMode = 1;
                    }
                    break;
                case "DirectionForm":
                    DirectionForm _direction = (DirectionForm)mCurrentComponent;
                    _chk = (CheckBox)sender;
                    if (_chk.Name == "DirectionHJoystickChk")
                    {
                        DirectionHJoystickChk.Checked = true;
                        DirectionHKeycodeChk.Checked = false;
                        DirectionHMouseChk.Checked = false;

                        DirectionHorizontalAxisCmb.Visible = true;

                        DirectionHorizontalAxisLeftCmb.Visible = false;
                        DirectionHorizontalAxisRightCmb.Visible = false;
                        DirectionHorizontalXCmb.Visible = false;

                        _direction.HorizontalInputMode = 1;
                    }
                    else if (_chk.Name == "DirectionVJoystickChk")
                    {
                        DirectionVJoystickChk.Checked = true;
                        DirectionVKeycodeChk.Checked = false;
                        DirectionVMouseChk.Checked = false;

                        DirectionVerticalAxisCmb.Visible = true;

                        DirectionVerticalAxisUpCmb.Visible = false;
                        DirectionVerticalAxisDownCmb.Visible = false;
                        DirectionVerticalYCmb.Visible = false;

                        _direction.VerticalInputMode = 1;
                    }
                    break;
                case "TouchForm":
                    TouchForm _touch = (TouchForm)mCurrentComponent;
                    TouchJoystickIDCmb.Visible = TouchJoystickChk.Checked = true;
                    TouchKeycodeIDCmb.Visible = TouchKeycodeChk.Checked = false;

                    //_touch.InputMode = 1;
                    break;
            }
        }   
        private void KeycodeChk_Click(object sender, EventArgs e)
        {
            //ComboBox _combo;
            CheckBox _chk;

            if (mCurrentComponent == null)
                return;

            switch (mCurrentComponent.Name)
            {
                case "ButtonForm":
                    ButtonForm _button = (ButtonForm)mCurrentComponent;
                    ButtonJoystickChk.Checked = false;
                    ButtonKeycodeChk.Checked = true;

                    ButtonJoystickIDCmb.Visible = false;
                    ButtonKeycodeIDCmb.Visible = true;
                    _button.InputMode = 2;
                    break;
                case "MoveForm":
                    MoveForm _move = (MoveForm)mCurrentComponent;
                    _chk = (CheckBox)sender;
                    if (_chk.Name == "MoveHKeycodeChk")
                    {
                        MoveHKeycodeChk.Checked = true;
                        MoveHJoystickChk.Checked = false;
                        MoveHMouseChk.Checked = false;

                        MoveHorizontalAxisLeftCmb.Visible = true;
                        MoveHorizontalAxisRightCmb.Visible = true;

                        MoveHorizontalAxisCmb.Visible = false;
                        MoveHorizontalXCmb.Visible = false;

                        _move.HorizontalInputMode = 2;
                    }
                    else if (_chk.Name == "MoveVKeycodeChk")
                    {
                        MoveVKeycodeChk.Checked = true;
                        MoveVJoystickChk.Checked = false;
                        MoveVMouseChk.Checked = false;

                        MoveVerticalAxisUpCmb.Visible = true;
                        MoveVerticalAxisDownCmb.Visible = true;

                        MoveVerticalAxisCmb.Visible = false;
                        MoveVerticalYCmb.Visible = false;

                        _move.VerticalInputMode = 2;
                    }
                    break;
                case "DirectionForm":
                    DirectionForm _direction = (DirectionForm)mCurrentComponent;
                    _chk = (CheckBox)sender;
                    if (_chk.Name == "DirectionHKeycodeChk")
                    {
                        DirectionHKeycodeChk.Checked = true;
                        DirectionHJoystickChk.Checked = false;
                        DirectionHMouseChk.Checked = false;

                        DirectionHorizontalAxisLeftCmb.Visible = true;
                        DirectionHorizontalAxisRightCmb.Visible = true;

                        DirectionHorizontalAxisCmb.Visible = false;
                        DirectionHorizontalXCmb.Visible = false;

                        _direction.HorizontalInputMode = 2;
                    }
                    else if (_chk.Name == "DirectionVKeycodeChk")
                    {
                        DirectionVKeycodeChk.Checked = true;
                        DirectionVJoystickChk.Checked = false;
                        DirectionVMouseChk.Checked = false;

                        DirectionVerticalAxisUpCmb.Visible = true;
                        DirectionVerticalAxisDownCmb.Visible = true;

                        DirectionVerticalAxisCmb.Visible = false;
                        DirectionVerticalYCmb.Visible = false;

                        _direction.VerticalInputMode = 2;
                    }
                    break;
                case "TouchForm":
                    TouchForm _touch = (TouchForm)mCurrentComponent;
                    TouchJoystickChk.Checked = true;
                    TouchKeycodeChk.Checked = false;

                    TouchJoystickIDCmb.Visible = false;
                    TouchKeycodeIDCmb.Visible = true;

                    //_touch.InputMode = 2;
                    break;
            }
        }
        private void MouseChk_Click(object sender, EventArgs e)
        {
            //ComboBox _combo;
            CheckBox _chk;

            _chk = (CheckBox)sender;

            if (mCurrentComponent == null)
                return;

            switch (mCurrentComponent.Name)
            {
                case "ButtonForm":
                    break;
                case "MoveForm":
                    MoveForm _move = (MoveForm)mCurrentComponent;
                    _chk = (CheckBox)sender;
                    if (_chk.Name == "MoveHMouseChk")
                    {
                        MoveHMouseChk.Checked = true;
                        MoveHJoystickChk.Checked = false;
                        MoveHKeycodeChk.Checked = false;

                        MoveHorizontalXCmb.Visible = true;

                        MoveHorizontalAxisCmb.Visible = false;
                        MoveHorizontalAxisLeftCmb.Visible = false;
                        MoveHorizontalAxisRightCmb.Visible = false;
                        
                        _move.HorizontalInputMode = 3;
                    }
                    else if (_chk.Name == "MoveVMouseChk")
                    {
                        MoveVMouseChk.Checked = true;
                        MoveVJoystickChk.Checked = false;
                        MoveVKeycodeChk.Checked = false;

                        MoveVerticalYCmb.Visible = true;

                        MoveVerticalAxisCmb.Visible = false;
                        MoveVerticalAxisUpCmb.Visible = false;
                        MoveVerticalAxisDownCmb.Visible = false;

                        _move.VerticalInputMode = 3;
                    }
                    break;
                case "DirectionForm":
                    DirectionForm _direction = (DirectionForm)mCurrentComponent;
                    _chk = (CheckBox)sender;
                    if (_chk.Name == "DirectionHMouseChk")
                    {
                        DirectionHMouseChk.Checked = true;
                        DirectionHJoystickChk.Checked = false;
                        DirectionHKeycodeChk.Checked = false;

                        DirectionHorizontalXCmb.Visible = true;

                        DirectionHorizontalAxisCmb.Visible = false;
                        DirectionHorizontalAxisLeftCmb.Visible = false;
                        DirectionHorizontalAxisRightCmb.Visible = false;
                        

                        _direction.HorizontalInputMode = 3;
                    }
                    else if (_chk.Name == "DirectionVMouseChk")
                    {
                        DirectionVMouseChk.Checked = true;
                        DirectionVJoystickChk.Checked = false;
                        DirectionVKeycodeChk.Checked = false;

                        DirectionVerticalYCmb.Visible = true;

                        DirectionVerticalAxisCmb.Visible = false;
                        DirectionVerticalAxisUpCmb.Visible = false;
                        DirectionVerticalAxisDownCmb.Visible = false;

                        _direction.VerticalInputMode = 3;
                    }
                    break;
                case "TouchForm":
                    break;
            }

        }
        #endregion

        #region Component RadioButtion
        private void ActionRdo_CheckedChanged(object sender, EventArgs e)
        {
            //ComboBox _combo;
            //CheckBox _chk;

            if (mCurrentComponent == null)
                return;

            switch (mCurrentComponent.Name)
            {
                case "ButtonForm":
                    ButtonForm _button = (ButtonForm)mCurrentComponent;
                    switch(_button.InputMode)
                    {
                        case 1:
                            if (ActionPressRdo.Checked)
                            {
                                _button.JoystickType = MainController.JOYSTICK_BUTTON_TYPE.PRESS;
                            }
                            else if (ActionReleaseRdo.Checked)
                            {
                                _button.JoystickType = MainController.JOYSTICK_BUTTON_TYPE.RELEASE;
                            }
                            else if (ActionClickRdo.Checked)
                            {
                                _button.JoystickType = MainController.JOYSTICK_BUTTON_TYPE.CLICK;
                            }
                            else if (ActionToggleRdo.Checked)
                            {
                                _button.JoystickType = MainController.JOYSTICK_BUTTON_TYPE.TOGGLE;
                            }
                            break;
                        case 2:
                            if (ActionPressRdo.Checked)
                            {
                                _button.KeyboardType = MainController.KEYBOARD_BUTTON_TYPE.PRESS;
                            }
                            else if (ActionReleaseRdo.Checked)
                            {
                                _button.KeyboardType = MainController.KEYBOARD_BUTTON_TYPE.RELEASE;
                            }
                            else if (ActionClickRdo.Checked)
                            {
                                _button.KeyboardType = MainController.KEYBOARD_BUTTON_TYPE.CLICK;
                            }
                            else if (ActionToggleRdo.Checked)
                            {
                                _button.KeyboardType = MainController.KEYBOARD_BUTTON_TYPE.TOGGLE;
                            }
                            break;
                    }
                    
                    break;
            }
                    
        }
        #endregion

        #region Selection Property code

        private void JoyStickCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox _combo;

            if (mCurrentComponent == null)
                return;

            switch (mCurrentComponent.Name)
            {
                case "ButtonForm":
                    ButtonForm _button = (ButtonForm)mCurrentComponent;
                    _combo = (ComboBox)sender;

                    switch(_combo.Name)
                    {
                        case "ButtonJoystickIDCmb":
                            _button.JoystickBtnID = (uint)ButtonJoystickIDCmb.SelectedValue;
                            _button.JoystickBtnIndex = (uint)ButtonJoystickIDCmb.SelectedIndex;
                            _button.InputMode = 1;
                            break;
                        case "ButtonKeycodeIDCmb":
                            _button.KeycodeBtnID = (uint)ButtonKeycodeIDCmb.SelectedValue;
                            _button.KeycodeBtnIndex = (uint)ButtonKeycodeIDCmb.SelectedIndex;
                            _button.InputMode = 2;
                            break;
                    }
                    
                    break;
                case "MoveForm":
                    MoveForm _move = (MoveForm)mCurrentComponent;
                    _combo = (ComboBox)sender;

                    switch (_combo.Name)
                    {
                        case "MoveHorizontalAxisCmb":
                            _move.HorizontalAxisID = (uint)MoveHorizontalAxisCmb.SelectedValue;
                            _move.HorizontalAxisIndex = (uint)MoveHorizontalAxisCmb.SelectedIndex;
                            _move.HorizontalInputMode = 1;
                            break;
                        case "MoveVerticalAxisCmb":
                            _move.VerticalAxisID = (uint)MoveVerticalAxisCmb.SelectedValue;
                            _move.VerticalAxisIndex = (uint)MoveVerticalAxisCmb.SelectedIndex;
                            _move.VerticalInputMode = 1;
                            break;
                        case "MoveHorizontalAxisLeftCmb":
                            _move.KeycodeLeftID= (uint)MoveHorizontalAxisLeftCmb.SelectedValue;
                            _move.KeycodeLeftIndex = (uint)MoveHorizontalAxisLeftCmb.SelectedIndex;
                            _move.HorizontalInputMode = 2;
                            break;
                        case "MoveHorizontalAxisRightCmb":
                            _move.KeycodeRightID = (uint)MoveHorizontalAxisRightCmb.SelectedValue;
                            _move.KeycodeRightIndex = (uint)MoveHorizontalAxisRightCmb.SelectedIndex;
                            _move.HorizontalInputMode = 2;
                            break;
                        case "MoveVerticalAxisDownCmb":
                            _move.KeycodeDownID = (uint)MoveVerticalAxisDownCmb.SelectedValue;
                            _move.KeycodeDownIndex = (uint)MoveVerticalAxisDownCmb.SelectedIndex;
                            _move.VerticalInputMode = 2;
                            break;
                        case "MoveVerticalAxisUpCmb":
                            _move.KeycodeUpID = (uint)MoveVerticalAxisUpCmb.SelectedValue;
                            _move.KeycodeUpIndex = (uint)MoveVerticalAxisUpCmb.SelectedIndex;
                            _move.VerticalInputMode = 2;
                            break;
                        case "MoveHorizontalXCmb":
                            _move.MouseXID = (uint)MoveHorizontalXCmb.SelectedValue;
                            _move.MouseXIndex = (uint)MoveHorizontalXCmb.SelectedIndex;
                            _move.HorizontalInputMode = 3;
                            break;
                        case "MoveVerticalYCmb":
                            _move.MouseYID = (uint)MoveVerticalYCmb.SelectedValue;
                            _move.MouseYIndex = (uint)MoveVerticalYCmb.SelectedIndex;
                            _move.VerticalInputMode = 3;
                            break;
                        
                    }
                    break;
                case "DirectionForm":
                    DirectionForm _direction = (DirectionForm)mCurrentComponent;
                    _combo = (ComboBox)sender;

                    switch(_combo.Name)
                    {
                        case "DirectionHorizontalAxisCmb":
                            _direction.HorizontalAxisID = (uint)DirectionHorizontalAxisCmb.SelectedValue;
                            _direction.HorizontalAxisIndex = (uint)DirectionHorizontalAxisCmb.SelectedIndex;
                            _direction.HorizontalInputMode = 1;
                            break;
                        case "DirectionVerticalAxisCmb":
                            _direction.VerticalAxisID = (uint)DirectionVerticalAxisCmb.SelectedValue;
                            _direction.VerticalAxisIndex = (uint)DirectionVerticalAxisCmb.SelectedIndex;
                            _direction.VerticalInputMode = 1;
                            break;
                        case "DirectionHorizontalAxisLeftCmb":
                            _direction.KeycodeLeftID = (uint)DirectionHorizontalAxisLeftCmb.SelectedValue;
                            _direction.KeycodeLeftIndex = (uint)DirectionHorizontalAxisLeftCmb.SelectedIndex;
                            _direction.HorizontalInputMode = 2;
                            break;
                        case "DirectionHorizontalAxisRightCmb":
                            _direction.KeycodeRightID = (uint)DirectionHorizontalAxisRightCmb.SelectedValue;
                            _direction.KeycodeRightIndex = (uint)DirectionHorizontalAxisRightCmb.SelectedIndex;
                            _direction.HorizontalInputMode = 2;
                            break;
                        case "DirectionVerticalAxisDownCmb":
                            _direction.KeycodeDownID = (uint)DirectionVerticalAxisDownCmb.SelectedValue;
                            _direction.KeycodeDownIndex = (uint)DirectionVerticalAxisDownCmb.SelectedIndex;
                            _direction.VerticalInputMode = 2;
                            break;
                        case "DirectionVerticalAxisUpCmb":
                            _direction.KeycodeUpID = (uint)DirectionVerticalAxisUpCmb.SelectedValue;
                            _direction.KeycodeUpIndex = (uint)DirectionVerticalAxisUpCmb.SelectedIndex;
                            _direction.VerticalInputMode = 2;
                            break;
                        case "DirectionHorizontalXCmb":
                            _direction.MouseXID = (uint)DirectionHorizontalXCmb.SelectedValue;
                            _direction.MouseXIndex = (uint)DirectionHorizontalXCmb.SelectedIndex;
                            _direction.HorizontalInputMode = 3;
                            break;
                        case "DirectionVerticalYCmb":
                            _direction.MouseYID = (uint)DirectionVerticalYCmb.SelectedValue;
                            _direction.MouseYIndex = (uint)DirectionVerticalYCmb.SelectedIndex;
                            _direction.VerticalInputMode = 3;
                            break;

                    }
                    break;
                case "TouchForm":
                    TouchForm _touch = (TouchForm)mCurrentComponent;

                    break;
            }
        }
        private void TouchJoyStickButtonCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mCurrentComponent == null)
                return;

            string _gestureID = TouchGestureIDCmb.Text;


            TouchForm _touch = (TouchForm)mCurrentComponent;
            Dictionary<string, uint> _gestureIDs = _touch.GestureIDs;

            BindingSource _bt = (BindingSource)TouchGestureIDCmb.DataSource;

            uint _joystickButtonID = (uint)TouchJoystickIDCmb.SelectedValue;

            if (_gestureIDs.ContainsKey(_gestureID))
            {
                if (_joystickButtonID == 0)
                    _gestureIDs.Remove(_gestureID);
                else
                    _gestureIDs[_gestureID] = (uint)_joystickButtonID;
            }
            else
            {
                if (_joystickButtonID > 0)
                {
                    _gestureIDs.Add(_gestureID, _joystickButtonID);

                }

            }

            _bt = (BindingSource)TouchGestureIDCmb.DataSource;
            if (_bt == null)
            {
                TouchGestureIDCmb.DataSource = new BindingSource(_gestureIDs, null);
                TouchGestureIDCmb.DisplayMember = "Key";
                TouchGestureIDCmb.ValueMember = "Value";
            }
            else
            {
                _bt.ResetBindings(false);
                TouchGestureIDCmb.Refresh();
            }
        }
        private void TouchGestureIDCmb_TextChanged(object sender, EventArgs e)
        {
            TouchForm _touch = (TouchForm)mCurrentComponent;
            _touch.Gesture = TouchGestureIDCmb.Text;
            _touch.GestureToTrackList();
        }
        private void TouchGestureIDCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int _item = (int)TouchGestureIDCmb.SelectedValue;
            ////int _index = Convert.ToInt32(_item.ToString());

            //TouchJoyStickButtonCmb.SelectedIndex = _item;
        }
        #endregion

        #region ToolBox code
        private void ButtonToolBtn_Click(object sender, EventArgs e)
        {
            toolButtonReset(TOOLTYPE.BUTTON, false);
        }

        private void ButtonToolBtn_DoubleClick(object sender, EventArgs e)
        {
            toolButtonReset(TOOLTYPE.BUTTON, true);

            ButtonForm _component = new ButtonForm();
            _component.setEditBox(this);
            setCurrentComponent(_component);
            mComponentList.Add(_component);
            _component.Location = new Point(0, 0);
            _component.Show();
        }

        private void MoveToolBtn_Click(object sender, EventArgs e)
        {
            toolButtonReset(TOOLTYPE.MOVE, false); 
        }

        private void MoveToolBtn_DoubleClick(object sender, EventArgs e)
        {
            toolButtonReset(TOOLTYPE.MOVE, true);

            MoveForm _component = new MoveForm();
            _component.setEditBox(this);
            setCurrentComponent(_component);
            mComponentList.Add(_component);
            _component.Location = new Point(0, 0);
            _component.Show();
        }

        private void DirectionToolBtn_Click(object sender, EventArgs e)
        {
            toolButtonReset(TOOLTYPE.DIRECTION, false); 
        }

        private void DirectionToolBtn_DoubleClick(object sender, EventArgs e)
        {
            toolButtonReset(TOOLTYPE.DIRECTION, true);

            DirectionForm _component = new DirectionForm();
            _component.setEditBox(this);
            setCurrentComponent(_component);
            mComponentList.Add(_component);
            _component.Location = new Point(0, 0);
            _component.Show();
        }

        private void TouchToolBtn_Click(object sender, EventArgs e)
        {
            toolButtonReset(TOOLTYPE.TOUCH, false); 
        }

        private void TouchToolBtn_DoubleClick(object sender, EventArgs e)
        {
            toolButtonReset(TOOLTYPE.TOUCH, true);

            TouchForm _component = new TouchForm();
            _component.setEditBox(this);
            setCurrentComponent(_component);
            mComponentList.Add(_component);
            _component.Location = new Point(0, 0);
            _component.Show();
        }

        private void toolButtonReset(TOOLTYPE mTool, bool visibleProperty)
        {
            mCurrentTool = mTool;

            ButtonToolBtn.BackColor     = System.Drawing.SystemColors.Control;
            MoveToolBtn.BackColor       = System.Drawing.SystemColors.Control;
            DirectionToolBtn.BackColor  = System.Drawing.SystemColors.Control;
            TouchToolBtn.BackColor      = System.Drawing.SystemColors.Control;

            ButtonPropertyPnl.Visible = false;
            MovePropertyPnl.Visible = false;
            DirectionPropertyPnl.Visible = false;
            TouchPropertyPnl.Visible = false;
            MinBtnPropertyPnl.Visible = false;

            switch (mTool)
            {
                case TOOLTYPE.BUTTON:
                    ButtonToolBtn.BackColor = System.Drawing.SystemColors.ControlDark;
                    ButtonPropertyPnl.Visible = true;
                    break;
                case TOOLTYPE.MOVE:
                    MoveToolBtn.BackColor = System.Drawing.SystemColors.ControlDark;
                    MovePropertyPnl.Visible = true;
                    break;
                case TOOLTYPE.DIRECTION:
                    DirectionToolBtn.BackColor = System.Drawing.SystemColors.ControlDark;
                    DirectionPropertyPnl.Visible = true;
                    break;
                case TOOLTYPE.TOUCH:
                    TouchToolBtn.BackColor = System.Drawing.SystemColors.ControlDark;
                    TouchPropertyPnl.Visible = true;
                    break;
                case TOOLTYPE.MINBUTTON:
                    MinBtnPropertyPnl.Visible = true;
                    break;
            }

            if (!visibleProperty)
            {
                ButtonPropertyPnl.Visible = false;
                MovePropertyPnl.Visible = false;
                DirectionPropertyPnl.Visible = false;
                TouchPropertyPnl.Visible = false;
                MinBtnPropertyPnl.Visible = false;
            }
        }
        
        private void AddBtn_Click(object sender, EventArgs e)
        {
            Form _component = null;
            switch (mCurrentTool)
            {
                case TOOLTYPE.BUTTON:
                    _component = new ButtonForm();
                    ((ButtonForm)_component).setEditBox(this);
                    setCurrentComponent(_component);
                    break;
                case TOOLTYPE.MOVE:
                    _component = new MoveForm();
                    ((MoveForm)_component).setEditBox(this);
                    setCurrentComponent(_component);
                    break;
                case TOOLTYPE.DIRECTION:
                    _component = new DirectionForm();
                    ((DirectionForm)_component).setEditBox(this);
                    setCurrentComponent(_component);
                    break;
                case TOOLTYPE.TOUCH:
                    _component = new TouchForm();
                    ((TouchForm)_component).setEditBox(this);
                    setCurrentComponent(_component);
                    break;
            }
            
            mComponentList.Add(_component);

            _component.Location = new Point(0, 0);
            _component.Show();

        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if (mComponentList.Count == 0)
                return;

            for (int i=0;i<mComponentList.Count();i++)
            {
                if(mComponentList[i].Equals(mCurrentComponent))
                {
                    mCurrentComponent.Close();
                    if (i == 0)
                    {
                        if(mComponentList.Count > 0)
                        {
                            mComponentList.RemoveAt(i);
                            if (mComponentList.Count == 0)
                            {
                                mCurrentComponent = mMinButton;
                                RemoveBtn.Enabled = false;
                            }
                            else
                                setCurrentComponent(mComponentList[0]);
                        }
                    }
                    else
                    {
                        setCurrentComponent(mComponentList[i - 1]);
                        mComponentList.RemoveAt(i);
                    }
                    break;
                }
            }

        }

        #endregion

        private bool saveController()
        {
            if (mComponentList.Count == 0 && mMinButton==null)
                return true;

            if (ControllerNameCmb.Text.Trim() == "")
            {
                MessageBox.Show("Please insert controller name.", "warning");
                return false;
            }
            
            XmlTextWriter _xmlWriter = new XmlTextWriter("./controllers/" + ControllerNameCmb.Text + ".xml", System.Text.Encoding.UTF8);
            _xmlWriter.WriteStartDocument(true);
            _xmlWriter.Formatting = Formatting.Indented;
            _xmlWriter.Indentation = 2;
            _xmlWriter.WriteStartElement("Controller");
            _xmlWriter.WriteStartElement("Name");
            _xmlWriter.WriteString(ControllerNameCmb.Text);
            _xmlWriter.WriteEndElement();
            if(mMinButton != null)
            {
                MinimizeButtonForm _minBtn = (MinimizeButtonForm)mMinButton;
                _xmlWriter.WriteStartElement("minBtn");
                    _xmlWriter.WriteStartElement("XValue"); _xmlWriter.WriteString(_minBtn.XValue.ToString()); _xmlWriter.WriteEndElement();
                    _xmlWriter.WriteStartElement("YValue"); _xmlWriter.WriteString(_minBtn.YValue.ToString()); _xmlWriter.WriteEndElement();
                    _xmlWriter.WriteStartElement("WidthValue"); _xmlWriter.WriteString(_minBtn.WidthValue.ToString()); _xmlWriter.WriteEndElement();
                    _xmlWriter.WriteStartElement("HeightValue"); _xmlWriter.WriteString(_minBtn.HeightValue.ToString()); _xmlWriter.WriteEndElement();
                    _xmlWriter.WriteStartElement("BackColorValue"); _xmlWriter.WriteValue(_minBtn.BackColorValue.ToArgb()); _xmlWriter.WriteEndElement();
                    _xmlWriter.WriteStartElement("BorderColorValue"); _xmlWriter.WriteValue(_minBtn.BorderColorValue.ToArgb()); _xmlWriter.WriteEndElement();
                    _xmlWriter.WriteStartElement("OpacityValue"); _xmlWriter.WriteValue(_minBtn.OpacityValue.ToString()); _xmlWriter.WriteEndElement();
                _xmlWriter.WriteEndElement();
            }
            
            _xmlWriter.WriteStartElement("MSensitive");
                _xmlWriter.WriteStartElement("Value"); _xmlWriter.WriteString(MouseSensitiveNud.Value.ToString()); _xmlWriter.WriteEndElement();
            _xmlWriter.WriteEndElement();

            foreach (Form _component in mComponentList)
            {
                switch (_component.Name)
                {
                    case "ButtonForm":
                        ButtonForm _button = (ButtonForm)_component;
                        _xmlWriter.WriteStartElement("Button");
                        _xmlWriter.WriteStartElement("XValue"); _xmlWriter.WriteString(_button.XValue.ToString()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("YValue"); _xmlWriter.WriteString(_button.YValue.ToString()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("WidthValue"); _xmlWriter.WriteString(_button.WidthValue.ToString()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("HeightValue"); _xmlWriter.WriteString(_button.HeightValue.ToString()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("TextValue"); _xmlWriter.WriteString(_button.TextValue.ToString()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("BackColorValue"); _xmlWriter.WriteValue(_button.BackColorValue.ToArgb()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("ForeColorValue"); _xmlWriter.WriteValue(_button.ForeColorValue.ToArgb()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("OpacityValue"); _xmlWriter.WriteValue(_button.OpacityValue.ToString()); _xmlWriter.WriteEndElement();

                        _xmlWriter.WriteStartElement("InputMode"); _xmlWriter.WriteValue(_button.InputMode); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("JoystickType"); _xmlWriter.WriteValue((uint)_button.JoystickType); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("KeyboardType"); _xmlWriter.WriteValue((uint)_button.KeyboardType); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("JoystickBtnName"); _xmlWriter.WriteValue(_button.JoystickBtnIndex); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("JoystickBtnID"); _xmlWriter.WriteValue(_button.JoystickBtnID); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("KeycodeBtnName"); _xmlWriter.WriteValue(_button.KeycodeBtnIndex); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("KeycodeBtnID"); _xmlWriter.WriteValue(_button.KeycodeBtnID); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteEndElement();

                        //ButtonJoyStickButtonCmb.SelectedIndex = (int)_button.JoyStickBtnID;
                        break;
                }
            }

            foreach (Form _component in mComponentList)
            {
                switch (_component.Name)
                {
                    case "MoveForm":
                        MoveForm _move = (MoveForm)_component;
                        _xmlWriter.WriteStartElement("Move");
                        _xmlWriter.WriteStartElement("XValue"); _xmlWriter.WriteString(_move.XValue.ToString()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("YValue"); _xmlWriter.WriteString(_move.YValue.ToString()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("WidthValue"); _xmlWriter.WriteString(_move.WidthValue.ToString()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("HeightValue"); _xmlWriter.WriteString(_move.HeightValue.ToString()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("BackColorValue"); _xmlWriter.WriteValue(_move.BackColorValue.ToArgb()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("ForeColorValue"); _xmlWriter.WriteValue(_move.ForeColorValue.ToArgb()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("OpacityValue"); _xmlWriter.WriteValue(_move.OpacityValue.ToString()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("MovingColorValue"); _xmlWriter.WriteValue(_move.MovingColorValue.ToArgb()); _xmlWriter.WriteEndElement();

                        _xmlWriter.WriteStartElement("HorizontalInputMode"); _xmlWriter.WriteValue(_move.HorizontalInputMode); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("VerticalInputMode"); _xmlWriter.WriteValue(_move.VerticalInputMode); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("HorizontalAxisName"); _xmlWriter.WriteValue(_move.HorizontalAxisIndex); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("HorizontalAxisID"); _xmlWriter.WriteValue(_move.HorizontalAxisID); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("VerticalAxisName"); _xmlWriter.WriteValue(_move.VerticalAxisIndex); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("VerticalAxisID"); _xmlWriter.WriteValue(_move.VerticalAxisID); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("KeycodeLeftName"); _xmlWriter.WriteValue(_move.KeycodeLeftIndex); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("KeycodeLeftID"); _xmlWriter.WriteValue(_move.KeycodeLeftID); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("KeycodeRightName"); _xmlWriter.WriteValue(_move.KeycodeRightIndex); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("KeycodeRightID"); _xmlWriter.WriteValue(_move.KeycodeRightID); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("KeycodeUpName"); _xmlWriter.WriteValue(_move.KeycodeUpIndex); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("KeycodeUpID"); _xmlWriter.WriteValue(_move.KeycodeUpID); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("KeycodeDownName"); _xmlWriter.WriteValue(_move.KeycodeDownIndex); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("KeycodeDownID"); _xmlWriter.WriteValue(_move.KeycodeDownID); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("MouseXName"); _xmlWriter.WriteValue(_move.MouseXIndex); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("MouseXID"); _xmlWriter.WriteValue(_move.MouseXID); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("MouseYName"); _xmlWriter.WriteValue(_move.MouseYIndex); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("MouseYID"); _xmlWriter.WriteValue(_move.MouseYID); _xmlWriter.WriteEndElement();

                        _xmlWriter.WriteEndElement();
                        //ButtonJoyStickButtonCmb.SelectedIndex = (int)_button.JoyStickBtnID;
                        break;
                    case "DirectionForm":
                        DirectionForm _direction = (DirectionForm)_component;
                        _xmlWriter.WriteStartElement("Direction");
                        _xmlWriter.WriteStartElement("XValue"); _xmlWriter.WriteString(_direction.XValue.ToString()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("YValue"); _xmlWriter.WriteString(_direction.YValue.ToString()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("WidthValue"); _xmlWriter.WriteString(_direction.WidthValue.ToString()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("HeightValue"); _xmlWriter.WriteString(_direction.HeightValue.ToString()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("BackColorValue"); _xmlWriter.WriteValue(_direction.BackColorValue.ToArgb()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("OpacityValue"); _xmlWriter.WriteValue(_direction.OpacityValue.ToString()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("MovingColorValue"); _xmlWriter.WriteValue(_direction.MovingColorValue.ToArgb()); _xmlWriter.WriteEndElement();

                        _xmlWriter.WriteStartElement("HorizontalInputMode"); _xmlWriter.WriteValue(_direction.HorizontalInputMode); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("VerticalInputMode"); _xmlWriter.WriteValue(_direction.VerticalInputMode); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("HorizontalAxisName"); _xmlWriter.WriteValue(_direction.HorizontalAxisIndex); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("HorizontalAxisID"); _xmlWriter.WriteValue(_direction.HorizontalAxisID); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("VerticalAxisName"); _xmlWriter.WriteValue(_direction.VerticalAxisIndex); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("VerticalAxisID"); _xmlWriter.WriteValue(_direction.VerticalAxisID); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("KeycodeLeftName"); _xmlWriter.WriteValue(_direction.KeycodeLeftIndex); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("KeycodeLeftID"); _xmlWriter.WriteValue(_direction.KeycodeLeftID); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("KeycodeRightName"); _xmlWriter.WriteValue(_direction.KeycodeRightIndex); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("KeycodeRightID"); _xmlWriter.WriteValue(_direction.KeycodeRightID); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("KeycodeUpName"); _xmlWriter.WriteValue(_direction.KeycodeUpIndex); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("KeycodeUpID"); _xmlWriter.WriteValue(_direction.KeycodeUpID); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("KeycodeDownName"); _xmlWriter.WriteValue(_direction.KeycodeDownIndex); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("KeycodeDownID"); _xmlWriter.WriteValue(_direction.KeycodeDownID); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("MouseXName"); _xmlWriter.WriteValue(_direction.MouseXIndex); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("MouseXID"); _xmlWriter.WriteValue(_direction.MouseXID); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("MouseYName"); _xmlWriter.WriteValue(_direction.MouseYIndex); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("MouseYID"); _xmlWriter.WriteValue(_direction.MouseYID); _xmlWriter.WriteEndElement();

                        _xmlWriter.WriteStartElement("NeutualReleaseMouse"); _xmlWriter.WriteValue(_direction.NeutualReleaseMouse.ToString()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("NeutualDoubleClick"); _xmlWriter.WriteValue(_direction.NeutualDoubleClick.ToString()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteEndElement();
                        //ButtonJoyStickButtonCmb.SelectedIndex = (int)_button.JoyStickBtnID;
                        break;
                    case "TouchForm":
                        TouchForm _touch = (TouchForm)_component;
                        _xmlWriter.WriteStartElement("Touch");
                        _xmlWriter.WriteStartElement("XValue"); _xmlWriter.WriteString(_touch.XValue.ToString()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("YValue"); _xmlWriter.WriteString(_touch.YValue.ToString()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("WidthValue"); _xmlWriter.WriteString(_touch.WidthValue.ToString()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("HeightValue"); _xmlWriter.WriteString(_touch.HeightValue.ToString()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("BackColorValue"); _xmlWriter.WriteValue(_touch.BackColorValue.ToArgb()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("ForeColorValue"); _xmlWriter.WriteValue(_touch.ForeColorValue.ToArgb()); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteStartElement("OpacityValue"); _xmlWriter.WriteValue(_touch.OpacityValue.ToString()); _xmlWriter.WriteEndElement();

                        string _gestureIDs = "";
                        foreach (string _key in _touch.GestureIDs.Keys)
                        {
                            _gestureIDs += (_key + "," + _touch.GestureIDs[_key]) + ":";
                        }
                        _xmlWriter.WriteStartElement("GestureIDs"); _xmlWriter.WriteValue(_gestureIDs); _xmlWriter.WriteEndElement();
                        _xmlWriter.WriteEndElement();
                        //TouchJoyStickButtonCmb.SelectedIndex = (int)_touch.JoyStickBtnID;
                        break;
                }
            }

            _xmlWriter.WriteEndElement();
            _xmlWriter.WriteEndDocument();
            _xmlWriter.Close();

            if(mMinButton != null)
            {
                mMinButton.Close();
                MinimizeBtnChk.Checked = false;
                mMinButton = null;
            }

            foreach (Form _component in mComponentList)
                _component.Close();
            mComponentList.Clear();

            ControllerNameCmb.Text = "";

            MessageBox.Show("successful saved.", "information");

            return true;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            saveController();
        }

        #region load controller
        private void loadButtonComponent(XmlTextReader xmlReader)
        {
            ButtonForm _component = new ButtonForm();
            _component.setEditBox(this);
            _component.Show();

            mComponentList.Add(_component);

            string _currentTagName = "";
            while (xmlReader.Read())
            {
                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        _currentTagName = xmlReader.Name;
                        break;
                    case XmlNodeType.Text:
                        if (_currentTagName == "XValue")
                        {
                            _component.XValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "YValue")
                        {
                            _component.YValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "WidthValue")
                        {
                            _component.WidthValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "HeightValue")
                        {
                            _component.HeightValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "TextValue")
                        {
                            _component.TextValue = xmlReader.Value;
                        }
                        else if (_currentTagName == "BackColorValue")
                        {
                            _component.BackColorValue = Color.FromArgb(Convert.ToInt32(xmlReader.Value));
                        }
                        else if (_currentTagName == "ForeColorValue")
                        {
                            _component.ForeColorValue = Color.FromArgb(Convert.ToInt32(xmlReader.Value));
                        }
                        else if (_currentTagName == "OpacityValue")
                        {
                            _component.OpacityValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "InputMode")
                        {
                            _component.InputMode = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "JoystickType")
                        {
                            _component.JoystickType = (MainController.JOYSTICK_BUTTON_TYPE)Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "KeyboardType")
                        {
                            _component.KeyboardType = (MainController.KEYBOARD_BUTTON_TYPE)Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "JoystickBtnName")
                        {
                            _component.JoystickBtnIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "JoystickBtnID")
                        {
                            _component.JoystickBtnID = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "KeycodeBtnName")
                        {
                            _component.KeycodeBtnIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "KeycodeBtnID")
                        {
                            _component.KeycodeBtnID = Convert.ToUInt32(xmlReader.Value);
                        }

                        break;
                    case XmlNodeType.EndElement:
                        _currentTagName = "";
                        if (xmlReader.Name == "Button")
                        {
                            //_component.setJoystick(mJoystickHandler, mJoystickId);
                            return;
                        }
                        break;
                }
            }

        }

        private void loadMoveComponent(XmlTextReader xmlReader)
        {
            MoveForm _component = new MoveForm();
            _component.setEditBox(this);
            _component.Show();

            mComponentList.Add(_component);

            string _currentTagName = "";
            while (xmlReader.Read())
            {
                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        _currentTagName = xmlReader.Name;
                        break;
                    case XmlNodeType.Text:
                        if (_currentTagName == "MouseXName")
                        {
                            _component.MouseXIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "MouseXID")
                        {
                            _component.MouseXID = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "MouseYName")
                        {
                            _component.MouseYIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "MouseYID")
                        {
                            _component.MouseYID = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "XValue")
                        {
                            _component.XValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "YValue")
                        {
                            _component.YValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "WidthValue")
                        {
                            _component.WidthValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "HeightValue")
                        {
                            _component.HeightValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "BackColorValue")
                        {
                            _component.BackColorValue = Color.FromArgb(Convert.ToInt32(xmlReader.Value));
                        }
                        else if (_currentTagName == "ForeColorValue")
                        {
                            _component.ForeColorValue = Color.FromArgb(Convert.ToInt32(xmlReader.Value));
                        }
                        else if (_currentTagName == "MovingColorValue")
                        {
                            _component.MovingColorValue = Color.FromArgb(Convert.ToInt32(xmlReader.Value));
                        }
                        else if (_currentTagName == "OpacityValue")
                        {
                            _component.OpacityValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "HorizontalInputMode")
                        {
                            _component.HorizontalInputMode = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "VerticalInputMode")
                        {
                            _component.VerticalInputMode = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "HorizontalAxisName")
                        {
                            _component.HorizontalAxisIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "HorizontalAxisID")
                        {
                            _component.HorizontalAxisID = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "VerticalAxisName")
                        {
                            _component.VerticalAxisIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "VerticalAxisID")
                        {
                            _component.VerticalAxisID = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "KeycodeLeftName")
                        {
                            _component.KeycodeLeftIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "KeycodeLeftID")
                        {
                            _component.KeycodeLeftID = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "KeycodeRightName")
                        {
                            _component.KeycodeRightIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "KeycodeRightID")
                        {
                            _component.KeycodeRightID = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "KeycodeUpName")
                        {
                            _component.KeycodeUpIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "KeycodeUpID")
                        {
                            _component.KeycodeUpID = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "KeycodeDownName")
                        {
                            _component.KeycodeDownIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "KeycodeDownID")
                        {
                            _component.KeycodeDownID = Convert.ToUInt32(xmlReader.Value);
                        }
                        break;
                    case XmlNodeType.EndElement:
                        if (xmlReader.Name == "Move")
                        {
                            //_component.setJoystick(mJoystickHandler, mJoystickId);
                            return;
                        }
                        break;
                }
            }
        }

        private void loadDirectionComponent(XmlTextReader xmlReader)
        {
            DirectionForm _component = new DirectionForm();
            _component.setEditBox(this);
            _component.Show();

            mComponentList.Add(_component);

            string _currentTagName = "";
            while (xmlReader.Read())
            {
                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        _currentTagName = xmlReader.Name;
                        break;
                    case XmlNodeType.Text:
                        if (_currentTagName == "MouseXName")
                        {
                            _component.MouseXIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "MouseXID")
                        {
                            _component.MouseXID = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "MouseYName")
                        {
                            _component.MouseYIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "MouseYID")
                        {
                            _component.MouseYID = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "XValue")
                        {
                            _component.XValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "YValue")
                        {
                            _component.YValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "WidthValue")
                        {
                            _component.WidthValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "HeightValue")
                        {
                            _component.HeightValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "BackColorValue")
                        {
                            _component.BackColorValue = Color.FromArgb(Convert.ToInt32(xmlReader.Value));
                        }
                        else if (_currentTagName == "OpacityValue")
                        {
                            _component.OpacityValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "MovingColorValue")
                        {
                            _component.MovingColorValue = Color.FromArgb(Convert.ToInt32(xmlReader.Value));
                        }
                        else if (_currentTagName == "HorizontalInputMode")
                        {
                            _component.HorizontalInputMode = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "VerticalInputMode")
                        {
                            _component.VerticalInputMode = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "HorizontalAxisName")
                        {
                            _component.HorizontalAxisIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "HorizontalAxisID")
                        {
                            _component.HorizontalAxisID = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "VerticalAxisName")
                        {
                            _component.VerticalAxisIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "VerticalAxisID")
                        {
                            _component.VerticalAxisID = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "KeycodeLeftName")
                        {
                            _component.KeycodeLeftIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "KeycodeLeftID")
                        {
                            _component.KeycodeLeftID = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "KeycodeRightName")
                        {
                            _component.KeycodeRightIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "KeycodeRightID")
                        {
                            _component.KeycodeRightID = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "KeycodeUpName")
                        {
                            _component.KeycodeUpIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "KeycodeUpID")
                        {
                            _component.KeycodeUpID = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "KeycodeDownName")
                        {
                            _component.KeycodeDownIndex = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "KeycodeDownID")
                        {
                            _component.KeycodeDownID = Convert.ToUInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "NeutualReleaseMouse")
                        {
                            _component.NeutualReleaseMouse = Convert.ToBoolean(xmlReader.Value);
                        }
                        else if (_currentTagName == "NeutualDoubleClick")
                        {
                            _component.NeutualDoubleClick = Convert.ToBoolean(xmlReader.Value);
                        }
                        break;
                    case XmlNodeType.EndElement:
                        if (xmlReader.Name == "Direction")
                        {
                            //_component.setJoystick(mJoystickHandler, mJoystickId);
                            return;
                        }
                        break;
                }
            }
        }

        private void loadTouchComponent(XmlTextReader xmlReader)
        {
            TouchForm _component = new TouchForm();
            _component.setEditBox(this);
            _component.Show();

            mComponentList.Add(_component);

            string _currentTagName = "";
            while (xmlReader.Read())
            {
                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        _currentTagName = xmlReader.Name;
                        break;
                    case XmlNodeType.Text:
                        if (_currentTagName == "XValue")
                        {
                            _component.XValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "YValue")
                        {
                            _component.YValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "WidthValue")
                        {
                            _component.WidthValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "HeightValue")
                        {
                            _component.HeightValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "BackColorValue")
                        {
                            _component.BackColorValue = Color.FromArgb(Convert.ToInt32(xmlReader.Value));
                        }
                        else if (_currentTagName == "ForeColorValue")
                        {
                            _component.ForeColorValue = Color.FromArgb(Convert.ToInt32(xmlReader.Value));
                        }
                        else if (_currentTagName == "OpacityValue")
                        {
                            _component.OpacityValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "GestureIDs")
                        {
                            Dictionary<string, uint> _gestureIDs = new Dictionary<string, uint>();
                            string[] _pairs = xmlReader.Value.Split(':');
                            foreach(string _pair in _pairs)
                            {
                                string[] _gesture = _pair.Split(',');
                                _gestureIDs.Add(_gesture[0], Convert.ToUInt32(_gesture[1]));
                            }
                        }
                        break;
                    case XmlNodeType.EndElement:
                        if (xmlReader.Name == "Touch")
                        {
                            //_component.setJoystick(mJoystickHandler, mJoystickId);
                            return;
                        }
                        break;
                }
            }
        }

        private void loadMinBtnComponent(XmlTextReader xmlReader)
        {
            MinimizeButtonForm _component = new MinimizeButtonForm(MinimizeButtonForm.COMPONENTMODE.EDIT_MODE);
            _component.setEditBox(this);
            _component.Show();

            mMinButton = _component;
            MinimizeBtnChk.Checked = true;

            string _currentTagName = "";
            while (xmlReader.Read())
            {
                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        _currentTagName = xmlReader.Name;
                        break;
                    case XmlNodeType.Text:
                        if (_currentTagName == "XValue")
                        {
                            _component.XValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "YValue")
                        {
                            _component.YValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "WidthValue")
                        {
                            _component.WidthValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "HeightValue")
                        {
                            _component.HeightValue = Convert.ToInt32(xmlReader.Value);
                        }
                        else if (_currentTagName == "BackColorValue")
                        {
                            _component.BackColorValue = Color.FromArgb(Convert.ToInt32(xmlReader.Value));
                        }
                        else if (_currentTagName == "BorderColorValue")
                        {
                            _component.BorderColorValue = Color.FromArgb(Convert.ToInt32(xmlReader.Value));
                        }
                        else if (_currentTagName == "OpacityValue")
                        {
                            _component.OpacityValue = Convert.ToInt32(xmlReader.Value);
                        }
                        break;
                    case XmlNodeType.EndElement:
                        if (xmlReader.Name == "minBtn")
                        {
                            //_component.setJoystick(mJoystickHandler, mJoystickId);
                            return;
                        }
                        break;
                }
            }
        }

        private void loadMouseSensitiveComponent(XmlTextReader xmlReader)
        {
            NumericUpDown _component = this.MouseSensitiveNud;

            string _currentTagName = "";
            while (xmlReader.Read())
            {
                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        _currentTagName = xmlReader.Name;
                        break;
                    case XmlNodeType.Text:
                        if (_currentTagName == "Value")
                        {
                            _component.Value = Convert.ToDecimal(xmlReader.Value);
                        }
                        break;
                    case XmlNodeType.EndElement:
                        if (xmlReader.Name == "MSensitive")
                        {
                            //_component.setJoystick(mJoystickHandler, mJoystickId);
                            return;
                        }
                        break;
                }
            }
        }
        #endregion

        private void closeAllComponent()
        {
            foreach (Form _component in mComponentList)
            {
                _component.Close();
                _component.Dispose();
            }
            if (mMinButton != null)
            {
                mMinButton.Close();
                mMinButton.Dispose();
            }
            
        }

        private void ControllerNameCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (ControllerNameCmb.Text.Trim() == "")
            {
                MessageBox.Show("Please select controller.", "warning");
                ControllerNameCmb.SelectedIndex = mCurrentController;
                return;
            }

            closeAllComponent();
            mComponentList.Clear();

            XmlTextReader _xmlReader = new XmlTextReader("./controllers/" + ControllerNameCmb.Text + ".xml");
            
            while (_xmlReader.Read())
            {
                switch (_xmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        if(_xmlReader.Name == "Button")
                        {
                            loadButtonComponent(_xmlReader);
                        }
                        else if(_xmlReader.Name == "Move")
                        {
                            loadMoveComponent(_xmlReader);
                        }
                        else if (_xmlReader.Name == "Direction")
                        {
                            loadDirectionComponent(_xmlReader);
                        }
                        else if (_xmlReader.Name == "Touch")
                        {
                            loadTouchComponent(_xmlReader);
                        }
                        else if (_xmlReader.Name == "minBtn")
                        {
                            loadMinBtnComponent(_xmlReader);
                        }
                        else if(_xmlReader.Name == "MSensitive")
                        {
                            loadMouseSensitiveComponent(_xmlReader);
                        }
                        break;
                    case XmlNodeType.Text:
                        if (_xmlReader.Name=="Name" && _xmlReader.Value != ControllerNameCmb.Text)
                        {
                            MessageBox.Show("Loading controller failed.", "error");
                            return;
                        }
                        break;
                    case XmlNodeType.EndElement:
                        break;
                }
            }

            _xmlReader.Close();
            foreach(Form _component in mComponentList)
            {
                switch (_component.Name)
                {
                    case "ButtonForm":
                        ((ButtonForm)_component).Sizeable = false;
                        break;
                    case "MoveForm":
                        ((MoveForm)_component).Sizeable = false;
                        break;
                    case "DirectionForm":
                        ((DirectionForm)_component).Sizeable = false;
                        break;
                    case "TouchForm":
                        ((TouchForm)_component).Sizeable = false;
                        break;
                    case "MinimizeButtonForm":
                        ((MinimizeButtonForm)_component).Sizeable = false;
                        break;
                }
            }
            if (mComponentList.Count > 0)
                setCurrentComponent(mComponentList[mComponentList.Count-1]);
            else if (mMinButton != null)
                setCurrentComponent(mMinButton);


        }

        private void EditBoxForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                mCurrentTool = TOOLTYPE.BUTTON;
                ButtonToolBtn.BackColor = System.Drawing.SystemColors.ControlDark;

                AddBtn.Enabled = true;
                mMain.loadCustomControllerMenu();

                this.ControllerNameCmb.Items.Clear();
                foreach (ToolStripMenuItem _component in mMain.mCustomControllerMenuList)
                {
                    this.ControllerNameCmb.Items.Add(_component.Text);
                }
            }
        }

        private void NewBtn_Click(object sender, EventArgs e)
        {
            saveController();
            closeAllComponent();
            mComponentList.Clear();

            ControllerNameCmb.Text = "";
        }

        private void MinimizeBtnChk_CheckedChanged(object sender, EventArgs e)
        {
            if( MinimizeBtnChk.Checked)
            {
                if (mMinButton != null)
                    return;
                toolButtonReset(TOOLTYPE.MINBUTTON, true);

                MinimizeButtonForm _component = new MinimizeButtonForm(MinimizeButtonForm.COMPONENTMODE.EDIT_MODE);
                _component.setEditBox(this);
                setCurrentComponent(_component);
                mMinButton = _component;
                _component.Location = new Point(50, 50);
                _component.Show();
            }
            else
            {
                mMinButton.Close();
                mMinButton.Dispose();
                mMinButton = null;
            }
        }
    }
}
