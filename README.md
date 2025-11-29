# 🧪 Coding Practice & Unity Prototypes

Unityの学習記録と、1日で実装可能な小規模なプロトタイプ（ワンメカニクス）をまとめたリポジトリです。
思いついたアイデアの検証や、特定の技術要素（Physics、AIなど）の理解を深めることを目的としています。

<p align="left">
  <img src="https://img.shields.io/badge/Unity-2022.3.6f1-000000?style=flat-square&logo=unity&logoColor=white" />
  <img src="https://img.shields.io/badge/C%23-Lang-239120?style=flat-square&logo=c-sharp&logoColor=white" />
</p>

---

## 📌 Projects List

これまでに実装したミニゲームやプロトタイプのログです。

| Date | Title | Key Tech / Topics | Description |
| :--- | :--- | :--- | :--- |
| 2025-07-13 | **🌈 虹ブロック崩し** | `Enum` `Camera Shake` | enumによる色管理と、インパクト時のカメラ演出の実装 |
| 2025-07-12 | **🗼 ハノイの塔** | `Algorithm` | 円盤の数から最短手数を計算するロジックの実装 |
| 2025-07-11 | **⚽ 2Dヘディング** | `Collider` `Physics2D` | 複数のコライダーを用いた判定制御の練習 |
| 2025-07-10 | **🚀 スペース連打ゲー** | `Input` `PlayerPrefs` | 連打回数に応じた移動と、最高記録の保存機能 |
| 2025-07-09 | **🏃 超簡易2Dアクション** | `Custom Physics` | 物理エンジンを使わない当たり判定と挙動制御の自作 |
| 2025-07-08 | **🏰 ローグライク風** | `Map Generation` | アルゴリズムなしで簡易的なランダムマップ生成を再現 |
| 2025-07-07 | **🏒 ホッケーゲーム** | `AI` `Input System` | 敵AIの追跡挙動とWASD移動の実装 |
| 2025-07-06 | **📉 斜方投射ゲーム** | `Physics` `Animation` | マウス入力に応じた物理挙動の視覚化 |
| 2025-07-05 | **❓ READMEクイズ** | `ScriptableObject` | データ管理にScriptableObjectを用いたクイズシステム |
| 2025-07-04 | **⚡ 反応速度ゲーム** | `Coroutine` `UI` | 非同期処理を用いたタイミング制御の練習 |

---

## 🔧 Environment

- **Unity**: `2022.3.6f1`
- **IDE**: Visual Studio 2022
- **VCS**: Git / GitHub

---

## 📂 Folder Structure

本リポジトリは以下のような構成で管理されています。

```text
root/
  ├── logs/           # 日々の詳細な作業ログ
  ├── ProjectName/    # 各Unityプロジェクトのソースコード
  └── README.md       # このファイル
