using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[CreateAssetMenu(fileName = "Player Data", menuName = "data", order = 1 )]
public class PlayerData : ScriptableObject
{
    [SerializeField]
    public List<PlayerInfo> playerData;
    public int indexData; 

    public void Data()
    {
        Debug.Log("The index retrieved was:" + indexData);
    }
}

[System.Serializable]
public struct PlayerInfo
{
    public string schema;
    public InputDevice device;

    public PlayerInfo(string schema, InputDevice device)
    {
        this.schema = schema;
        this.device = device;
    }

   
}
