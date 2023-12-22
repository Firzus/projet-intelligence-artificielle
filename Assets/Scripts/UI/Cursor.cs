using Unity.VisualScripting;
using UnityEngine;


public class Cursor : MonoBehaviour
{
    [SerializeField] float _cooldownTime = 1f;

    private SpriteRenderer _sp;
    private Time _time;
    private float _cooldown;
    void Start()
    {
        _sp = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        CoolDown();
        var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;
        transform.position = mouseWorldPos;

        if (Input.GetButtonDown("Fire1"))
        {
            GetClicked();
        }
    }

    private void CoolDown()
    {
        if (_cooldown >= -1)
        {
            _cooldown -= Time.deltaTime;
        }
        if (_cooldown <= 0f)
        {
            _sp.color = Color.white;
        }
    }
    private void GetClicked()
    {
        _cooldown = _cooldownTime;
        _sp.color = Color.red;
    }
}
