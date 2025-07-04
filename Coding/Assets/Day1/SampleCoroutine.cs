using System.Collections; // IEnumerator を使うため
using UnityEngine;
using UnityEngine.UI; // UI を使うため
using TMPro; // TMPro を使うため

public class SampleCoroutine : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _message;
    [SerializeField] Button startButton;
    [SerializeField] Button tapButton;
    [SerializeField] Button retryButton;
    Coroutine _coroutine = null; 
    float _startTime; //開始時間
    bool _canTap = false; //Tapのインタラクション

    public void StartTimer()
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(WaitAndStart());

            startButton.interactable = false; // StartはTapが終わるまで押せないfalse
        }
    }

    public void Tap()
    {
        if (_canTap == false) //まだだめ
        {
            _message.text = "Too early...";
        }
        else
        {
            float reactionTime = Time.time - _startTime; //計測合計ーGOサイン
            _message.text = $"Reaction Time: {reactionTime:F2} seconds";
        }

        tapButton.interactable = false;
        _canTap = false;

        if (_coroutine != null)　//一応コルーチンストップ
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }

        // Tapが終わったのでStartボタンを押せるように戻す
        startButton.interactable = true;
    }

    IEnumerator WaitAndStart()
    {
        _message.text = "Ready..."; // Go!!までTapボタンは押せる
        tapButton.interactable = true;
        _canTap = false;

        float waitTime = Random.Range(0.5f, 5f); // wait
        yield return new WaitForSeconds(waitTime);

        _message.text = "Go!!";
        _startTime = Time.time;
        _canTap = true;
    }

}
