using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;



public class ItemPickup : MonoBehaviour
{
    public List<GameObject> ItemsInRange = new List<GameObject>();
    public Pickup Pickup;
    public ActivatedSpikeTrap Trap;
    public ItemSelector Inv;
    public GameObject FirstTrapPickupDialogue;
    public GameObject FirstFoodPickupDialogue;
    public GameObject FirstRitualDialogue;
    PlayerStats Stats;
    public bool FirstFoodPickup;
    public bool FirstTrapPickup;
    public bool FirstRitual;
    [SerializeField] AudioSource ItemPickupSound;
    public static event Action OnPlayerDamaged;



    private void Start()
    {
        FirstRitual = true;
        FirstFoodPickup = true;
        FirstTrapPickup = true;
        Stats = GameObject.FindObjectOfType<PlayerStats>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            Pickup = other.GetComponent<Pickup>();
            if (FirstFoodPickup)
            {
                FirstFoodPickupDialogue.SetActive(true);
            }
        }
        if (other.CompareTag("Trap"))
        {
            Pickup = other.GetComponent<Pickup>();
            Trap = other.GetComponent<ActivatedSpikeTrap>();
            if (FirstTrapPickup)
            {
                FirstTrapPickupDialogue.SetActive(true);
            }

        }
        if (other.CompareTag("Ritual") && FirstRitual)
        {
            FirstRitualDialogue.SetActive(true);
            FirstRitual = false;
        }

    }

    public void PickupItems()
    {
        OnPlayerDamaged?.Invoke();
        if (Pickup.ItemInteractable)
        {
            Debug.Log("StatChange");
            if (Pickup.InvItem.Stats > 0)
            {
                FirstFoodPickup = false;
                if (Stats.CurrentHealth + Pickup.InvItem.Stats < Stats.MaxHealth+1)
                {
                    Stats.HealDamage(Pickup.InvItem.Stats);
                    Destroy(Pickup.gameObject);


                }
                
                else if (Stats.CurrentHunger + Pickup.InvItem.Stats < Stats.MaxHunger+1)
                {
                    Stats.GainHunger(Pickup.InvItem.Stats);
                    Destroy(Pickup.gameObject);

                }

                else if (Stats.CurrentHealth + Pickup.InvItem.Stats > Stats.MaxHealth  && Stats.CurrentHunger + Pickup.InvItem.Stats > Stats.MaxHunger )
                {
                    ItemPickupSound.Play();
                    Inv.allItems.Add(Pickup.InvItem);
                    Destroy(Pickup.gameObject);
                }

            }
            else
            {
                ItemPickupSound.Play();
                Inv.allItems.Add(Pickup.InvItem);
                Destroy(Pickup.gameObject);
            }
            
            
            
            if (Trap != null)
            {
                FirstTrapPickup = false;
            }
            
            
            if (Pickup.InvItem2 != null)
            {
                if (Trap.FullTrap)
                {
                    Inv.allItems.Add(Pickup.InvItem2);
                }
            }
            if (Pickup.InvItem3 != null)
            {
                Inv.allItems.Add(Pickup.InvItem3);

            }
            Inv.reLoadItems();
        }
        OnPlayerDamaged?.Invoke();
    }
    
}
