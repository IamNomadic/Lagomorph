using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TheWell : MonoBehaviour
{
    float LocalTime;
    bool ending;
    public GameObject UIWall;
    public SpriteRenderer SR;
    public Sprite ActivatedWell;
    public PlayerStats PS;
    private void Start()
    {
        LocalTime = 5;
        ending = false;
    }
    private void Update()
    {
        if (ending)
        {
            LocalTime = LocalTime - Time.deltaTime;
        }
        if(LocalTime < 0 )
        {
            SceneManager.LoadScene("Title");
        }
        
        if (PS.RitualsDone)
        {
            SR.sprite = ActivatedWell;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("pre");
        Debug.Log(PS.RitualsDone);


        if (collision.CompareTag("Player")&&PS.RitualsDone)
        {
            Debug.Log("post");
            ending = true;
            
            UIWall.SetActive(true);
            
        }
    }

}
