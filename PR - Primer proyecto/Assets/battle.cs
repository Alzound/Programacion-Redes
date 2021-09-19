using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battle : MonoBehaviour
{
    public int currentHealth;
    public int maximumHealt = 20;
    public int damage = 5;
    public bool death = false;
    public Transform rot;
    public HealthBar health;
    public Transform tank;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maximumHealt;
        health.SetMaxHealth (maximumHealt);
    }

    // Update is called once per frame
    void Update()
    {
        battles();
    }

    void battles()
    {
        if(currentHealth <= 0)
        {
            death = true;
            if(death == true && Input.GetKeyDown(KeyCode.R))
            {
                SetInitialHealth();
                Quaternion actualRot = this.gameObject.transform.rotation;
                rot.rotation = Quaternion.Euler(actualRot.x, actualRot.y, actualRot.z);
                tank.transform.localPosition = new Vector3(0, 0, 0);

                death = false;
            }
        }
        /*
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Quaternion actualRot = this.gameObject.transform.rotation;            
            rot.rotation = Quaternion.Euler(actualRot.x,actualRot.y,actualRot.z);
            tank.transform.localPosition = new Vector3(0, 0, 0);
            
        }
        */
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("enter");
            currentHealth -= damage; 
        }
    }
    */

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("enter");
            currentHealth -= damage;
            health.SetHealth(currentHealth);
        }
    }

    public void SetInitialHealth()
    {
        Debug.Log("life");
        currentHealth = maximumHealt;
        health.SetMaxHealth(maximumHealt);
    }
}
