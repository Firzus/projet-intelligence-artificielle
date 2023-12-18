using System.Collections;
using UnityEngine;

public class Rocket_Explosion : MonoBehaviour
{

    [SerializeField] float _frameNumber;        //nombre de frames d'animation
    [SerializeField] float _frameTime = 0.1f;   //temps entre chaque frames
    private int _frameIndex;                    //frame actuel de l'animation
    private float _animationTime;               //temps total de l'animation avant destruction de l'objet
    public int Frame {  get => _frameIndex; }
    void Start()
    {
        _animationTime = _frameTime * _frameNumber;
        _frameIndex = 0;
        StartCoroutine(EffectTime());
        StartCoroutine(DestroyTime());
    }

    IEnumerator DestroyTime()
    {
        yield return new WaitForSeconds(_animationTime);
        Destroy(this.gameObject);
    }

    IEnumerator EffectTime()
    {
        yield return new WaitForSeconds(_frameTime);
        _frameIndex++;
        StartCoroutine(EffectTime());
    }
}
