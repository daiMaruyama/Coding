using System.Collections; // IEnumerator ���g������
using UnityEngine;
using UnityEngine.UI; // UI ���g������
using TMPro; // TMPro ���g������

public class SampleCoroutine : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _message;
    [SerializeField] Button startButton;
    [SerializeField] Button tapButton;
    [SerializeField] Button retryButton;
    Coroutine _coroutine = null; 
    float _startTime; //�J�n����
    bool _canTap = false; //Tap�̃C���^���N�V����

    public void StartTimer()
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(WaitAndStart());

            startButton.interactable = false; // Start��Tap���I���܂ŉ����Ȃ�false
        }
    }

    public void Tap()
    {
        if (_canTap == false) //�܂�����
        {
            _message.text = "Too early...";
        }
        else
        {
            float reactionTime = Time.time - _startTime; //�v�����v�[GO�T�C��
            _message.text = $"Reaction Time: {reactionTime:F2} seconds";
        }

        tapButton.interactable = false;
        _canTap = false;

        if (_coroutine != null)�@//�ꉞ�R���[�`���X�g�b�v
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }

        // Tap���I������̂�Start�{�^����������悤�ɖ߂�
        startButton.interactable = true;
    }

    IEnumerator WaitAndStart()
    {
        _message.text = "Ready..."; // Go!!�܂�Tap�{�^���͉�����
        tapButton.interactable = true;
        _canTap = false;

        float waitTime = Random.Range(0.5f, 5f); // wait
        yield return new WaitForSeconds(waitTime);

        _message.text = "Go!!";
        _startTime = Time.time;
        _canTap = true;
    }

}
