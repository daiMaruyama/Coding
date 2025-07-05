using System.Collections; // IEnumerator ���g������
using UnityEngine;
using UnityEngine.UI; // UI ���g������
using TMPro; // TMPro ���g������

public class SampleCoroutine : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _message;
    [SerializeField] Button _startButton;
    [SerializeField] Button _tapButton;
    // [SerializeField] Button retryButton;
    Coroutine _coroutine = null; 
    float _startTime; //GO�T�C��
    bool _canTap = false; //Tap�̃C���^���N�V����

    public void StartTimer()
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(WaitAndStart());

            _startButton.interactable = false; // Start��Tap���I���܂ŉ����Ȃ�false
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
            float reactionTime = Time.time - _startTime; //���������Ƃ��܂ł̍��v���� - GO�T�C��
            _message.text = $"Reaction Time: {reactionTime:F2} seconds";
        }

        _tapButton.interactable = false;
        _canTap = false;

        if (_coroutine != null)�@//�ꉞ�R���[�`���X�g�b�v
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }

        // Tap���I������̂�Start�{�^����������悤�ɖ߂�
        _startButton.interactable = true;
    }

    IEnumerator WaitAndStart()
    {
        _message.text = "Ready..."; // Go!!�܂�Tap�{�^���͉�����
        _tapButton.interactable = true;
        _canTap = false;

        float waitTime = Random.Range(0.5f, 5f); // wait
        yield return new WaitForSeconds(waitTime);

        _message.text = "Go!!";
        _startTime = Time.time;
        _canTap = true;
    }

}
