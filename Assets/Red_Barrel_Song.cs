using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_Barrel_Song : MonoBehaviour
{
    [SerializeField] AudioSource source;
    void Start()
    {
        source.Play();
        StartCoroutine(LifeTime());
    }

    IEnumerator LifeTime()
    {
    yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
