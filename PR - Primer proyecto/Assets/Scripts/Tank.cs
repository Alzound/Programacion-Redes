using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tank : MonoBehaviour
{
    [Header("Input system")]
    private PlayerInput playerInput;
    private InputAction move, quit, fire;

    [SerializeField]
    [Header("Tank variables")]
    public Vector3 spawnPos;
    //public InputAction move;
    Vector2 tankMovSpeed;
    float tankSpeed = 15f;
    float tankRot = 510f;
    public bool isMoving; 

    [Header("Tank projectiles")]
    public GameObject projectile;
    public int poolCapacity = 5;
    public List<GameObject> bullets;
    public GameObject spawnBPoint;
    public GameObject bullet;
    public Transform bulletSpawnpref;
    private int currentBulletIndex = 0;

    [Header("Tank materials")]
    public List<Material> mat;
    public GameObject chasis;
    public GameObject top;
    public int num = 0;

    public int tankInd = 0;


    private void OnEnable()
    {
        move.performed += Movement;
        fire.performed += Fire; 
        quit.performed += Quit;
        quit.canceled += Quit;
    }

    private void OnDisable()
    {
        move.performed -= Movement;
        fire.performed -= Fire;
        quit.performed -= Quit;
        quit.canceled -= Quit;
    }


    private void Start()
    {
        
        bullets = new List<GameObject>();
               

        chasis.GetComponent<Renderer>().material = mat[num];
        top.GetComponent<Renderer>().material = mat[num];
        for (int i = 0; i < poolCapacity; i++)
        {
            GameObject obj = (GameObject)Instantiate(projectile);
            obj.SetActive(false);
            bullets.Add(obj);
        }

        currentBulletIndex = 0; // Inicializa el índice de la bala actual
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

    public void SetPlayerIndex(int index)
    {
        tankInd = index; 
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (currentBulletIndex < bullets.Count)
            {
                GameObject currentBullet = bullets[currentBulletIndex];

                if (!currentBullet.activeInHierarchy)
                {
                    currentBullet.transform.position = spawnBPoint.transform.position;
                    currentBullet.transform.rotation = spawnBPoint.transform.rotation;
                    currentBullet.SetActive(true);
                    currentBullet.GetComponent<Rigidbody>().AddForce(bulletSpawnpref.forward * 1000 * 2);
                    currentBulletIndex++; // Avanza al siguiente índice de bala
                }
            }
        }
    }

    public void Movement(InputAction.CallbackContext context)
    {
        tankMovSpeed = context.ReadValue<Vector2>();
        isMoving = true; 
    }
    public void Quit(InputAction.CallbackContext context)
    {
        Application.Quit();
    }
}
