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
            Debug.Log("正解！次は " + (RainbowColor)_currentIndex);
        }
    }

    public void OnMiss()
    {
        _missCount++;
        Debug.Log("ミス！残り " + (MaxMissCount - _missCount));

        if (_missCount >= MaxMissCount)
        {
            Debug.Log("ゲームオーバー！");
            // ここでリトライなど
        }
    }
}
