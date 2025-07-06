using UnityEngine;

public class Ball : MonoBehaviour
{
    private float _startX;
    private bool _hasLanded = false;

    public void SetStartX(float x)
    {
        _startX = x;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (_hasLanded) return;

        if (collision.gameObject.CompareTag("Ground"))
        {
            float landedX = transform.position.x;
            float distance = landedX - _startX;

            Debug.Log($" ”ò‹——£: {distance:F2} m");

            // ”ò‹——£•\¦‚ÌŒÄ‚Ño‚µ
            if (Distance.Instance != null)
            {
                Distance.Instance.Show(distance);
            }
            else
            {
                Debug.LogError("Distance.Instance ‚ª null ‚Å‚·I");
            }

            _hasLanded = true;
        }
    }
}
