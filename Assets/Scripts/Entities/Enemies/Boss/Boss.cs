using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Boss : EntityState
{
    [SerializeField] public bool isDashing;
    [SerializeField] public bool canDash;
    [SerializeField] public bool isDashHandler;

    [SerializeField] public bool canShield;
    [SerializeField] public bool shieldOn;
    [SerializeField] public bool isShieldHandler;
    [SerializeField] public GameObject _shield;

    private const string IDLE_LEFT = "Boss_Idle_Left";
    private const string IDLE_RIGHT = "Boss_Idle_Right";
    private const string IDLE_TOP = "Boss_Idle_Back";
    private const string IDLE_BOTTOM = "Boss_Idle_Front";
    private const string DIE = "Boss_Die_Front";

    [SerializeField] private Vector2 jumpPos;

    // Start is called before the first frame update
    void Start()
    {
        canShield = true;
        canDash = true;
        FovRange = 5f;
        EnemyStart(100, 1f);
        CurrentHp = MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHp <= 0)
        {
            gameObject.GetComponent<Animator>().Play(DIE);
            Dead();
        }
    }

    public void LookDirection(EntityState _target)
    {
        float x = _target.transform.position.x;
        float y = _target.transform.position.y;

        if (x >= gameObject.transform.position.x)
        {
            gameObject.GetComponent<Animator>().Play(IDLE_RIGHT);
        }
        else
        {
            gameObject.GetComponent<Animator>().Play(IDLE_LEFT);
        }
       
    }

    public IEnumerator ShieldHandler()
    {
        shieldOn = true;
        canShield = true;
        yield return new WaitForSeconds(0.5f);
        isShieldHandler = true;
        yield return new WaitForSeconds(3f);
        shieldOn = false;
        canShield = false;
        yield return new WaitForSeconds(20f);
        canShield = true;
        isShieldHandler = true;
    }

    public IEnumerator DashHandler()
    {
        isDashing = true;
        canDash = true;
        yield return new WaitForSeconds(0.5f);
        isDashHandler = true;
        yield return new WaitForSeconds(0.2f);
        isDashing = false;
        canDash = false;
        yield return new WaitForSeconds(4f);
        canDash = true;
        isDashHandler = false;
    }
}
