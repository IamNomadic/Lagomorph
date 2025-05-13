using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyHealth : MonoBehaviour
{
    public bool Dead;
    public GameObject DeadBunnyPrefab;
    public BunnyWander BW;
   
    public int BunnyHP;
    private void Start()
    {

            BunnyHP = 1;

    }
    private void Update()
    {
        if (BunnyHP <= 0)
        {
            
            Dead = true;
            Destroy(gameObject);
        }
    }
    public void TakeDMG(int Damage)
    {
        BunnyHP = BunnyHP - Damage;
    }
}

