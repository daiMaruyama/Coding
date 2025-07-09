using UnityEngine;
using DiscordRPC;
using DiscordRPC.Logging;

public class DiscordRPCController : MonoBehaviour
{
    public DiscordRpcClient client;

    void Start()
    {
        // 自分の Discord アプリの「Client ID」に置き換える
        client = new DiscordRpcClient("1392492210095652964");

        // ログ出力（任意）
        client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };

        // 接続
        client.Initialize();

        // 表示内容を設定
        client.SetPresence(new RichPresence()
        {
            Details = "Unityでゲーム開発中！",
            State = "シーン編集中",
            Assets = new Assets()
            {
                LargeImageKey = "logo",      // Discord Developer Portal で登録した画像名
                LargeImageText = "Unity"
            },
            Timestamps = Timestamps.Now
        });
    }

    void Update()
    {
        if (client != null)
        {
            client.Invoke();  // 毎フレーム呼ぶ必要あり
        }
    }

    void OnApplicationQuit()
    {
        if (client != null)
        {
            client.Dispose();
        }
    }
}
