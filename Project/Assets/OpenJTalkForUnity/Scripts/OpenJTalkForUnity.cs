using JTalkDll;
using System;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;
using System.Text.RegularExpressions;
using System.Text;
using System.Windows.Forms.Design;
using UnityEngine;


public class OpenJTalkForUnity
{
    /// <summary>
    /// ランダムな声で喋ります。引数にstringで喋らせたい文字列を与えてください。
    /// </summary>
    /// <param name="text">喋らせたい文字列</param>
    public static void SpeakRandomVoice(string text)
    {
        using (JTalkTTS tts = new JTalkTTS { })
        {
            tts.Voice = tts.Voices[new System.Random().Next(tts.Voices.Count)];
            tts.SpeakAsync(text);
            tts.WaitUntilDone();
        }
    }

    /// <summary>
    /// "tohoku-f01-neutral"で喋ります。引数にstringで喋らせたい文字列を与えてください。
    /// </summary>
    /// <param name="text">喋らせたい文字列</param>
    public static void Speak(string text)
    {
        using (JTalkTTS tts = new JTalkTTS { VoiceName = "tohoku-f01-neutral" })
        {
            tts.SpeakAsync(text);
            tts.WaitUntilDone();
        }
    }

    /// <summary>
    /// 任意のボイスで喋ります。引数に喋らせたい文字列とボイスの名前（tohoku-f01-neutral）を与えてください。
    /// ボイスは"C:\open_jtalk\voice"に格納されていることが前提です
    /// </summary>
    /// <param name="text">喋らせたい文字列</param>
    /// <param name="VoiceName">ボイスの名前</param>
    public static void Speak(string text, string VoiceName)
    {
        using (JTalkTTS tts = new JTalkTTS { VoiceName = VoiceName })
        {
            tts.SpeakAsync(text);
            tts.WaitUntilDone();
        }
    }


    private static JTalkTTS tts;
    private static CancellationTokenSource cancelToken;
    public static Task SpeakStoppable(string text, string VoiceName)
    {
        tts = new JTalkTTS { VoiceName = VoiceName };
        tts.SpeakAsync(text);

        cancelToken = new CancellationTokenSource();
        while (tts.IsSpeaking) cancelToken.Token.ThrowIfCancellationRequested();
        return null;
    }
    public static void StopSpeaking()
    {
        if (cancelToken != null) cancelToken.Cancel();
        if (tts.IsSpeaking) tts.Stop();
    }
}
