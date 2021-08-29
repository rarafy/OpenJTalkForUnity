using JTalkDll;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using UnityEngine;

public class OpenJTalk
{
    // 参照-------------------------------------------------------------------------------------------------------------------
    private static JTalkTTS _tts = new JTalkTTS { VoiceName = "tohoku-f01-neutral" };
    /// <summary>
    /// インストールされている全てのボイスの種類を表示します。<br/><br/>
    /// ※ボイスは"Assets\OpenJTalkForUnity\dll\voice"に格納されているものを探しに行きます。
    /// </summary>
    public static void VoiceTypeInfo()
    {
        List<string> a = new List<string>();
        a.AddRange(_tts.Voices.Select(v => v.Name).ToList<string>());

        foreach (string item in a) Debug.Log(item);
    }


    // 発声（同期）-------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// ランダムな声で喋ります。引数にstringで喋らせたい文字列を与えてください。
    /// </summary>
    /// <param name="text">喋らせたい文字列</param>
    /// <param name="speed">読み上げ速度</param>
    public static void SpeakRandomVoice(string text, double speed = 1.0)
    {
        using (JTalkTTS tts = new JTalkTTS { })
        {
            tts.Voice = tts.Voices[new System.Random().Next(tts.Voices.Count)];//Voiceを設定
            tts.Speed = speed;//読み上げ速度を設定
            tts.SpeakAsync(text);
            tts.WaitUntilDone();
        }
    }

    /// <summary>
    /// 任意のボイスで喋ります。引数に喋らせたい文字列とボイスの名前（tohoku-f01-neutral）を与えてください。<br />
    /// 何も指定しない場合は"tohoku-f01-neutral"の声で「こんにちは」と話します<br /><br />
    /// ※ボイスは"Assets\OpenJTalkForUnity\dll\voice"に格納されている必要があります。
    /// </summary>
    /// <param name="text">喋らせたい文字列</param>
    /// <param name="VoiceName">ボイスの名前</param>
    /// <param name="speed">読み上げ速度</param>
    public static void Speak(string text = "こんにちは", string VoiceName = "tohoku-f01-neutral", double speed = 1.0)
    {
        using (JTalkTTS tts = new JTalkTTS { VoiceName = VoiceName })
        {
            tts.Speed = speed;//読み上げ速度を設定
            tts.SpeakAsync(text);
            tts.WaitUntilDone();
        }
    }


    // 発声（非同期）-------------------------------------------------------------------------------------------------------------------

    private static JTalkTTS tts;
    private static CancellationTokenSource cancelToken;
    /// <summary>
    /// ランダムな声で喋ります。引数にstringで喋らせたい文字列を与えてください。
    /// 特別な事情が無ければSpeakRandomVoice()よりもこちらを使うのが良いでしょう。
    /// </summary>
    /// <param name="text">喋らせたい文字列</param>
    /// <param name="speed">読み上げ速度</param>
    public static Task SpeakRandomVoiceStoppable(string text = "こんにちは", double speed = 1.0)
    {
        tts = new JTalkTTS { };
        tts.Voice = tts.Voices[new System.Random().Next(tts.Voices.Count)];//Voiceを設定
        tts.Speed = speed;//読み上げ速度を設定
        tts.SpeakAsync(text);

        cancelToken = new CancellationTokenSource();
        while (tts.IsSpeaking) cancelToken.Token.ThrowIfCancellationRequested();
        return null;
    }
    /// <summary>
    /// 何も指定しない場合は「こんにちは」と話します。<br/>
    /// 特別な事情が無ければSpeak()よりもこちらを使うのが良いでしょう。<br/><br/>
    /// ※ボイスはProjectの"Assets\OpenJTalkForUnity\dll\voice"に格納されていることが前提です
    /// </summary>
    /// <param name="text">喋らせたい文字列</param>
    /// <param name="VoiceName">ボイスの名前</param>
    /// <param name="speed">読み上げ速度</param>
    public static Task SpeakStoppable(string text = "こんにちは", string VoiceName = "tohoku-f01-neutral", double speed = 1.0)
    {
        tts = new JTalkTTS { VoiceName = VoiceName };
        tts.Speed = speed;//読み上げ速度を設定
        tts.SpeakAsync(text);

        cancelToken = new CancellationTokenSource();
        while (tts.IsSpeaking) cancelToken.Token.ThrowIfCancellationRequested();
        return null;
    }
    /// <summary>
    /// 発声を停止します。
    /// </summary>
    public static void StopSpeaking()
    {
        if (cancelToken != null) cancelToken.Cancel();
        if (tts.IsSpeaking) tts.Stop();
    }
}
