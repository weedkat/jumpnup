using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handles interactions with the animator component of the player
/// It reads the player's state from the controller and animates accordingly
/// </summary>
public class PlayerAnimator : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("The player controller script to read state information from")]
    public PlayerMovement PlayerMovement;
    [Tooltip("The animator component that controls the player's animations")]
    public Animator animator;

    /// <summary>
    /// Description:
    /// Standard Unity function called once before the first update
    /// Input:
    /// none
    /// Return:
    /// void (no return)
    /// </summary>
    void Start()
    {
        ReadPlayerStateAndAnimate();
    }

    /// <summary>
    /// Description:
    /// Standard Unity function called every frame
    /// Input:
    /// none
    /// Return:
    /// void (no return)
    /// </summary>
    void Update()
    {
        ReadPlayerStateAndAnimate();
    }

    /// <summary>
    /// Description:
    /// Reads the player's state and then sets and unsets booleans in the animator accordingly
    /// Input:
    /// none
    /// Returns:
    /// void (no return)
    /// </summary>
    void ReadPlayerStateAndAnimate()
    {
        if (animator == null)
        {
            return;
        }
        if (PlayerMovement.state == PlayerMovement.PlayerState.Run)
        {
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);
        }

        if (PlayerMovement.state == PlayerMovement.PlayerState.Jump)
        {
            animator.SetBool("isJump", true);
        }
        else
        {
            animator.SetBool("isJump", false);
        }

        if (PlayerMovement.state == PlayerMovement.PlayerState.Fall)
        {
            animator.SetBool("isFalling", true);
        }
        else
        {
            animator.SetBool("isFalling", false);
        }

        if (PlayerMovement.state == PlayerMovement.PlayerState.Dead)
        {
            animator.SetBool("isDead", true);
        }
        else
        {
            animator.SetBool("isDead", false);
        }
    }
}
