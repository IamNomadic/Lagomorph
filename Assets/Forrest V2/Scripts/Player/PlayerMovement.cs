using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class PlayerMovement : MonoBehaviour
{
    public bool MovementEnabled;
    private bool isFacingRight = false;
    public static event Action OnPlayerDamaged;
    public float Speed;
    public float horizontal;
    public float vertical;
    public Rigidbody2D rB;
    public float StepTime;
    public float TimeToStep;
    public AudioSource PlayerAudio;
    public AudioClip Step1;
    public AudioClip Step2;
    bool Walking;
    private void Awake()
    {
        MovementEnabled = true;
    }
    public void EnableMovement()
    {
        MovementEnabled = true;
    }
    public void OneSecDisableMovement()
    {
        MovementEnabled = false;
        StartCoroutine(onesec());
    }
    public void TwoSecDisableMovement()
    {
        MovementEnabled = false;
        StartCoroutine(twosec());
    }
    IEnumerator onesec()
    {
        yield return new WaitForSeconds(1);
        EnableMovement();
    }
    IEnumerator twosec()
    {
        yield return new WaitForSeconds(2);
        EnableMovement();
    }
    public void Move(Vector2 context)
    {
        if (MovementEnabled)
        {
            
            horizontal = context.x;
            vertical = context.y;
        }
    }
    void Update()
    {
        rB.linearVelocity = new Vector2(horizontal * Speed, rB.linearVelocity.y);
        rB.linearVelocity = new Vector2(rB.linearVelocity.x, vertical * Speed);
        if (!isFacingRight && horizontal > 0f)
            Flip();
        else if (isFacingRight && horizontal < 0f) Flip();
        StepTime = StepTime + Time.deltaTime;
        if (horizontal > 0.1f || vertical > 0.1f|| horizontal < -0.1f || vertical < -0.1f)
        {
            Walking = true;
            Debug.Log("Walking");
            if(StepTime > TimeToStep)
            {
                PlayerAudio.Play();
                StepTime = 0;
            }
        }
        else
        {
            Walking = false;
            PlayerAudio.Stop();
            
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
