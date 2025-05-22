using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public PlayerMovement playerMovement;

    public int CurrentHunger;
    public int MaxHunger;
    public int HungerTickTimeGate;
    [SerializeField]float HungerTickTime;
    public int MaxHealth;
    public int CurrentHealth;
    public bool dead;
    public bool RitualsDone;
    bool Starving;
    bool OutOfHunger= false;
    public int RitualsCompleted;
    public int RitualsToComplete;
    public static event Action OnPlayerDamaged;
    private void Start()
    {
        OutOfHunger = false;
        RitualsDone = false;

    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        if (OutOfHunger == false || Starving == true)
        {
            HungerTickTime += Time.deltaTime;

        }
        
        if (HungerTickTime >=HungerTickTimeGate)
        {
            HungerTickTime = 0;
            CurrentHunger--;
            if (Starving)
            {
                TakeDamage(1);
            }
            OnPlayerDamaged?.Invoke();

            Debug.Log("lost 1 hunger");

        }
        if(CurrentHunger <=0)
        {
            OutOfHunger = true;
            Starving = true;
            
        }
        if (RitualsCompleted>=RitualsToComplete)
        {
            RitualsDone = true;
        }

    }

    public void RefreshHud()
    {
        OnPlayerDamaged?.Invoke();

    }

    private IEnumerator LevelReset()
    {
        yield return new WaitForSeconds(0.5f);
        dead = false;
        SceneManager.LoadScene("Title");
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
      
       
        OnPlayerDamaged?.Invoke();
        if (CurrentHealth <= 0)
        {
            StartCoroutine("LevelReset");
            Debug.Log("you are dead");


            dead = true;
        }
    }
    public void HealDamage(int Health)
    {
        if (CurrentHealth + Health < MaxHealth+1)
        {
            CurrentHealth += Health;
        }
        


        OnPlayerDamaged?.Invoke();
        if (CurrentHealth <= 0)
        {
            StartCoroutine("LevelReset");
            Debug.Log("you are dead");


            dead = true;
        }
    }
    public void GainHunger(int Hunger)
    {
        if (CurrentHunger +Hunger <MaxHunger+1)
        { CurrentHunger += Hunger; }
       


        OnPlayerDamaged?.Invoke();
    }
    public void OnCollisionEnter2D (Collision2D DeathBox)
    {
       
     
    }
}