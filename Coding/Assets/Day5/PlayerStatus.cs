using TMPro;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] int maxHp = 50;
    int currentHp;
    float hpTimer = 0f;
    [SerializeField] TextMeshProUGUI hpText;

    [SerializeField] float hpDecreasePerSecond = 1f;

    void Start()
    {
        currentHp = maxHp;
    }

    void Update()
    {
        hpTimer += Time.deltaTime;
        if (hpTimer >= 1f)
        {
            currentHp -= Mathf.FloorToInt(hpDecreasePerSecond * hpTimer);
            currentHp = Mathf.Max(currentHp, 0);
            hpTimer = 0f;

            if (hpText != null)
            {
                hpText.text = $"HP: {currentHp}/{maxHp}";
            }
        }
    }

    public void Heal(int amount)
    {
        currentHp += amount;
        if (currentHp > maxHp) currentHp = maxHp;

        Debug.Log($"HP��: +{amount} => {currentHp}/{maxHp}");
    }

    // HP���[�����ǂ����̔���
    public bool IsDead()
    {
        return currentHp <= 0;
    }
}
