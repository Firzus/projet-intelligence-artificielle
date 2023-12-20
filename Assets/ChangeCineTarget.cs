using Cinemachine;
using UnityEngine;

public class ChangeCineTarget : MonoBehaviour
{
    void Start()
    {
        GameObject a = GameObject.Find("2DCamera");
        CinemachineVirtualCamera camera = a.GetComponent<CinemachineVirtualCamera>();
        camera.Follow = gameObject.transform;
        camera.LookAt = gameObject.transform;
    }

}
