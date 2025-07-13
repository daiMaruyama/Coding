using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RainbowColor
{
    Red,
    Orange,
    Yellow,
    Green,
    Blue,
    Indigo,
    Violet
}

public class RainbowBlock : MonoBehaviour
{
    [SerializeField] private RainbowColor _color;
    [SerializeField] private RainbowManager _manager;

    public void OnHit()
    {
        if (_manager.CanDestroy(_color))
        {
            _manager.NotifyDestroyed(_color);
            Destroy(gameObject);
        }
        else
        {
            _manager.OnMiss(); //GameOver?
            Debug.Log("Miss");
        }
    }
}

