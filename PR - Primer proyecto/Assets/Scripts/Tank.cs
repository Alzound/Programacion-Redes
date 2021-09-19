using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tank : MonoBehaviour
{

    public Vector3 spawnPos;
    public InputAction move;
    Vector2 tankMovSpeed;
    float tankSpeed = 15f;
    float tankRot = 510f;

    float firingSpeed = 10f;
    public GameObject proyectile;
    public int poolCapacity = 5;
    public List<GameObject> bullets;
    public GameObject spawnBPoint;
    public GameObject bullet;
    public Transform bulletSpawnpref;

    private void Start()
    {
        bullets = new List<GameObject>();
        for (int i = 0; i < poolCapacity; i++)
        {
            GameObject obj = (GameObject)Instantiate(proyectile);
            obj.SetActive(false);
            bullets.Add(obj);
        }
        
    }


    private void Update()
    {
        transform.Translate(tankSpeed * tankMovSpeed.y * Time.deltaTime * Vector3.forward);
        transform.Rotate(tankRot * tankMovSpeed.x * Time.deltaTime * Vector3.up);
        
    }

    public void SetInitialPos(Vector3 position)
    {
        spawnPos = position;
        transform.position = position; 
    }

    public void Fire(InputAction.CallbackContext context)
    {
        Rigidbody bulletF = bullet.GetComponent<Rigidbody>();
        
        if (context.phase != InputActionPhase.Started) return;

        

        for (int i = 0; i < bullets.Count; i++)
        {
            if(!bullets[i].activeInHierarchy)
            {
                bullets[i].transform.position = spawnBPoint.transform.position;
                bullets[i].transform.rotation = spawnBPoint.transform.rotation;
                bullets[i].SetActive(true);
                bulletF.AddForce(bulletSpawnpref.forward * 600000 * 1);
                break;
            }
        }

      
    }
    public void Move(InputAction.CallbackContext context)
    {
        tankMovSpeed = context.ReadValue<Vector2>();
        
        //transform.Translate(10 * Vector3.forward * context.ReadValue<Vector2>().y * Time.deltaTime);
    }
  

}
