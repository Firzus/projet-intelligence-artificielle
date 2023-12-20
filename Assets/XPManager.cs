using UnityEngine;
using UnityEngine.UI;

public class XPManager : MonoBehaviour
{
    [SerializeField] Slider xpSlider;
    private int currentXP = 0;
    private readonly int maxXP = 100;

    void Start()
    {
        xpSlider.maxValue = maxXP;
        xpSlider.value = currentXP;
    }

    public void AddXP(int amount)
    {
        currentXP += amount;
        currentXP = Mathf.Min(currentXP, maxXP);
        xpSlider.value = currentXP;
    }
}
