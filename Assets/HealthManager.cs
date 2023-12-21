using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] Slider healthSlider;
    [SerializeField] GameObject player;
    private EntityState playerState;

    void Start()
    {
        if(player != null)
        {
            playerState = player.GetComponent<EntityState>();

            healthSlider.maxValue = playerState.MaxHp;
            healthSlider.value = playerState.CurrentHp;
        }
        else
        {
            Debug.Log("Player GameObject Not Assigned");
        }
    }

    private void Update()
    {
        healthSlider.value = playerState.CurrentHp;
    }
}