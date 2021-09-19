using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPool : MonoBehaviour
{
    float timeSpawn = 2f;
    float timeSinceSpawn;
    ObjectPool objectPool;


    // Start is called before the first frame update
    void Start()
    {
        objectPool = FindObjectOfType<ObjectPool>();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceSpawn += Time.deltaTime;
        if(timeSinceSpawn >= timeSpawn)
        {
            GameObject newBullet = objectPool.GetBullet();
            newBullet.transform.position = this.transform.position;
            timeSinceSpawn = 0f;
        }
    }
}
