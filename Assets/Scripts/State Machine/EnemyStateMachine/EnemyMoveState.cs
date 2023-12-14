using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyBaseState
{
    //private GameObject[] wp;
    bool loop = false;
    public override void EnterState(EnemyStateManager enemy)
    {
        InstantiateWaypoint();
        //CreateRandomWaypoint(enemy);
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        if (!loop)
        {
            PointA(enemy);
        }
        else
        {
            PointB(enemy);
        }
    }

    public override void OnTriggerEnter2D(EnemyStateManager enemy, Collider2D col)
    {
        //switch state if trigger
        Debug.Log("Trigger " + col.name);
        if (col.name == "player")
        {
            enemy.SwitchState(enemy.chase);
        }
        //get tag
    }

    //Local function
    private void PointA(EnemyStateManager enemy)
    {
        GameObject B = GameObject.Find("/Waypoint/B");
        float speed = 2.0f;
        Vector3 destination = B.transform.position;
        Vector3 newPos = Vector3.MoveTowards(enemy.transform.position, destination, speed * Time.deltaTime);
        enemy.transform.position = newPos;
        float distance = Vector3.Distance(enemy.transform.position, destination);
        if (distance == 0.0f)
        {
            loop = true;
        }
    }

    private void PointB(EnemyStateManager enemy)
    {
        GameObject A = GameObject.Find("/Waypoint/A");
        float speed = 2.0f;
        Vector3 destination = A.transform.position;
        Vector3 newPos = Vector3.MoveTowards(enemy.transform.position, destination, speed * Time.deltaTime);
        enemy.transform.position = newPos;
        float distance = Vector3.Distance(enemy.transform.position, destination);
        if (distance == 0.0f)
        {
            loop = false;
        }
    }

    private void InstantiateWaypoint()
    {
        string WaypointPath = "Assets/Prefabs/EnemiesWaypoint/Simple Bullet/Simple Bullet Waypoint.prefab";
        GameObject prefab = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(WaypointPath);
        GameObject waypoint = GameObject.Instantiate(prefab);
        waypoint.name = "Waypoint";
    }

    private void CreateRandomWaypoint(EnemyStateManager enemy)
    {
        int a = (int)Random.Range(2.0f, 4.0f);

        for (int i = 0; i < a; i++)
        {
            float x = Random.Range(-10.0f, 5.0f), y = Random.Range(-10.0f, 5.0f), z = Random.Range(-10.0f, 5.0f);
            string WaypointPath = "Assets/Prefabs/EnemiesWaypoint/Simple Bullet/Simple Bullet Waypoint.prefab";
            GameObject prefab = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(WaypointPath);
            GameObject waypoint = GameObject.Instantiate(prefab, new Vector3(x, y, z), prefab.transform.rotation);
            waypoint.name = "Waypoint " + enemy.name + " " + i;
        }
    }
}
