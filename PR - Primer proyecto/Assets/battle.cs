using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class battle : MonoBehaviour
{
    public int currentHealth;
    public int maximumHealt = 20;
    public int damage = 5;
    public bool death = false;
    public Transform rot;
    public HealthBar health;
    public Transform tank;
    public GameObject thisTank;
    public int counter;

    
   
    public int winner;
    public int hits;

    // Start is called before the first frame update
    void Start()
    {

        currentHealth = maximumHealt;
        health.SetMaxHealth (maximumHealt);
    }

    // Update is called once per frame
    void Update()
    {
      //  counterUP();
        Battles();
        
    }

    void Battles()
    {
        if (currentHealth <= 0)
        {

            death = true;

            if (death == true)
            {
                counter++;
                thisTank.SetActive(false);
                Quaternion actualRot = this.gameObject.transform.rotation;
                rot.rotation = Quaternion.Euler(actualRot.x, actualRot.y, actualRot.z);
                tank.transform.localPosition = new Vector3(0, 0, 0);
                SetInitialHealth();
                death = false;
                thisTank.SetActive(true); 
            }    
        }    
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {

            currentHealth -= damage;
            health.SetHealth(currentHealth);
            
            winner = collision.transform.GetComponent<bulletSpeed>().bulletInd;
            
        }
        
    }

    public void SetInitialHealth()
    {

        currentHealth = maximumHealt;
        health.SetMaxHealth(maximumHealt);
    }
}
