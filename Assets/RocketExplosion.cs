using System.Collections;
using UnityEngine;

public class RocketExplosion : MonoBehaviour
{
    [SerializeField] Animator animator;

    private const float delay = 1.250f;

    void Start()
    {
        CineMachineShake.Instance.ShakeCamera(10f, 0.7f);
        Debug.Log(CineMachineShake.Instance);
        StartCoroutine(PlayAnimationAndDestroy());
    }

    IEnumerator PlayAnimationAndDestroy()
    {

        animator.Play("Rocket_Explosion");

        // Attendre pendant un certain temps
        yield return new WaitForSeconds(delay);
        
        // Détruire l'objet
        Destroy(gameObject);
    }
}