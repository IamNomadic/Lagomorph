using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class threedot : MonoBehaviour
{
    public TMP_Text thisd;
    float time;
    public int tick;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time = Time.deltaTime+ time;
        if (time >= 1)
        {
            time = 0;
            tick++;
        }
        if(tick==1)
        {
            thisd.text = ".";
        }
        if (tick == 2)
        {
            thisd.text = "..";
        }
        if (tick == 3)
        {
            thisd.text = "...";

        }
        if (tick == 4)
        {
            tick = 1;

        }
    }
}
