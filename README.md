# OpenJTalkForUnity
OpenJTalkをUnity上で使うためのプラグインです。
動的に文字列を読み上げさせることが出来ます。

<br>

## 検証環境
- Windows 10 20H2
- Unity Editor 2020.1.15f1

<br>

## 使い方
1. open_jtalk.7zを解凍して、C:\open_jtalkに配置します。

<img src="https://user-images.githubusercontent.com/33755507/129215445-fa0ad6cc-76d2-4993-915e-44cb423f6c09.png" width="500">

2. OpenJTalkForUnity.unitypackageをインポートします。

<img src="https://user-images.githubusercontent.com/33755507/129216066-e57e084a-2027-4d35-8f19-4ec0d4261dec.png" width="400">

3. Edit > Project Settings > Other Settings > Configuration > Api Compatibility Levelを「.NET 4.x」に変更します。
<img src="https://user-images.githubusercontent.com/33755507/129219061-f24d8638-56f9-405c-b91f-bc76951c6c4a.png" width="300">

4. プログラムを書きます。Assets/OpenJTalkForUnity/SampleSceneあたりを参考にしてください。

<br>

## Q&A
- 謎のエラーが出ます

アンマネージドDLLの不具合っぽいです。実使用に支障はありません。
![e1](https://user-images.githubusercontent.com/33755507/129216635-f21a0cfc-8ccc-4e49-bd61-496cdbf8f907.PNG)

<br>

- 違う声を使いたいです

C:\open_jtalk\voice に入っているhtsvoiceであれば使うことが出来ます。Speak()の第二引数で".htsvoice"の名前を**拡張子抜きで指定**します。

例：takumi_happy.htsvoice → OpenJTalkForUnity.Speak("今日は良い天気ですね。", "takumi_happy");

<br>

## 参照文献
[jtalkdll(GitHub)](https://github.com/rosmarinus/jtalkdll)
