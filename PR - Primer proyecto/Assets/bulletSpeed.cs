using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSpeed : MonoBehaviour
{
    /*
    public GameObject bullet;
    public Transform bulletSpawnpref;
    public void firing()
    {
   
            bullet.GetComponent<Rigidbody>().AddForce(bulletSpawnpref.forward * 600000 * 2);
        
    }
    */
    private void OnEnable()
    {
        Invoke("Destroy", 3f);

    }
    
    void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
