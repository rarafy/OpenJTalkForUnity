using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakVoiceSelected : MonoBehaviour
{
    [SerializeField] string text = "おはようございます。今日は良い天気ですね。";
    [SerializeField] string voiceName = "tohoku-f01-sad";

    void Start()
    {
        OpenJTalk.Speak(text, voiceName);
    }
}
