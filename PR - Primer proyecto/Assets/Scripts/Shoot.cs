using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    //public Rigidbody proyectile;
    //public Transform spawnPB; 
    
    // Update is called once per frame
    void Update()
    {
       // PopUpProyectile(); 
    }

    /*
    void PopUpProyectile()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Rigidbody proyectileInstance;
            proyectileInstance = Instantiate(proyectile, spawnPB.position, spawnPB.rotation) as Rigidbody;
            proyectileInstance.AddForce(spawnPB.forward * 25f);
            Debug.Log("Hasfire"); 
        }
    }
    */
}
