using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryManagerDay3 : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
