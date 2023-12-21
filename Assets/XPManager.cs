using UnityEngine;
using UnityEngine.UI;

public class XPManager : MonoBehaviour
{
    [SerializeField] Slider xpSlider;
    [SerializeField] GameObject player;
    private EntityState playerState;

    void Start()
    {
        if (player != null)
        {
            playerState = player.GetComponent<EntityState>();

            xpSlider.maxValue = playerState.MaxXp;
            xpSlider.value = playerState.CurrentXp;
        }
        else
        {
            Debug.Log("Player GameObject Not Assigned");
        }
    }

    private void Update()
    {
        xpSlider.value = playerState.CurrentXp;
    }
}