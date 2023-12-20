using UnityEngine;

public abstract class Entities : MonoBehaviour
{
    [SerializeField] float MaxHp;
    [SerializeField] float CurrentHp;
    [SerializeField] float Speed;
    [SerializeField][HideInInspector] Transform EnemyTransform;
    [SerializeField][HideInInspector] float FovRange;
    [SerializeField][HideInInspector] CapsuleCollider2D CapsuleCollider2D;
    [SerializeField][HideInInspector] BoxCollider2D BoxCollider2D;
    [SerializeField][HideInInspector] CircleCollider2D CircleCollider2D;

    public float _maxHp { get => MaxHp; set => MaxHp = value; }
    public float _currentHp { get => CurrentHp; set => CurrentHp = value; }
    public float _speed { get => Speed; set => Speed = value; }
    public Transform enemyTransform { get => EnemyTransform; set => EnemyTransform = value; }
    public float fovRange { get => FovRange; set => FovRange = value; }
    public CapsuleCollider2D _capsuleCollider2D { get => CapsuleCollider2D; set => CapsuleCollider2D = value; }
    public BoxCollider2D _boxCollider2D { get => BoxCollider2D; set => BoxCollider2D = value; }
    public CircleCollider2D _circleCollider2D { get => CircleCollider2D; set => CircleCollider2D = value; }

}
