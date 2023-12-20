using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    [SerializeField] public bool isDashing;
    [SerializeField] public bool canDash;
    [SerializeField] public bool isDashHandler;

    [SerializeField] public bool canShield;
    [SerializeField] public bool shieldOn;
    [SerializeField] public bool isShieldHandler;

    [SerializeField] private Vector2 jumpPos;

    // Start is called before the first frame update
    void Start()
    {
        canShield = true;
        canDash = true;
        fovRange = 3f;
        EnemyStart(200, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
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
