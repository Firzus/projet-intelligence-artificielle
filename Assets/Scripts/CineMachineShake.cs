using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CineMachineShake : MonoBehaviour
{
    public static CineMachineShake Instance { get; private set; }

    private CinemachineVirtualCamera virtualCamera;
    private float shakeTime;
    private float shakeTimerTotal;
    private float startingIntensity;

    private void Awake()
    {
        Instance = this;
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        Debug.Log(virtualCamera);
    }

    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        startingIntensity = intensity;
        shakeTimerTotal = time;
        shakeTime = time;
    }

    private void Update()
    {
        if (shakeTime > 0) 
        {
            shakeTime -= Time.deltaTime;
           
            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

           cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = Mathf.Lerp(startingIntensity, 0f, (1 - shakeTime / shakeTimerTotal));
        }   
    }
}
