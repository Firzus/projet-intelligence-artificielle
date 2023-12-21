using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastTeste : MonoBehaviour
{
    [SerializeField] WeaponAim target;
    [SerializeField] GameObject collider;


    public bool RayCast()
    {
        
        GameObject enemy = gameObject.transform.parent.gameObject;
        Vector3 destination = target._target.transform.position;

        // Obtenir le point le plus proche sur le bord du collider à partir de la position de la destination
        Vector3 origin = collider.transform.position;
        //Vector3 origin = collider.bounds.ClosestPoint(destination);

        RaycastHit2D hit = Physics2D.Raycast(origin, destination - origin);
        Debug.DrawRay(origin, destination - origin, Color.red);
        
        if (hit.collider.CompareTag("Player"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
