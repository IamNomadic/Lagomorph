using UnityEngine;

public class RepositionObject : MonoBehaviour
{
    [SerializeField] GameObject Self;
    [SerializeField] float speed = 1;
    [SerializeField] string Tag;
    Vector2 Direction;
    Vector2 MoveVector;
    


    private void Start()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        

        if (collision.CompareTag(Tag))
        {
            Vector2 Direction = transform.position - collision.transform.position;
            Direction.Normalize();
            MoveVector = Direction * speed;
            
            Self.gameObject.transform.position = Self.gameObject.transform.position + new Vector3(MoveVector.x,MoveVector.y, 0);
           
        }

    }
}
