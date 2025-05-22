using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmellZone : MonoBehaviour
{
    public bool targetLock;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            targetLock = true;


        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            targetLock = false;
        }
    }
}
