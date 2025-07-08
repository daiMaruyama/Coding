using UnityEngine;
using UnityEngine.SceneManagement;

public class Star : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("�N���A�I");
            // �N���A�����B�����ł̓V�[�����ēǂݍ���
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}