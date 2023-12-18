using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] BoxCollider2D _boxCollider;

    private void Start()
    {
        if(_boxCollider == null && this.gameObject.GetComponent<BoxCollider2D>() != null)
        {
            _boxCollider = this.gameObject.GetComponent<BoxCollider2D>();
        }
        if (animator == null && this.gameObject.GetComponent<Animator>() != null)
        {
            animator = this.gameObject.GetComponent<Animator>();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            animator.SetBool("isDestroyed", true);
            _boxCollider.isTrigger = true;

        }
    }
}