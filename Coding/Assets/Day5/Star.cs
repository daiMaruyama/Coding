using UnityEngine;
using UnityEngine.SceneManagement;

public class Star : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("クリア！");
            // クリア処理。ここではシーンを再読み込み
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}