using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyAttack : MonoBehaviour
{
    public GameTimer GT;
    [SerializeField] AudioSource BunnyHitPlayerSound;
    public PlayerStats PH;
    float AttackCoolDown;
    private void Awake()
    {
        GT = GameObject.FindObjectOfType<GameTimer>();
        PH = GameObject.FindObjectOfType<PlayerStats>();
    }
    private void FixedUpdate()
    {
        AttackCoolDown = AttackCoolDown - Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GT.CurrentDifficulty <= 2 && AttackCoolDown <=0)
        {
            if (collision.CompareTag("Player"))
            {
                PH.TakeDamage(1);
                BunnyHitPlayerSound.Play();
                AttackCoolDown = 1;
            }
        }
        else if (GT.CurrentDifficulty<4 && AttackCoolDown <= 0)
        {
            if (collision.CompareTag("Player"))
            {
                PH.TakeDamage(2);
                BunnyHitPlayerSound.Play();
                AttackCoolDown = 1;

            }
        }
    }
}
