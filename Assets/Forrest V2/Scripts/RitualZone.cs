using UnityEngine;

public class RitualZone : MonoBehaviour
{

    public bool Detected;

    private void Start()
    {
        Detected = false;
    }

    private void FixedUpdate()
    {
        
    }


    public void OnTriggerStay2D(Collider2D collision)
    {
       if(CompareTag("Ritual"))
        {
            Detected = true;
        }
    }
}
