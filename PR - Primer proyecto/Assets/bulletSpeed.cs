using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSpeed : MonoBehaviour
{
    public int bulletInd;
 

    private void Start()
    {
        
    }

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
