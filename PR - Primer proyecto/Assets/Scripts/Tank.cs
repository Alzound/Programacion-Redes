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

 
    public GameObject proyectile;
    public int poolCapacity = 5;
    public List<GameObject> bullets;
    public GameObject spawnBPoint;
    public GameObject bullet;
    public Transform bulletSpawnpref;


    public List<Material> mat;
    public GameObject chasis;
    public GameObject top;
    public int num = 0;

    public int tankInd = 0; 
  

    private void Start()
    {
        
        bullets = new List<GameObject>();
               

        chasis.GetComponent<Renderer>().material = mat[num];
        top.GetComponent<Renderer>().material = mat[num];
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
      //  change();

    }

    public void SetInitialPos(Vector3 position)
    {
        
        spawnPos = position;
        transform.position = position;
    }

    public void SetPlayerIndex(int index)
    {
        tankInd = index; 
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Started) return;

        for (int i = 0; i < bullets.Count; i++)
        {
            if(!bullets[i].activeInHierarchy)
            {
                bullets[i].transform.position = spawnBPoint.transform.position;
                bullets[i].transform.rotation = spawnBPoint.transform.rotation;
                bullets[i].SetActive(true);
                bullets[i].GetComponent<Rigidbody>().AddForce(bulletSpawnpref.forward * 1000 * 2);
                break;
            }
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        tankMovSpeed = context.ReadValue<Vector2>();
    }
}
