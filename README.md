![](https://img.shields.io/badge/openupm-v1.5.0-blue)
![](https://img.shields.io/github/v/release/rarafy/OpenJTalkForUnity?include_prereleases)
![](https://img.shields.io/github/release-date/rarafy/OpenJTalkForUnity)
![](https://img.shields.io/github/license/rarafy/OpenJTalkForUnity)
![](https://img.shields.io/badge/PRs-welcome-orange)
![](https://img.shields.io/badge/Unity%202018.3%20or%20later.x-supported-blue)
![](https://img.shields.io/badge/Unity%202019.x-supported-blue)
![](https://img.shields.io/badge/Unity%202020.x-supported-blue)
![](https://img.shields.io/github/downloads/rarafy/OpenJTalkForUnity/total)
![](https://img.shields.io/github/repo-size/rarafy/OpenJTalkForUnity)

# OpenJTalk For Unity
A plug-in for using OpenJTalk on Unity.<br>
It allows you to read out text dynamically.
- ReadMe(English)
- [ReadMe(日本語)](README_JP.md)

<br>

## Environment

The code is developed on following environments. Note that these are NOT minimum version requirements.

- Windows 10 20H2
- Unity Editor 2020.3.12f1 (LTS)

<br>

## How to use
1. Import [OpenJTalkForUnity.unitypackage](https://github.com/rarafy/OpenJTalkForUnity/releases/download/open_jtalk-1.11v3/OpenJTalkForUnity.unitypackage) to your project

<img src="https://user-images.githubusercontent.com/33755507/129216066-e57e084a-2027-4d35-8f19-4ec0d4261dec.png" width="400">

2. Set "Edit > Project Settings > Other Settings > Configuration > Api Compatibility Level" to ".NET 4.x"
<img src="https://user-images.githubusercontent.com/33755507/129219061-f24d8638-56f9-405c-b91f-bc76951c6c4a.png" width="300">

3. Write the program. Refer to `Assets\OpenJTalkForUnity\Scene`.

<br>

#### When you want to use Package Manager
In "Window>Package Manager", select "Add package from git URL...". Then type ```https://github.com/rarafy/OpenJTalkForUnity.git?path=_Project/Packages/OpenJTalkForUnity``` and press "Add".

![image](https://user-images.githubusercontent.com/33755507/156442876-af659d0e-be22-4c82-a972-10bd8c389b34.png)

__Let's also import the sample program__. The sample programs will be placed in ``Assets/Samples/OpenJTalkForUnity/1.1.13/Sample``.

<br><br>

## API
There are several APIs available. Basically, you should refer to `Assets\OpenJTalkForUnity\Scene` to write scripts.
- `OpenJTalk.VoiceTypeInfo()`
：Check which voices are available and output as Debug.Log.
- `OpenJTalk.SpeakRandomVoice(string text, double speed=1.0)`
：Speaks in a random voice.
- `OpenJTalk.Speak(string text = "Hello", string VoiceName = "tohoku-f01-neutral", double speed = 1.0)`
：Reads out an arbitrary string of text at a specified voice and speed.
- `OpenJTalk.SpeakRandomVoiceStoppable(string text = "Hello", double speed = 1.0)`
：It speaks in a random voice. (It's a Task, so it's asynchronous.)
- `OpenJTalk.SpeakStoppable(string text = "Hello", string VoiceName = "tohoku-f01-neutral", double speed = 1.0)`
：Reads out an arbitrary string of text at a specified voice and speed.
- `OpenJTalk.StopSpeaking()`
：Stop vocalizing midway.

<br>

## Q&A
- I'm getting a mysterious error.

It seems to be a problem with the unmanaged DLL. It does not interfere with actual use.<br>
If you are really concerned about this, you can delete the corresponding file (some advanced features will not be available).
![e1](https://user-images.githubusercontent.com/33755507/129216635-f21a0cfc-8ccc-4e49-bd61-496cdbf8f907.PNG)

<br>

- I want to use a different voice.

You can use any htsvoice that is placed in the hierarchy below Assets\OpenJTalkForUnity\dll\voice by specifying its name as the second argument of Speak().

Ex：When you want to use "takumi_happy.htsvoice"

`
void Start(){
OpenJTalkForUnity.Speak("Today is a nice day.", "takumi_happy");
}
`

<br>

- My app stops while reading out loud.

A feature called Asynchronous (Task) can be used to solve this problem. For example

```
void Start()
{
  Task.Run(() => OpenJTalk.Speak("Today is a nice day."));
}
```

↑ Using tasks in this way will prevent the application from stopping while it is running.

<br>

- Um, OpenJTalk, I think there were more parameters? (Advanced)

You can unlock those parameters by editing `Assets\OpenJTalkForUnity\Scripts\OpenJTalk.cs`.<br>
For example, if you want to add a Speed parameter, you can add `tts.Speed = 1.0;` to the line before `tts.SpeakAsync(text);`.<br>
Of course, you can also rewrite the first part of the declaration as<br>
`JTalkTTS tts = new JTalkTTS { VoiceName = "tohoku-f01-neutral", Speed = 1.0 }`.

<br>

## References
[jtalkdll(GitHub)](https://github.com/rosmarinus/jtalkdll)
