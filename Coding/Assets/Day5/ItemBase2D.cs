using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class ItemBase2D : MonoBehaviour
{
    [SerializeField] AudioClip _sound = default;
    [SerializeField] ActivateTiming _whenActivated = ActivateTiming.Get;

    public abstract void Activate();

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        if (_sound)
        {
            AudioSource.PlayClipAtPoint(_sound, Camera.main.transform.position);
        }

        if (_whenActivated == ActivateTiming.Get)
        {
            Activate();
            Destroy(this.gameObject);
        }
        else if (_whenActivated == ActivateTiming.Use)
        {
            gameObject.SetActive(false);
            GetComponent<Collider2D>().enabled = false;

            // var player = collision.GetComponent<RoguePlayer>();
            var player = collision.GetComponentInParent<RoguePlayer>();
            if (player == null)
            {
                Debug.LogError("RoguePlayer‚ªŒ©‚Â‚©‚ç‚È‚¢");
            }
            else
            {
                Debug.Log("RoguePlayer‚ªŽæ“¾‚Å‚«‚½");
                player.GetItem(this);
            }
        }
    }

    protected enum ActivateTiming
    {
        Get,
        Use
    }
}
