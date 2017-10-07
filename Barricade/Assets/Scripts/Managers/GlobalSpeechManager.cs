// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests
{
    public class GlobalSpeechManager : MonoBehaviour, ISpeechHandler
    {

        public void ProcessVoice(string text)
        {
            switch (text.ToLower())
            {
                case "scan":
                    AppStateManager.Instance.Rescan();
                    break;
                case "connect":
                    AppStateManager.Instance.Connection();
                    break;
                case "start":
                    AppStateManager.Instance.StartGame();
                    break;
            }
        }


        public void OnSpeechKeywordRecognized(SpeechEventData eventData)
        {
            ProcessVoice(eventData.RecognizedText);
        }


    }
}