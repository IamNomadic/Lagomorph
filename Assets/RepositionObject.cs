using UnityEngine;

public class RepositionObject : MonoBehaviour
{
    [SerializeField] GameObject Self;
    [SerializeField] string Tag;
    float Randx;
    float Randy;


    private void Start()
    {
        Randx = UnityEngine.Random.Range(-0.5f, 0.5f);
        Randy = UnityEngine.Random.Range(-0.5f, 0.5f);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("hooogadaba");

        if (collision.CompareTag(Tag))
        {
            Self.gameObject.transform.position = Self.gameObject.transform.position + new Vector3(Randx, Randy, 0);
           
        }

    }
}
