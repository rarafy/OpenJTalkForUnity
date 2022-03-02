using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakRandomVoice : MonoBehaviour
{
    [Header("実行するたびに声が変わります")]
    [SerializeField] string text = "おはようございます。今日は良い天気ですね。";

    void Start()
    {
        OpenJTalk.SpeakRandomVoice(text);
    }
}
