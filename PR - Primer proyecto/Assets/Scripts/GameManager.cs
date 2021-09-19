using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class GameManager : MonoBehaviour
{
    
    public GameObject SpawnPositionManager; 
    public List<Transform> spawnP = new List<Transform>();
    public List<GameObject> tanks = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform trans in SpawnPositionManager.transform)
        {
            spawnP.Add(trans); 
        }
    }

    private void Update()
    {
        death();
    }

    public void OnSpawnPlayer(PlayerInput input)
    {
        if(input == true)
        {
            int randomIndex = Random.Range(0, spawnP.Count);
            input.GetComponent<Tank>().SetInitialPos(spawnP[randomIndex].position);
            tanks.Add(input.GetComponent<Tank>().gameObject);
            spawnP.RemoveAt(randomIndex); 
            
            /*
            input.transform.position = spawnP[num++].position;

            input.GetComponent<Tank>().SetInitialPos(spawnP[num].position); 
           */
        }
    }


    void death()
    {
        int randomIndex = Random.Range(0, spawnP.Count);
        if (tanks[0].GetComponentInChildren<battle>().death == true)
            {
            if (Input.GetKeyDown(KeyCode.R))
            {


                tanks[0].GetComponent<Tank>().SetInitialPos(spawnP[randomIndex].position);
            }    
        }
            if (tanks[1].GetComponent<battle>().death == true)
            {
                tanks[1].GetComponent<Tank>().SetInitialPos(spawnP[randomIndex].position);
            }
            if (tanks[2].GetComponent<battle>().death == true)
            {
                tanks[2].GetComponent<Tank>().SetInitialPos(spawnP[randomIndex].position);
            }
            if (tanks[3].GetComponent<battle>().death == true)
            {
                tanks[3].GetComponent<Tank>().SetInitialPos(spawnP[randomIndex].position);
            }

    }
}
