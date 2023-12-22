using UnityEngine;

public class OptionsGUI : MonoBehaviour
{
    [SerializeField] GameObject panel;

    private void Start()
    {
        panel.SetActive(false);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TooglePanel();

            GameManager.instance.PauseGame();
        }
    }

    public void TooglePanel()
    {
        if (panel.activeSelf)
        {
            panel.SetActive(false);
        }
        else
        {
            panel.SetActive(true);
        }
    }

    public void ReturnMenu()
    {
        AudioManager.Instance.musicSource.Stop();
        GameManager.instance.LoadMenu();
    }
}