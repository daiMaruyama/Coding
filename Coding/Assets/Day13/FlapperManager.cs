using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlapperManager : MonoBehaviour
{
    [SerializeField] GameObject _gameOverPanel;
    
    public void GameOver()
    { 
        _gameOverPanel.SetActive(true);
    }
}
