#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using DiscordRPC;

[InitializeOnLoad]
public static class DiscordEditor
{
    private static DiscordRpcClient _client;

    static DiscordEditor()
    {
        EditorApplication.update += Update;
        Initialize();
    }

    private static void Initialize()
    {
        _client = new DiscordRpcClient("1392492210095652964");

        _client.Initialize();

        _client.SetPresence(new RichPresence()
        {
            Details = "Unityプロジェクト開発中",
            State = "編集中",
            Assets = new Assets()
            {
                LargeImageKey = "logo",
                LargeImageText = "Unity Editor"
            },
            Timestamps = Timestamps.Now
        });
    }

    private static void Update()
    {
        _client?.Invoke();
    }
}
#endif
