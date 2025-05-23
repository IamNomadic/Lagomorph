using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class RitualGenerator : MonoBehaviour
{
    //public TextMeshPro timer;
    public List<GameObject> spawnPool;
    [SerializeField] GameObject SpawnZoneCollider;
    public int RitualsGenerated;
    public int RitualsToGenerate;
    public bool RitualsDone;

    // Start is called before the first frame update
    void Start()
    {
        RitualsDone = false;
        spawnobjects();
    }
    private void FixedUpdate()
    {
        
    }
    public void spawnobjects()
    {

        int randomItem = 0;
        GameObject toSpawn;
        
        float screenX, screenY;
        Vector2 pos;
        for(RitualsGenerated = 0; RitualsGenerated < RitualsToGenerate; RitualsGenerated++)
        {
           

            randomItem = UnityEngine.Random.Range(0, spawnPool.Count);
            toSpawn = spawnPool[randomItem];

            screenX = UnityEngine.Random.Range(GetComponent<Collider>().bounds.min.x, GetComponent<Collider>().bounds.max.x);
            screenY = UnityEngine.Random.Range(GetComponent<Collider>().bounds.min.y, GetComponent<Collider>().bounds.max.y);
            pos = new Vector2(screenX, screenY);
            Instantiate(toSpawn, pos, toSpawn.transform.rotation);
        }
    }
    private void destroyOjects()
    {
        foreach(GameObject o in GameObject.FindGameObjectsWithTag("Spawnable"))
        {
            Destroy(o);
        }
    }

}
