using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] float duration = 3.0f;
    [SerializeField] Image background;

    private void Start()
    {
        StartCoroutine(ChangeValueOverTime(0, 80, duration));

        AudioManager.Instance.PlayMusic("MenuTheme");
        AudioManager.Instance.PlaycSFX("Torch");
    }

    public void StartGame()
    {
        GameManager.instance.LoadLevel();

        AudioManager.Instance.PlaycSFX("ClicSimple");
        AudioManager.Instance.musicSource.Stop();
    }

    public IEnumerator ChangeValueOverTime(float startValue, float endValue, float duration)
    {
        float time = 0;
        Color originalColor = background.color;
        Color.RGBToHSV(originalColor, out float H, out float S, out _);
        float V;
        while (time < duration)
        {
            V = Mathf.Lerp(startValue / 100f, endValue / 100f, time / duration);
            background.color = Color.HSVToRGB(H, S, V);
            time += Time.deltaTime;
            yield return null;
        }

        V = endValue / 100f;
        background.color = Color.HSVToRGB(H, S, V);
    }
}