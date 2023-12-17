using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] BoxCollider2D _boxCollider;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            animator.SetBool("isDestroyed", true);
            _boxCollider.isTrigger = true;
        }
    }
}