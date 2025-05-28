# 「ぼ」
学校の課題に際し、C#の知識0から1週間でどれだけできるかを試したものです。  
コードプロパティは Programing_Ⅱ_Summer\Assets\Script
# 目的
Unityの基本的な操作、仕様の学習およびC#の基礎の習得
# 動画URL
その1 : https://drive.google.com/file/d/1fYrXyevwK5HsTkw9PYrw0g5Xz3y_RBEP/view?usp=drive_link  
その2 : https://drive.google.com/file/d/1zQQjNysCiE9gS_4aJ_YH8QO72LqOyV97/view?usp=drive_link
# 開発環境
| 要素 | 仕様 |
| :-- | :-- |
| ゲームエンジン | Unity 2022.3.45f1|
| 使用言語 | C# |
| OS | Windows 11 |
| CPU | Ryzen 7 7800x3D |
| GPU | RTX 4070 super |
| メモリ | 32GB |
| テキストエディタ | Visual Studio Code 1.100.2|
# 仕様
## 概要
キャラクターを操作して、カンペに従い行動する。  
向きによって発するセリフが違うことを用いてタスクをこなす。
## 動作
w,a,s,d : 移動  
space : セリフの発言
## 使用ライブラリ
System.Collections  
System.Collections.Generic  
System.Runtime.CompilerServices  
System.Threading.Tasks  
UnityEngine  
UnityEngine.SceneManagement  
DG.Tweening  
UnityEngine.UI  
## 工夫点
・transform や audioSource などゲーム開発において基本的な関数に加え、async(非同期処理)を用いて滑らかな動作、演出を実現した。  
・DOTweenによるより細かな調整が可能なアニメーション技術の基礎を使用した。  
・ProBuilderを用いて1枚の立方体用テクスチャからcubeの6面すべてに違うテクスチャを表示した(サイコロのイメージ)。  
# 反省点
知識0から1週間という期限上想定をすべて実装することは不可能と判断したため見た目上影響のない範囲のみの実装となった。
故に、見えない壁の実装やデバッグ機能などかなり致命的な点が多く実装できていない。  
また、非同期処理に対する理解も曖昧であるため、アルゴリズムが少々不明瞭である。
