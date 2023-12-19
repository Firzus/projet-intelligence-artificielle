using System.Collections;
using UnityEngine;

public class RedBarrelExplosion : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject _explosion;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Explosion"))
        {
            GameObject a = Instantiate(_explosion, gameObject.transform.position, gameObject.transform.rotation);
            a.transform.localScale = new Vector3(4,4,0);
            animator.SetBool("isDestroyed", true);
            Destroy(gameObject);
        }
    }


}
