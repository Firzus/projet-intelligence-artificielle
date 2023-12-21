using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] EntityState state;

    private Vector2 movementInput;
    public Vector2 MovementInput { get => movementInput; }

    public void Update()
    {
        movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (movementInput.magnitude > 1)
        {
            movementInput.Normalize();
        }
        if (state.CanMove)
        {
            MovePlayer(state.Speed);
        }
    }

    public void MovePlayer(float speed)
    {
        rb.velocity = movementInput * speed;
    }
}
