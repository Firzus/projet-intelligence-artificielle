using System.Collections;
using UnityEngine;

public class ChandelierDustExplose : MonoBehaviour
{
    [SerializeField] Animator animator;

    private const float delay = 0.667f;

    void Start()
    {
        Debug.Log("explosion start");
        StartCoroutine(PlayAnimationAndDestroy());
    }

    IEnumerator PlayAnimationAndDestroy()
    {
        animator.Play("ChandelierDust_Explosion");

        // Attendre pendant un certain temps
        yield return new WaitForSeconds(delay);

        // Détruire l'objet
        Destroy(gameObject);
    }
}
