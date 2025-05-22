using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleColorChange : MonoBehaviour
{
    public  float TimeClock;
    public  Color CurrentGate;
    public PlayerStats PS;

    float R;
    float G;
    float B;
    float A;
    [SerializeField] public SpriteRenderer SR;
    bool Transform1;
    bool Transform2;
    bool Transform3;

    // Start is called before the first frame update
    void Start()
    {
        Transform1 = true;
        Transform2 = true;
        Transform3 = true;
        PS = GameObject.FindObjectOfType<PlayerStats>();
        R = 1;
        G = 1;
        B = 1;
        A = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TimeClock = TimeClock + Time.deltaTime;
        SR.color = new Color(R, G, B, A);
        if(PS.RitualsCompleted == 1)
        {
            if(R >0.93 && G > 0.75 && B >0.93)
            {
                R = R - Time.deltaTime / 300;
                G = G - Time.deltaTime / 100;
                B = B - Time.deltaTime / 300;

            }
            if (Transform1)
            {
                this.gameObject.transform.localScale = this.gameObject.transform.localScale * 1.2f;
                Transform1 = false;
            }
        }
        else if (PS.RitualsCompleted == 2)
        {
            if (R > 0.85 && G > 0.6 && B > 0.85)
            {
                R = R - Time.deltaTime / 300;
                G = G - Time.deltaTime / 100;
                B = B - Time.deltaTime / 300;

            }
            if (Transform2)
            {
                this.gameObject.transform.localScale = this.gameObject.transform.localScale * 1.2f;
                Transform2 = false;
            }

        }
        else if (PS.RitualsCompleted == 3)
        {
            if (R > 0.80 && G > 0.5 && B > 0.80)
            {
                R = R - Time.deltaTime / 300;
                G = G - Time.deltaTime / 100;
                B = B - Time.deltaTime / 300;

            }
            if (Transform3)
            {
                this.gameObject.transform.localScale = this.gameObject.transform.localScale * 1.2f;
                Transform3 = false;
            }
            }
       
    }
}
