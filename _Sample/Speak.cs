using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speak : MonoBehaviour
{
    [SerializeField] string text = "おはようございます。今日は良い天気ですね。";

    void Start()
    {
        OpenJTalk.Speak(text);
    }
}
