using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] PlayerMove playerMove;
    [SerializeField] Animator animator;

    private string currentState;
    private string lastMovementDirection;

    // Animation States
    const string PLAYER_IDLE_LEFT = "Player_Idle_Left";
    const string PLAYER_IDLE_RIGHT = "Player_Idle_Right";
    const string PLAYER_IDLE_UP = "Player_Idle_Up";
    const string PLAYER_IDLE_DOWN = "Player_Idle_Down";
    const string PLAYER_RUN_LEFT = "Player_Run_Left";
    const string PLAYER_RUN_RIGHT = "Player_Run_Right";
    const string PLAYER_RUN_DOWN = "Player_Run_Down";
    const string PLAYER_RUN_UP = "Player_Run_Up";

    public void ChangeAnimationState(string newState)
    {
        // Stop the same animation from interrupting itself
        if (currentState == newState) return;

        // Play the animation
        animator.Play(newState);

        // Reassign the current state
        currentState = newState;
    }

    private void FixedUpdate()
    {
        Vector2 movementInput = playerMove.MovementInput;

        if (movementInput == Vector2.zero)
        {
            switch (lastMovementDirection)
            {
                case "Left":
                    ChangeAnimationState(PLAYER_IDLE_LEFT);
                    break;
                case "Right":
                    ChangeAnimationState(PLAYER_IDLE_RIGHT);
                    break;
                case "Up":
                    ChangeAnimationState(PLAYER_IDLE_UP);
                    break;
                case "Down":
                    ChangeAnimationState(PLAYER_IDLE_DOWN);
                    break;
            }
        }
        else
        {
            if (movementInput.x > 0)
            {
                ChangeAnimationState(PLAYER_RUN_RIGHT);
                lastMovementDirection = "Right";
            }
            else if (movementInput.x < 0)
            {
                ChangeAnimationState(PLAYER_RUN_LEFT);
                lastMovementDirection = "Left";
            }

            if (movementInput.y > 0)
            {
                ChangeAnimationState(PLAYER_RUN_UP);
                lastMovementDirection = "Up";
            }
            else if (movementInput.y < 0)
            {
                ChangeAnimationState(PLAYER_RUN_DOWN);
                lastMovementDirection = "Down";
            }
        }
    }
}
