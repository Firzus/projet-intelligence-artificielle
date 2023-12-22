using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] BoxCollider2D _boxIsTrigger;
    [SerializeField] GameObject _childCollider;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Explosion") || collision.gameObject.CompareTag("Boss") || collision.gameObject.CompareTag("Enemy"))
        {
            animator.SetBool("isDestroyed", true);
            _boxIsTrigger.enabled = false;
            Destroy(_childCollider);
        }
    }
}