using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tank : MonoBehaviour
{
    public InputAction move;
    Vector2 tankMovSpeed;
    float tankSpeed = 15f; 
    float tankRot= 510f; 


    private void Update()
    {
        transform.Translate(tankSpeed * tankMovSpeed.y * Time.deltaTime * Vector3.forward);
        transform.Rotate(tankRot * tankMovSpeed.x * Time.deltaTime * Vector3.up); 
    }

    public void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("Fire");
    }
    public void Move(InputAction.CallbackContext context)
    {
        tankMovSpeed = context.ReadValue<Vector2>();
        
        //transform.Translate(10 * Vector3.forward * context.ReadValue<Vector2>().y * Time.deltaTime);
    }
  

}
