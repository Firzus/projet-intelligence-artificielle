using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] BoxCollider2D _boxIsTrigger;
    [SerializeField] GameObject _childCollider;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("a");
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Explosion"))
        {
            animator.SetBool("isDestroyed", true);
            _boxIsTrigger.enabled = false;
            Destroy(_childCollider);
        }
    }
}