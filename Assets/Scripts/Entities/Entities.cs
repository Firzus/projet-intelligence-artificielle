using UnityEngine;

public abstract class Entities : MonoBehaviour
{
    [SerializeField] float _maxHp;
    [SerializeField] float _currentHp;
    [SerializeField] float _speed;
    [SerializeField][HideInInspector] float _fovRange;
    [SerializeField][HideInInspector] Transform _enemyTransform;
    [SerializeField][HideInInspector] CapsuleCollider2D _capsuleCollider2D;
    [SerializeField][HideInInspector] BoxCollider2D _boxCollider2D;
    [SerializeField][HideInInspector] CircleCollider2D _circleCollider2D;

    public float MaxHp { get => _maxHp; set => _maxHp = value; }
    public float CurrentHp { get => _currentHp; set => _currentHp = value; }
    public float Speed { get => _speed; set => _speed = value; }
    public Transform EnemyTransform { get => _enemyTransform; set => _enemyTransform = value; }
    public float FovRange { get => _fovRange; set => _fovRange = value; }
    public CapsuleCollider2D CapsuleCollider2D { get => _capsuleCollider2D; set => _capsuleCollider2D = value; }
    public BoxCollider2D BoxCollider2D { get => _boxCollider2D; set => _boxCollider2D = value; }
    public CircleCollider2D CircleCollider2D { get => _circleCollider2D; set => _circleCollider2D = value; }
}
