using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDeathState : EnemyBaseState
{
    private const string EXPLOSE = "Dynamite_Man_Explose";
    public override void EnterState(EnemyStateManager enemy)
    {
        enemy.agent.ResetPath();
        enemy.agent.velocity = Vector2.zero;
        if (enemy.name == "Dynamite_Man")
        {
            enemy.player.GetComponent<EntityState>().CurrentHp -= 5;
            MonoBehaviour.Destroy(enemy.transform.GetChild(1).gameObject);
            enemy.StartCoroutine(Explode(enemy));
        }

    }
    public override void UpdateState(EnemyStateManager enemy)
    {

    }
    public override void OnTriggerEnter2D(EnemyStateManager enemy, Collider2D col)
    {

    }
    public override void OnTriggerExit2D(EnemyStateManager enemy, Collider2D col)
    {

    }

    IEnumerator Explode(EnemyStateManager enemy)
    {
        enemy.animator.Play(EXPLOSE);
        enemy.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1.5f);
        enemy.player.GetComponent<EntityState>().KillCount++;
        MonoBehaviour.Destroy(enemy.gameObject);
    }
}
