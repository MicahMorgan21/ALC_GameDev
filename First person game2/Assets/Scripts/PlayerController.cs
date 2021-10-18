using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement
    public float moveSpeed; // How fast the player moves

    public float jumpForce; // How High The player jumps
    //Camera
    public float lookSensitivity; // Mouse movement sensitivity

    public float maxLookX; // Lowest down we can look

    public float minLookX; // Highest up we can look
    
    private float rotX;    // Current x rotation of the camera

    //Components
    private Camera cam;

    private Rigidbody rb;

    private Weapon weapon;

    void Awake()
    {
        // Get the components
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();

        weapon = GetComponent<Weapon>();
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        CamLook();
        // Jump Button
        if(Input.GetButtonDown("Jump"))
            Jump();
            // Fire Button
            if(Input.GetButton("Fire1"))
            {
                if(weapon.CanShoot())
                    weapon.Shoot();
            }
    }
    void Move()
   {  // Get Keyboard input with move speed
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;
        // Applying movement to the rigidbody
        Vector3 dir = transform.right * x + transform.forward * z;
   }
    

}
