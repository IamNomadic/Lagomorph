using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyGenerator : MonoBehaviour
{
    public List<GameObject> SpawnPool;
    [SerializeField] Collider SpawnZoneColliderTop;
    [SerializeField] Collider SpawnZoneColliderLeft;
    [SerializeField] Collider SpawnZoneColliderRight;
    [SerializeField] Collider SpawnZoneColliderBottom;
    Collider SelectedSpawnZone;
    public int BunniesSpawned;
    public int BunniesToSpawn;

    int Col;
    public float SpawnCooldown;
    public int SpawnFrequency;
    public int SpawnAmount;
    public bool SpawnBunnys;
    public GameTimer GT;
    // Start is called before the first frame update
    void Start()
    {
        
        SpawnBunnys = true;
        spawnobjects();
    }
    private void FixedUpdate()
    {
        
        if (SpawnCooldown >0)
        {
            SpawnCooldown = SpawnCooldown -Time.deltaTime;
        }
        else
            {
            SpawnBunnys = true;
            spawnobjects();
        }
        if(GT.RitualsCompleted == 3)
        {
            BunniesToSpawn = 200;
        }
    }
    public void spawnobjects()
    {
        
        int randomItem = 0;
        GameObject toSpawn;

        float screenX, screenY;
        Vector2 pos;
        for (int i = 0; BunniesSpawned <= BunniesToSpawn && SpawnBunnys; i++)
        {
            Col = Random.Range(1, 4);
            if (Col==1)
            {
                SelectedSpawnZone = SpawnZoneColliderTop;
            }
            if (Col == 2)
            {
                 SelectedSpawnZone = SpawnZoneColliderLeft;

            }
            if (Col == 3)
            {
                 SelectedSpawnZone = SpawnZoneColliderRight;

            }
            if (Col == 4)
            {
                SelectedSpawnZone = SpawnZoneColliderBottom;

            }
            Debug.Log("Bunny" + i);

            randomItem = UnityEngine.Random.Range(0, SpawnPool.Count);
            toSpawn = SpawnPool[randomItem];

            screenX = UnityEngine.Random.Range(SelectedSpawnZone.bounds.min.x, SelectedSpawnZone.bounds.max.x);
            screenY = UnityEngine.Random.Range(SelectedSpawnZone.bounds.min.y, SelectedSpawnZone.bounds.max.y);
            pos = new Vector2(screenX, screenY);
            Instantiate(toSpawn, pos, toSpawn.transform.rotation);
            SpawnBunnys = false;
            BunniesSpawned++;
            SpawnCooldown = SpawnFrequency;
            
        }
    }

    private void destroyOjects()
    {
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("Spawnable"))
        {
            Destroy(o);
        }
    }

}
