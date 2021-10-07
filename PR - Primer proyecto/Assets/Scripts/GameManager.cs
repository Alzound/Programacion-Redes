using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro; 

public class GameManager : MonoBehaviour
{
    
    public GameObject SpawnPositionManager; 
    public List<Transform> spawnP = new List<Transform>();
    public List<GameObject> tanks = new List<GameObject>();
    public List<Material> mat;
    public int randomIndex = 0;
    public int num;
    public int i = 0;
    public int var = 0; 
    public TextMeshProUGUI textMesh; 
    public int score;
    public int player;
    public GameObject bullet;

    public GameObject canvas; 
    PlayerInput input;

    public PlayerData dataM;


    int index = 0;

    //public static PlayerInput GetPlayerByIndex(int playerIndex);
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform trans in SpawnPositionManager.transform)
        {
            spawnP.Add(trans); 
        }
        var = spawnP.Count;

       
        PlayerInputManager.instance.JoinPlayer(playerIndex: 0,controlScheme: "Keyboard&Mouse", pairWithDevice: Keyboard.current);
        //Jugador2
        var input = PlayerInputManager.instance.JoinPlayer(playerIndex: 1);
        PlayerInput.all[input.playerIndex].SwitchCurrentControlScheme(controlScheme: "Keyboard2", Keyboard.current); 
    }

    private void Update()
    {
        Death(input); 
        //        changecolor();
        SelectWinner();

        dataM.Data();
    }

    public void OnSpawnPlayer(PlayerInput input)
    {
        
        if (input == true)
        {
            input.GetComponent<Tank>().SetPlayerIndex(index);
            randomIndex = Random.Range(0, spawnP.Count);
            
            input.GetComponent<Tank>().SetInitialPos(spawnP[randomIndex].position);
            tanks.Add(input.GetComponent<Tank>().gameObject);
            spawnP.RemoveAt(randomIndex);
            bullet.GetComponent<bulletSpeed>().bulletInd = index;
            index++;
            

        }

    }

    public void OnDisabledPlayer(PlayerInput input)
    {
        index--; 
    }
    public void Death(PlayerInput input)
    {

            randomIndex = Random.Range(0, spawnP.Count);
            if (tanks[0].GetComponentInChildren<battle>().death == true)
            {
             
                tanks[0].GetComponent<Tank>().SetInitialPos(spawnP[randomIndex].position);

            }
            if (tanks[1].GetComponentInChildren<battle>().death == true)
            {
  
            tanks[1].GetComponent<Tank>().SetInitialPos(spawnP[randomIndex].position);

            }
            if (tanks[2].GetComponentInChildren<battle>().death == true)
            {
       
            tanks[2].GetComponent<Tank>().SetInitialPos(spawnP[randomIndex].position);
            }
            if (tanks[3].GetComponentInChildren<battle>().death == true)
            {
  
            tanks[3].GetComponent<Tank>().SetInitialPos(spawnP[randomIndex].position);
            }
    }


    void SelectWinner()
    {
        foreach(GameObject tank in tanks)
        {
            while(i < var)
            {
                Debug.Log("entro al var");
                if (tanks[i].GetComponentInChildren<battle>().counter == 3)
                {
                    player = tanks[i].GetComponentInChildren<battle>().winner;
                    canvas.SetActive(true);
                    score = tanks[player].GetComponentInChildren<battle>().counter;
                    Time.timeScale = 0;
                    textMesh.text = "Player " + player + " WINS \n TOTAL TIMES DEATH:" + score;
                    break; 
                }
                else
                {
                    i++;
                }
            }
            i = 0; 
            
            
        }


        #region //basicamente es lo mismo, pero largoo.

        /*
        //opción deprecada
        if(tanks[0].GetComponentInChildren<battle>().counter == 3)
        {
            player = tanks[0].GetComponentInChildren<battle>().winner;
            canvas.SetActive(true);
            score = tanks[0].GetComponentInChildren<battle>().counter;
            Time.timeScale = 0; 
            textMesh.text = "Player " + player + " WINS \n TOTAL LIVES LEFT:" + score;

        }
        if (tanks[1].GetComponentInChildren<battle>().counter == 3)
        {

            player = tanks[1].GetComponentInChildren<battle>().winner;
            canvas.SetActive(true);
            score = tanks[1].GetComponentInChildren<battle>().counter;
            Time.timeScale = 0;
            textMesh.text = "Player " + player + " WINS \n TOTAL LIVES LEFT:" + score;
        }
        if (tanks[2].GetComponent<battle>().counter == 3)
        {
            canvas.SetActive(true);
            Time.timeScale = 0;
            score = tanks[2].GetComponent<battle>().counter;
            textMesh.text = "Player 2 WINS \n TOTAL LIVES LEFT:" + score;
        }
        if (tanks[3].GetComponent<battle>().counter == 3)
        {
            canvas.SetActive(true);
            Time.timeScale = 0;
            score = tanks[3].GetComponent<battle>().counter;
            textMesh.text = "Player 2 WINS \n TOTAL LIVES LEFT:" + score;
        }
        */
        #endregion


        #region //opcion1
        /*
        if(tanks[0].GetComponent<battle>().counter > tanks[1].GetComponent<battle>().counter)
        {

            if(tanks[0].GetComponent<battle>().counter > tanks[2].GetComponent<battle>().counter)
            {
                if (tanks[0].GetComponent<battle>().counter > tanks[3].GetComponent<battle>().counter)
                {
                    score = tanks[0].GetComponent<battle>().counter;
                    textMesh.text = "Player 1 WINS \n TOTAL LIVES LEFT:" + score;
                }
                else
                {
                    score = tanks[2].GetComponent<battle>().counter;
                    textMesh.text = "Player 3 WINS \n TOTAL LIVES LEFT:" + score;
                }
            }
            else
            {
                if (tanks[2].GetComponent<battle>().counter > tanks[3].GetComponent<battle>().counter)
                {
                    score = tanks[1].GetComponent<battle>().counter;
                    textMesh.text = "Player 2 WINS \n TOTAL LIVES LEFT:" + score;

                }
                else
                {
                    score = tanks[3].GetComponent<battle>().counter;
                    textMesh.text = "Player 4 WINS \n TOTAL LIVES LEFT:" + score;
                }
            }
        }
        else
        {
            if (tanks[1].GetComponent<battle>().counter > tanks[2].GetComponent<battle>().counter)
            {
                if (tanks[1].GetComponent<battle>().counter > tanks[3].GetComponent<battle>().counter)
                {
                    score = tanks[1].GetComponent<battle>().counter;
                    textMesh.text = "Player 2 WINS \n TOTAL LIVES LEFT:" + score;
                }
                else
                {
                    score = tanks[3].GetComponent<battle>().counter;
                    textMesh.text = "Player 4 WINS \n TOTAL LIVES LEFT:" + score;
                }
            }
            else
            {
                if (tanks[2].GetComponent<battle>().counter > tanks[3].GetComponent<battle>().counter)
                {
                    score = tanks[2].GetComponent<battle>().counter;
                    textMesh.text = "Player 3 WINS \n TOTAL LIVES LEFT:" + score;
                }
                else
                {
                    score = tanks[3].GetComponent<battle>().counter;
                    textMesh.text = "Player 4 WINS \n TOTAL LIVES LEFT:" + score;
                }
            }
        }
        */
        #endregion
    }


}
