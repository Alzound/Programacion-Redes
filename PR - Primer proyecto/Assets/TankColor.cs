using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankColor : MonoBehaviour
{
    public Transform meshRendererManager;
    public Material[] tankColours;

    // Start is called before the first frame update
    void Start()
    {
        for(int i= 0; i< meshRendererManager.childCount;i++)
        {
            var child = meshRendererManager.GetChild(i);
            MeshRenderer mesh = child.GetComponent<MeshRenderer>();

            Material[] mats = mesh.materials;
            mats[0] = tankColours[i];
            mesh.materials = mats;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
