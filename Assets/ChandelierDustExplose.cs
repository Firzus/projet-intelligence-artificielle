using System.Collections;
using UnityEngine;

public class ChandelierDustExplose : MonoBehaviour
{
    private const float delay = 0.667f;
    void Start()
    {
        StartCoroutine(PlayAnimationAndDestroy());
    }

    IEnumerator PlayAnimationAndDestroy()
    {
        GetComponent<Animator>().Play("Chandelier_Dust_Explosion");

        // Attendre pendant un certain temps
        yield return new WaitForSeconds(delay);

        // Détruire l'objet
        Destroy(gameObject);
    }
}
