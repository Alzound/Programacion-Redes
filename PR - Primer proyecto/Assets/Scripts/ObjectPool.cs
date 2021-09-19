using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject bulletPref;
    public Queue<GameObject> bulletPool = new Queue<GameObject>();
    public int poolSize = 5;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPref);
            bulletPool.Enqueue(bullet);
            bullet.SetActive(false);
        }
    }

    public GameObject GetBullet()
    {
        if(bulletPool.Count > 0)
        {
            GameObject bullet = bulletPool.Dequeue();
            bullet.SetActive(true);
            return bullet;
        }
        else
        {
            GameObject bulllet = Instantiate(bulletPref);
            return bulllet;
        }
    }

    public void ReturnBullet(GameObject bullet)
    {
        bulletPool.Enqueue(bullet);
        bullet.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
