using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatedSpikeTrap : MonoBehaviour
{
    public Transform TrappedItemLocation;
    public bool FullTrap;
    bool TrapUsed;
    public BunnyHealth Bunny;
    public Collider2D Killbox;
    public GameObject DeadBunny;
    public Sprite UsedTrap;
    public SpriteRenderer SR;
    public AudioSource TrapAudio;

    private void Start()
    {
        FullTrap = false;
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy")&&!FullTrap)
        {
            SR.sprite = UsedTrap;
            Bunny = collision.GetComponent<BunnyHealth>();
            TrapUsed = true;
            if (Bunny.BunnyHP == 1)
            {
                Instantiate(DeadBunny,TrappedItemLocation);

                    FullTrap = true;
            }

            Bunny.TakeDMG(1);
            TrapAudio.Play();
            


        }
    }

}
