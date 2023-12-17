using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private string currentState;
    [SerializeField] Animator animator;

    public void ChangeAnimationState(string newState)
    {
        // Stop the same animation from interrupting itself
        if (currentState == newState) return;

        // Play the animation
        animator.Play(newState);

        // Reassign the current state
        currentState = newState;
    }
}