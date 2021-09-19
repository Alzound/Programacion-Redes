using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletReturn : MonoBehaviour
{
    ObjectPool objectPool;


    // Start is called before the first frame update
    void Start()
    {
        objectPool = FindObjectOfType<ObjectPool>();    
    }

    private void OnDisable()
    {
        objectPool.ReturnBullet(this.gameObject);
    }
}
