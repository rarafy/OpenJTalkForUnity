using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Stoppable : MonoBehaviour
{
    [SerializeField] string text = "おはようございます。今日は良い天気ですね。";
    [SerializeField] string voiceName = "tohoku-f01-happy";

    public void StartSpeaking()
    {
        Task task = Task.Run(() =>
        {
            return OpenJTalk.SpeakStoppable(text, voiceName);
        });
    }

    public void Stop()
    {
        OpenJTalk.StopSpeaking();
    }
}
