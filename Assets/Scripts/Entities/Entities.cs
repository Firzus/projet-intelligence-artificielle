using UnityEngine;

public abstract class Entities : MonoBehaviour
{
    [SerializeField][HideInInspector] public float _maxHp;
    [SerializeField][HideInInspector] public float _currentHp;
    [SerializeField][HideInInspector] public float _speed;
    [SerializeField][HideInInspector] public Transform enemyTransform;
    [SerializeField][HideInInspector] public float fovRange;
    [SerializeField][HideInInspector] public CapsuleCollider2D _capsuleCollider2D;
    [SerializeField][HideInInspector] public BoxCollider2D _boxCollider2D;
    [SerializeField][HideInInspector] public CircleCollider2D _circleCollider2D;
}
