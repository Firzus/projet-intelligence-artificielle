using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    [SerializeField] GameObject _boss;
    [SerializeField] GameObject _EnemiesFolder;
    [SerializeField] Transform _spawnPosition;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(_boss, _spawnPosition.position, _spawnPosition.rotation, _EnemiesFolder.transform);
        Destroy(gameObject);
    }
}
