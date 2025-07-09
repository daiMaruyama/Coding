using UnityEngine;
using DiscordRPC;
using DiscordRPC.Logging;

public class DiscordRPCController : MonoBehaviour
{
    public DiscordRpcClient client;

    void Start()
    {
        // ������ Discord �A�v���́uClient ID�v�ɒu��������
        client = new DiscordRpcClient("1392492210095652964");

        // ���O�o�́i�C�Ӂj
        client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };

        // �ڑ�
        client.Initialize();

        // �\�����e��ݒ�
        client.SetPresence(new RichPresence()
        {
            Details = "Unity�ŃQ�[���J�����I",
            State = "�V�[���ҏW��",
            Assets = new Assets()
            {
                LargeImageKey = "logo",      // Discord Developer Portal �œo�^�����摜��
                LargeImageText = "Unity"
            },
            Timestamps = Timestamps.Now
        });
    }

    void Update()
    {
        if (client != null)
        {
            client.Invoke();  // ���t���[���ĂԕK�v����
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
