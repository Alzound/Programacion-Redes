/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LobbyManager : MonoBehaviour
{
    public List<GameObject> joinPosManager;
    public InputAction join1;
    public InputAction join2;
    public InputAction startGame;

    public GameObject pos; 


    public int Tindex = 0; 
    //public InputAction action;
    public List<int> players = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        join1.Enable();
       // join2.Enable();
        join1.performed += (call) => JoinPlayer(call, 0);
        //join2.performed += (call) => JoinPlayer(call, 1);

        
    }

    void JoinPlayer(InputAction.CallbackContext callback, int index)
    {
        
        if (players.Contains(index)) return;
        Debug.Log(index); 
        var input = PlayerInputManager.instance.JoinPlayer();

        string scheme = "Keyboard&Mouse";
        if (index == 1) scheme = "Keyboard2";

        PlayerInput.all[input.playerIndex].SwitchCurrentControlScheme(controlScheme: scheme, Keyboard.current);

        players.Add(index);
        join1.Disable();
        //join2.Disable(); 
    }

    private void Update()
    {
        
    }
    public void OnJoinPlayer(PlayerInput input)
    {

        Transform correctPos = pos.gameObject.transform;//joinPosManager[Tindex].gameObject.transform;
        input.transform.SetPositionAndRotation(correctPos.position, correctPos.rotation);
        Debug.Log("Me he unido2");
    }

    
}

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement; 

public class LobbyManager : MonoBehaviour
{
    public InputAction join1;
    public InputAction join2;

    public PlayerData data;

    public int indexLobby = 0;
    //Hago una lista para ver los controles conectados
    [SerializeField]
    List<int> joinControllers = new List<int>();

    int timer = 0; 

    public Transform joinPosManager;

    // Start is called before the first frame update
    void Start()
    {
        //Habilito las acciones
        join1.Enable();
        join2.Enable();
        //Agregando la funcionalidad a las acciones
        join1.performed += (call) => JoinPlayer(call, 0);
        join2.performed += (call) => JoinPlayer(call, 1);

        //PlayerInfo info = new PlayerInfo();
    }

    void JoinPlayer(InputAction.CallbackContext callback, int index)
    {
        if (joinControllers.Contains(index)) return;
        
        var input = PlayerInputManager.instance.JoinPlayer();

        string scheme = "Keyboard&Mouse";
        if (index == 1) scheme = "Keyboard2";

        PlayerInput.all[input.playerIndex].SwitchCurrentControlScheme(controlScheme: scheme, Keyboard.current);

        joinControllers.Add(index);
        indexLobby++;
        data.indexData = indexLobby;
    }

    // Update is called once per frame
    void Update()
    {
        Next(); 
    }

    public void OnJoinPlayer(PlayerInput input)
    {
        Debug.Log("me uni");
        Transform correctPos = joinPosManager.GetChild(input.playerIndex);

        input.transform.SetPositionAndRotation(correctPos.position, correctPos.rotation);
    }

    public void Next()
    {
        StartCoroutine(NextScene());
        Debug.Log(NextScene());
    }

    IEnumerator NextScene()
    {
        timer++; 
        Debug.Log("Quedan: " + timer);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("yes"); 
    }
}