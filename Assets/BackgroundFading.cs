using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeImageValue : MonoBehaviour
{
    [SerializeField] Image background;
    [SerializeField] float duration = 2.0f;

    void Start()
    {
        AudioManager.Instance.PlaycSFX("Torch");

        StartCoroutine(ChangeValueOverTime(0, 80, duration));
    }

    IEnumerator ChangeValueOverTime(float startValue, float endValue, float duration)
    {
        float time = 0;
        Color originalColor = background.color;
        Color.RGBToHSV(originalColor, out float H, out float S, out float V);

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
