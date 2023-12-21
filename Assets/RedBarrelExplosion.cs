using System.Collections;
using UnityEngine;

public class RedBarrelExplosion : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject _explosion;
    [SerializeField] GameObject _explosionSong;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Explosion"))
        {
            GameObject song = Instantiate(_explosionSong, gameObject.transform.position, gameObject.transform.rotation);
            GameObject a = Instantiate(_explosion, gameObject.transform.position, gameObject.transform.rotation);
            a.transform.localScale = new Vector3(4,4,0);
            animator.SetBool("isDestroyed", true);
            CineMachineShake.Instance.ShakeCamera(10f, 0.5f);
            Destroy(gameObject);
        }
    }


}
