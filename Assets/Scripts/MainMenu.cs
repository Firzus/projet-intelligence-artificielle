using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Instance.PlayMusic("MenuTheme");
    }

    public void StartGame()
    {
        GameManager.instance.LoadScene("Level");

        AudioManager.Instance.PlaycSFX("ClicSimple");
        AudioManager.Instance.musicSource.Stop();
    }
}