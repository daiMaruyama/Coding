using UnityEngine;
using TMPro;

public class Distance : MonoBehaviour
{
    public static Distance Instance;

    [SerializeField] private TextMeshProUGUI _text;

    void Awake()
    {
        Instance = this;
        _text.text = ""; // ‰Šúó‘Ô‚Í”ñ•\¦
    }

    public void Show(float distance)
    {
        _text.text = $"Distance {distance:F2} m";
    }
}
