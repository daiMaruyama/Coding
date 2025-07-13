using UnityEngine;

public class RainbowManager : MonoBehaviour
{
    private int _currentIndex = 0;
    private int _missCount = 0;
    private const int MaxMissCount = 5;

    public bool CanDestroy(RainbowColor color)
    {
        return (int)color == _currentIndex;
    }

    public void NotifyDestroyed(RainbowColor color)
    {
        if ((int)color == _currentIndex)
        {
            _currentIndex++;
            Debug.Log("�����I���� " + (RainbowColor)_currentIndex);
        }
    }

    public void OnMiss()
    {
        _missCount++;
        Debug.Log("�~�X�I�c�� " + (MaxMissCount - _missCount));

        if (_missCount >= MaxMissCount)
        {
            Debug.Log("�Q�[���I�[�o�[�I");
            // �����Ń��g���C�Ȃ�
        }
    }
}
