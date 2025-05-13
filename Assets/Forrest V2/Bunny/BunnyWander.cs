using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyWander : MonoBehaviour
{
    public GameObject PlayerCharacter;
    public SmellZone smellZone;
    public GameTimer GT;
    public Rigidbody2D rb;
    Vector2 direction;
    Vector2 WanderDirection;
    Vector2 zero = new Vector2(2,2);
    float distance;
    float speed;
    float LocalTime;
    bool hit;
    bool targetLock;
    
    private void Awake()
    {
        PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
        GT = GameObject.FindObjectOfType<GameTimer>();

    }
    private void Start()
    {
        
        GameTimer GT = GetComponent<GameTimer>();
        if (GT.CurrentDifficulty > 2)
        {
            this.transform.localScale = new Vector3(0.6f, 0.6f, 1);
        }
    }
    private void Update()
    {
        distance = ((float)Math.Sqrt((gameObject.transform.position.x  - PlayerCharacter.transform.position.x)*(gameObject.transform.position.x - PlayerCharacter.transform.position.x) + (gameObject.transform.position.y - PlayerCharacter.transform.position.y) * (gameObject.transform.position.y - PlayerCharacter.transform.position.y)));
        
        Vector2 direction = transform.position - PlayerCharacter.transform.position;
        LocalTime = LocalTime + Time.deltaTime;
        if (LocalTime>= 4)
        {
            WanderDirection = new Vector2(UnityEngine.Random.Range(-1, 2), UnityEngine.Random.Range(-1, 2)) * 0.2f;
            LocalTime = 0;
            Debug.Log(WanderDirection);
        }
        direction.Normalize();

        if (smellZone.targetLock)
        {
            rb.linearVelocity = direction * speed;
            WanderDirection = new Vector2(0, 0);
        }
        else if (!smellZone.targetLock)
        {
            rb.linearVelocity = WanderDirection;
        }
        #region Phase 1
        if (GT.CurrentDifficulty <= 0.8f)
        {
            if (distance > 2 && !hit)
            {
                speed = 0f;
            }
            if (distance > 0.9 &&!hit)
            {
                speed = 0.7f;
            }
            else if (distance < 0.9 && !hit)
            {
                speed = 1.5f;
            }

        }
        #endregion
        #region Phase 2
        else if (GT.CurrentDifficulty <2)
        {
            
            if (distance > 2 && !hit)
            {
                speed = 0f;
            }
            else if (distance > 0.8 && !hit)
            {
                speed = -0.2f;
            }
            else if (distance > 0.4 && !hit)
            {
                speed = -0.5f;
            }
            else if (distance > 0.2 && !hit)
            {
                speed = -1.8f;
            }
            else if (distance < 0.1)
            {
                speed = 1.8f;
                hit = true;
                StartCoroutine(HitPlayer());
            }
        }
        #endregion
        #region Phase 3
        else if (GT.CurrentDifficulty <3)
        {

            if (distance > 5 && !hit)
            {
                speed = 0f;
            }
            else if (distance > 1.0 && !hit)
            {
                speed = -0.2f;
            }
            else if (distance > 0.4 && !hit)
            {
                speed = -0.5f;
            }
            else if (distance > 0.2 && !hit)
            {
                speed = -1.8f;
            }
            else if (distance < 0.1)
            {
                speed = 1.8f;
                hit = true;
                StartCoroutine(HitPlayer());
            }
        }
        #endregion
        #region Phase 4
        else if (GT.CurrentDifficulty < 4)
        {

            
            if (distance > 5 && !hit)
            {
                speed = -0.2f;
            }

            else if (distance > 1.0 && !hit)
            {
                speed = -0.4f;
            }
            else if (distance > 0.4 && !hit)
            {
                speed = -0.6f;
            }
            else if (distance > 0.2 && !hit)
            {
                speed = -1.8f;
            }
            else if (distance < 0.1)
            {
                speed = 1.8f;
                hit = true;
                StartCoroutine(HitPlayer());
            }
        }
        #endregion
        IEnumerator HitPlayer()
        {
            yield return new WaitForSeconds(1);
            hit = false;
        }
    }
    
   
}
