using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScript : MonoBehaviour
{

    public float DisplayTime;

    public void OnEnable()
    {
        DisplayTime = 4;

    }

    private void FixedUpdate()
    {
        DisplayTime = DisplayTime -Time.deltaTime;
        if (DisplayTime <=0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
