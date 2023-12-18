using System.Collections;
using UnityEngine;

public class AnimationAndDestroy : MonoBehaviour
{
    //[SerializeField] Animator animator;

    private const float delay = 1.250f;

    void Start()
    {
        Debug.Log("explosion start");
        StartCoroutine(PlayAnimationAndDestroy());
    }

    IEnumerator PlayAnimationAndDestroy()
    {
        GetComponent<Animator>().Play("Rocket_Explosion");


        // Attendre pendant un certain temps
        yield return new WaitForSeconds(delay);

        // Détruire l'objet
        Destroy(gameObject);
    }
}