using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public Sprite _intactSprite;
    public Sprite _destroySprite;
    private SpriteRenderer _renderer;
    private BoxCollider2D _boxCollider;
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _boxCollider =GetComponent<BoxCollider2D>();
        if (_intactSprite != null)
        {
            _renderer.sprite = _intactSprite;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            _renderer.sprite = _destroySprite;
            _boxCollider.isTrigger = true;
            //Destroy(this.gameObject);
        }
    }
}
