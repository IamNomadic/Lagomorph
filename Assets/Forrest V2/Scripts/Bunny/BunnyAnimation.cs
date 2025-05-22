using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyAnimation : MonoBehaviour
{
    private bool isFacingRight = false;

    public SpriteRenderer SR;
    public Rigidbody2D BunnyRB;
    public Animator BunnyAnimator;
    private void FixedUpdate()
    {
        if (!isFacingRight && BunnyRB.linearVelocity.x > 0f)
            Flip();
        else if (isFacingRight && BunnyRB.linearVelocity.x < 0f) Flip();
        if (BunnyRB.linearVelocity.x >0.01|| BunnyRB.linearVelocity.x < -0.01)
        {
            BunnyAnimator.Play("BunnyWalk");
        }
        else if (BunnyRB.linearVelocity.y > 0.01 || BunnyRB.linearVelocity.y < -0.01)
        {
            BunnyAnimator.Play("BunnyWalk");
        }
        else
        {
            BunnyAnimator.Play("BunnyIdle");

        }
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        var localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}
