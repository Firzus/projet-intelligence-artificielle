using System.Collections;
using UnityEngine;

public class RocketExplosion : MonoBehaviour
{
    [SerializeField] Animator animator;

    private const float delay = 1.250f;

    void Start()
    {
        StartCoroutine(PlayAnimationAndDestroy());
    }

    IEnumerator PlayAnimationAndDestroy()
    {
        animator.Play("Rocket_Explosion");


        // Attendre pendant un certain temps
        yield return new WaitForSeconds(delay);

        // D�truire l'objet
        Destroy(gameObject);
    }
}