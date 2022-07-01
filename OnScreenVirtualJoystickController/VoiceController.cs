/*******************************************************************************

INTEL CORPORATION PROPRIETARY INFORMATION
This software is supplied under the terms of a license agreement or nondisclosure
agreement with Intel Corporation and may not be copied or disclosed except in
accordance with the terms of that agreement
Copyright(c) 2013-2014 Intel Corporation. All Rights Reserved.

*******************************************************************************/
using System;
using vJoyInterfaceWrap;
using SendInput;
//using System.Windows.Forms;
using System.Speech.Recognition;
//using System.Windows;
//using System.Threading;
using System.Collections.Generic;

namespace OnScreenController
{
    public class VoiceController
    {
        Dictionary<string, uint[]> mJoystickBtnId;

        vJoy mJoystickHandler;
        //vJoy.JoystickState iReport;
        uint mJoystickId;

        // Create a new SpeechRecognitionEngine instance.
        SpeechRecognitionEngine mRecognizer;
        bool mEnable = false;
        public bool Enable
        {
            get
            {
                return mEnable;
            }
            set
            {
                mEnable = value;
            }
        }

        long maxvalX, maxvalY, maxvalZ, maxvalRX, maxvalRY;

        public VoiceController()
        {
            mRecognizer = new SpeechRecognitionEngine();
        }

        public void setJoystick(vJoy joystick, uint joystickId)
        {
            mJoystickHandler = joystick;
            mJoystickId = joystickId;
        }

        public void setJoystickParameter(long mX, long mY, long mZ, long mRX, long mRY)
        {
            maxvalX = mX;
            maxvalY = mY;
            maxvalZ = mZ;
            maxvalRX = mRX;
            maxvalRY = mRY;
        }
        
        public void initializeController()
        {
            mRecognizer.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(recognizer_SpeechDetected);
            mRecognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);
            mRecognizer.RecognizeCompleted += new EventHandler<RecognizeCompletedEventArgs>(recognizer_RecognizeCompleted);
        }

        public void setJoystickBtnId(Dictionary<string, uint[]> joystickbtnid)
        {
            mJoystickBtnId = joystickbtnid;
        }

        public bool StartController()
        {
            if (mJoystickBtnId.Count == 0)
                return false;

            try
            {
                // Create a simple grammar.
                Choices commands = new Choices();

                Dictionary<string, uint[]>.KeyCollection _keys = mJoystickBtnId.Keys;
                List<string> _commandList = new List<string>();
                foreach (string _key in _keys)
                {
                    _commandList.Add(_key);
                }
                commands.Add(_commandList.ToArray());
                // Create a GrammarBuilder object and append the Choices object.
                GrammarBuilder gb = new GrammarBuilder();
                gb.Append(commands);
                // Create the Grammar instance and load it into the speech recognition engine.
                Grammar g_Comamnds = new Grammar(gb);

                mRecognizer.LoadGrammarAsync(g_Comamnds);

                // Configure input to the speech recognizer.  
                this.mRecognizer.SetInputToDefaultAudioDevice();
                // Start asynchronous, continuous speech recognition.
                this.mRecognizer.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch
            {
                return false;
            }

            mRecognizer.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(recognizer_SpeechDetected);
            mRecognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);
            mRecognizer.RecognizeCompleted += new EventHandler<RecognizeCompletedEventArgs>(recognizer_RecognizeCompleted);

            return true;
        }
        
        public void StopController()
        {
            mRecognizer.SpeechDetected -= recognizer_SpeechDetected;
            mRecognizer.SpeechRecognized -= recognizer_SpeechRecognized;
            mRecognizer.RecognizeCompleted -= recognizer_RecognizeCompleted;
        }

        private void recognizer_SpeechDetected(object sender, SpeechDetectedEventArgs e)
        {
            // MessageBox.Show("Recognizing voice command...");
        }

        Dictionary<uint, bool> mOutputState = new Dictionary<uint, bool>();

        // Create a simple handler for the SpeechRecognized event.
        private void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            bool _res;
            // add code 
            float confidence = e.Result.Confidence;
            if (confidence < 0.3)
                return;

            string CommandHeard = e.Result.Text.ToLower();

            if (mJoystickBtnId.ContainsKey(CommandHeard))
            {
                uint _input = mJoystickBtnId[CommandHeard][0];
                uint _option = mJoystickBtnId[CommandHeard][1];
                uint _code = mJoystickBtnId[CommandHeard][2];

                if (!mOutputState.ContainsKey(_code))
                {
                    mOutputState[_code] = false;
                }

                if (_input == 0)
                {
                    switch (_option)
                    {
                        case (uint)MainController.JOYSTICK_BUTTON_TYPE.PRESS:
                            mOutputState[_code] = true;
                            mJoystickHandler.SetBtn(mOutputState[_code], mJoystickId, _code);
                            break;
                        case (uint)MainController.JOYSTICK_BUTTON_TYPE.RELEASE:
                            mOutputState[_code] = false;
                            mJoystickHandler.SetBtn(mOutputState[_code], mJoystickId, _code);
                            break;
                        case (uint)MainController.JOYSTICK_BUTTON_TYPE.CLICK:
                            mJoystickHandler.SetBtn(true, mJoystickId, _code);
                            System.Threading.Thread.Sleep(10);
                            mJoystickHandler.SetBtn(false, mJoystickId, _code);
                            break;
                        case (uint)MainController.JOYSTICK_BUTTON_TYPE.TOGGLE:
                            mOutputState[_code] = !mOutputState[_code];
                            mJoystickHandler.SetBtn(mOutputState[_code], mJoystickId, _code);
                            break;
                    }
                }
                else if (_input == 1)
                {
                    switch (_option)
                    {
                        case (uint)MainController.JOYSTICK_BUTTON_TYPE.PRESS:
                            mOutputState[_code] = true;
                            _res = SendKeyboardInput.PressKey(_code);
                            break;
                        case (uint)MainController.JOYSTICK_BUTTON_TYPE.RELEASE:
                            mOutputState[_code] = false;
                            _res = SendKeyboardInput.ReleaseKey(_code);
                            break;
                        case (uint)MainController.JOYSTICK_BUTTON_TYPE.CLICK:
                            mOutputState[_code] = true;
                            _res = SendKeyboardInput.PressKey(_code);
                            System.Threading.Thread.Sleep(10);
                            _res = SendKeyboardInput.ReleaseKey(_code);
                            break;
                        case (uint)MainController.JOYSTICK_BUTTON_TYPE.TOGGLE:
                            mOutputState[_code] = !mOutputState[_code];
                            if (mOutputState[_code])
                                _res = SendKeyboardInput.PressKey(_code);
                            else
                                _res = SendKeyboardInput.ReleaseKey(_code);
                            break;
                    }
                }
            }
        }

        private void recognizer_RecognizeCompleted(object sender, RecognizeCompletedEventArgs e)
        {
            mRecognizer.RecognizeAsync();
        }
    }
}
