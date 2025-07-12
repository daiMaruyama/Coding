using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disk : MonoBehaviour
{
    public int Size { get; private set; }
    // public float Width => transform.localScale.x;
    public Pole CurrentPole;

    [SerializeField] private SpriteRenderer _renderer;

    private Color _originalColor;

    public void Initialize(int size, Pole pole, Color color)
    {
        Size = size;

        float width = Mathf.Lerp(1.6f, 0.6f, (float)(size - 1) / 9f);
        transform.localScale = new Vector3(width, 0.3f, 1f);

        _renderer.color = color;
        pole.Push(this);
    }

    public void SetPole(Pole pole)
    {
        CurrentPole = pole;
        transform.position = pole.GetTopPosition();
    }

    private void OnMouseDown()
    {
        Debug.Log($"Clicked Disk: {Size}");

        if (GameManager.Instance.CanSelectDisk(this))
        {
            Debug.Log("Disk selected!");
            GameManager.Instance.SelectDisk(this);
        }
    }

    public void Lift()
    {
        _originalColor = _renderer.color;

        Color faded = _originalColor;
        faded.a = 0.5f;
        _renderer.color = faded;
    }

    public void Drop()
    {
        _renderer.color = _originalColor;
    }
}
