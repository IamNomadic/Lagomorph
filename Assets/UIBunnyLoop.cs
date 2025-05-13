using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBunnyLoop : MonoBehaviour
{
    float time;
    [SerializeField] int State;
    [SerializeField] Rigidbody2D RB;
    [SerializeField] bool inverted;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localScale = new Vector2(3, 3);
    }

    // Update is called once per frame
    void Update()
    {

        time = time + Time.deltaTime;

        if (time > 8)
        {

            State++;
            time = 0;
        }
        if (State ==5 && !inverted)
        {
            State = 1;
        }
        if (State ==9&& inverted)
        {
            State = 5;
        }
        if(State ==1)
        {
            RB.linearVelocity = new Vector2(1, 0);
        }
        else if (State == 2)
        {
            RB.linearVelocity = new Vector2(0, 1);
        }
        else if (State == 3)
        {
            RB.linearVelocity = new Vector2(-1, 0);
        }
        else if (State == 4)
        {
            RB.linearVelocity = new Vector2(0, -1);
        }
        else if (State == 5)
        {
            RB.linearVelocity = new Vector2( -1f, 0);
        }
        else if (State == 6)
        {
            RB.linearVelocity = new Vector2(0, -1);
        }
        else if (State == 7)
        {
            RB.linearVelocity = new Vector2(1, 0);
        }
        else if (State == 8)
        {
            RB.linearVelocity = new Vector2(0, 1);
        }
        else if (State == 9)
        {
            RB.linearVelocity = new Vector2(1, 0);
        }
    }
}
