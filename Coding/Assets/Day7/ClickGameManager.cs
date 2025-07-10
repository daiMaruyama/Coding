using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class ClickGameManager : MonoBehaviour
{
    [SerializeField] PlayerByClick _player;
    [SerializeField] TextMeshProUGUI _messageText;
    [SerializeField] TextMeshProUGUI _timerText;
    [SerializeField] Button _startButton;
    [SerializeField] float _gameDuration = 10f;

    bool _gameStarted = false;
    float _timer;

    bool _canReset = true;

    void Start()
    {
        _startButton.onClick.AddListener(OnStartButtonClicked);
    }

    public void OnStartButtonClicked()
    {
        if (!_canReset) return;

        ResetGame();
        StartCoroutine(GameStartRoutine());

        // リセット受付を一旦停止して1秒後に再開
        StartCoroutine(ResetDelayCoroutine());
    }

    void ResetGame()
    {
        _player.ResetPlayer();       // プレイヤー位置＆距離リセット
        _timerText.text = "";        // タイマーリセット
        _messageText.text = "";      // メッセージクリア
        _messageText.alpha = 1f;     // 透明度リセット
    }

    IEnumerator GameStartRoutine()
    {
        _startButton.gameObject.SetActive(false);
        _messageText.text = "Ready...";
        yield return new WaitForSeconds(1f);

        _gameStarted = true;
        _player.EnableInput(true);

        StartCoroutine(ShowGoAndFade());

        _timer = _gameDuration;

        while (_timer > 0f)
        {
            _timer -= Time.deltaTime;
            _timerText.text = $"{_timer:F1}s";
            yield return null;
        }

        _gameStarted = false;
        _player.EnableInput(false);

        float best = PlayerPrefs.GetFloat("BestScore", 0f);
        if (_player.Distance > best)
        {
            best = _player.Distance;
            PlayerPrefs.SetFloat("BestScore", best);
            PlayerPrefs.Save();
        }

        _messageText.alpha = 1f;
        _messageText.text = $"result: {_player.Distance:F2} m\nBest: \n{best:F2} m";

        _startButton.gameObject.SetActive(true);
    }

    IEnumerator ShowGoAndFade()
    {
        _messageText.text = "Go!";
        _messageText.alpha = 1f;

        float duration = 1f;
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            _messageText.alpha = Mathf.Lerp(1f, 0f, time / duration);
            yield return null;
        }
    }

    IEnumerator ResetDelayCoroutine()
    {
        _canReset = false;
        yield return new WaitForSeconds(1f);
        _canReset = true;
    }
}
