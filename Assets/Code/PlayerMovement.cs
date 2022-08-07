using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private enum FacingDirection{Invalid = 0,North = 1,East = 2,South = 3,West = 4};

    [SerializeField]
    private float moveSpeed = 0f;

    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Animator animator;

    private Vector2 movement;
    private FacingDirection facing = 0;

    // Update is called once per frame
    void Update()
    {
        //Gathers movement inputs
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        SetFacing();

        //Sets variables in the animator
        SetAnimator();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void SetAnimator()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        animator.SetFloat("Facing", (float)facing);
    }

    //This could probably be more efficent than seting it each frame
    //Sets which way the player is facing;
    private void SetFacing()
    {
        if (movement.y > 0)
        {
            facing = FacingDirection.North;
        }
        else if (movement.y < 0)
        {
            facing = FacingDirection.South;
        }
        else
        {
            if (movement.x > 0)
            {
                facing = FacingDirection.East;
            }
            else if (movement.x < 0)
            {
                facing = FacingDirection.West;
            }
        }
    }

    //Returns and byte based off the direction the player is facing. 0 to 3. Every int goes in the order of NESW
    public byte GetFacingDirection()
    {
        try
        {
            return (byte)facing;
        }
        catch
        {
            return 0;
        }
    }

}