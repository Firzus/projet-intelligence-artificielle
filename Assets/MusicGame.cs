using UnityEngine;

public class MusicGame : MonoBehaviour
{
    public void Start()
    {
        if(AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayMusic("FightTheme");
        }
        else
        {
            Debug.LogWarning("AudioManager instance not found.");
        }
    }
}
