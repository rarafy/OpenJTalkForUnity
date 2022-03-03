# OpenJTalk For Unity
OpenJTalkをUnity上で使うためのプラグインです。
動的に文字を読み上げることが出来ます。

<br>

## 検証環境
- Windows 10 20H2
- Unity Editor 2020.3.12f1 (LTS)

<br>

## 使い方
1. [OpenJTalkForUnity.unitypackage](https://github.com/rarafy/OpenJTalkForUnity/releases/download/open_jtalk-1.11v3/OpenJTalkForUnity.unitypackage)をインポートします。

<img src="https://user-images.githubusercontent.com/33755507/129216066-e57e084a-2027-4d35-8f19-4ec0d4261dec.png" width="400">

2. Edit > Project Settings > Other Settings > Configuration > Api Compatibility Levelを「.NET 4.x」に変更します。
<img src="https://user-images.githubusercontent.com/33755507/129219061-f24d8638-56f9-405c-b91f-bc76951c6c4a.png" width="300">

3. プログラムを書きます。`Assets\OpenJTalkForUnity\Scene`を参考にしてください。

<br>

#### ※Package Managerを使いたい場合
Window>Package Manager で Add package from git URL...を選択し、```https://github.com/rarafy/OpenJTalkForUnity.git?path=_Project/Packages/OpenJTalkForUnity``` と入力してください。

![image](https://user-images.githubusercontent.com/33755507/156442876-af659d0e-be22-4c82-a972-10bd8c389b34.png)

__サンプルプログラムもインポートしましょう__。サンプルプログラムは```Assets/Samples/OpenJTalkForUnity/1.1.13/Sample```に配置されます。

<br><br>

## API
いくつかのAPIが用意されています。基本的には`Assets\OpenJTalkForUnity\Scene`を参考にしながら書いてみると良いと思います。
- `OpenJTalk.VoiceTypeInfo()`
：どの声が使えるかを調べ、Debug.Logとして出力します。
- `OpenJTalk.SpeakRandomVoice(string text, double speed=1.0)`
：ランダムな声で喋ります。
- `OpenJTalk.Speak(string text = "こんにちは", string VoiceName = "tohoku-f01-neutral", double speed = 1.0)`
：指定した声と速度で任意の文字列を読み上げます。
- `OpenJTalk.SpeakRandomVoiceStoppable(string text = "こんにちは", double speed = 1.0)`
：ランダムな声で喋ります。（Taskなので非同期処理です）
- `OpenJTalk.SpeakStoppable(string text = "こんにちは", string VoiceName = "tohoku-f01-neutral", double speed = 1.0)`
：指定した声と速度で任意の文字列を読み上げます。
- `OpenJTalk.StopSpeaking()`
：喋るのを途中でやめます。

<br>

## Q&A
- 謎のエラーが出ます

アンマネージドDLLの不具合っぽいです。実使用に支障はありません。<br>
どうしても気になる場合は該当のファイルを削除すると良いでしょう（Windowsネイティブの機能が使えなくなりますが実使用には影響ありません）。
![e1](https://user-images.githubusercontent.com/33755507/129216635-f21a0cfc-8ccc-4e49-bd61-496cdbf8f907.PNG)

<br>

- 違う音声を使いたい

Assets\OpenJTalkForUnity\dll\voice よりも下の階層に置かれたhtsvoiceであれば使うことが出来ます。Speak()の第二引数で名前を指定します。

例：takumi_happy.htsvoiceを使いたい場合

`
void Start(){
OpenJTalkForUnity.Speak("今日は良い天気ですね。", "takumi_happy");
}
`

<br>

- OpenJTalk、もっとパラメータあったよね？（高度）

`Assets\OpenJTalkForUnity\Scripts\OpenJTalk.cs`を編集することで、それらのパラメータを解禁できます。<br>
例えば、Speedパラメータを追加したい場合、`tts.SpeakAsync(text);`の前の行に`tts.Speed = 1.0;`を加えると良いでしょう。<br>
もちろん、最初の宣言部分を<br>
`JTalkTTS tts = new JTalkTTS { VoiceName = "tohoku-f01-neutral", Speed = 1.0 }`<br>
と書き換えることでも実現できます。

<br>

## 参照文献
[jtalkdll(GitHub)](https://github.com/rosmarinus/jtalkdll)
