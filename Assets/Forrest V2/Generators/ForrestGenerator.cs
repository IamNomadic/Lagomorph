using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForrestGenerator : MonoBehaviour
{
    public List<GameObject> spawnPool;
    public GameObject quad;
    [SerializeField] int TotalToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        spawnobjects();
    }
    public void spawnobjects()
    {

        int randomItem = 0;
        GameObject toSpawn;
        MeshCollider collider = quad.GetComponent<MeshCollider>();
        float screenX, screenY;
        Vector2 pos;
        for (int i = 0; i < TotalToSpawn; i++)
        {
            Debug.Log((i+1) + "ForrestObjects");

            randomItem = Random.Range(0, spawnPool.Count);
            toSpawn = spawnPool[randomItem];

            screenX = Random.Range(collider.bounds.min.x, collider.bounds.max.x);
            screenY = Random.Range(collider.bounds.min.y, collider.bounds.max.y);
            pos = new Vector2(screenX, screenY);
            Instantiate(toSpawn, pos, toSpawn.transform.rotation);
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
