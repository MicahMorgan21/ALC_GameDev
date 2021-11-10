using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   [Header("Movement")]
    public float moveSpeed;
    [Header("Camera")]
    public float lookSensitivity;
    public float maxLookX;
    public float minLookX;
    private float rotX;
    [Header("Componets")]
    private Camera cam;
    private Rigidbody rb;

    void Awake()
    {
        // Get the components
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();

        //Disable cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Camlook();

    }

    void Move()
    {
         // Get Keyboard input with move speed 
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;
        // Applying movement to the rigidbody
        Vector3 dir = transform.right * x + transform.forward * z;
         // Apply directio to camera movement
        rb.velocity = dir;
    }
    void Camlook()
    {
       // Get mouse input so we can look around with the mouse
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity;

        // Clamp the vertical rotation of the camera
        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);

        // Applying the rotation to Camera
        cam.transform.localRotation = Quaternion.Euler(-rotX, 0, 0);
        transform.eulerAngles += Vector3.up * y; 
    }
}
