using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Stats")]
    public int curHP;
    public int maxHP;

    [Header("Movement")]
    public float moveSpeed; // How fast the player moves
    public float jumpForce; // How high the player jumps
    [Header("Camera")]
    public float lookSensitivity; // Mouse movement sensitivity
    public float maxLookX;  // Lowest down we can look
    public float minLookX;  // Highest up we can look
    private float rotX;     // Current x rotation of the camera
    [Header("Components")]
    private Camera cam;
    private Rigidbody rb;

    private Weapon weapon;

    void Awake() 
    {
        // Get the components
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();

        weapon = GetComponent<Weapon>();

        // Disable cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    void start()
    {
        //Initialize the UI
        GameUI.instance.UpdateHealthBar(curHP, maxHP);
        GameUI.instance.UpdateScoreText(0);
        GameUI.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo);
    }

    // Update is called once per frame
    void Update()
    {
        //Don't do anything when the game is paused
        if(GameManager.instance.gamePaused == true)
            return;


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
    {   // Get Keyboard input with move speed 
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;
        // Applying movement to the rigidbody
        Vector3 dir = transform.right * x + transform.forward * z;
        // Jump direction
        dir.y = rb.velocity.y;
        // Apply directio to camera movement
        rb.velocity = dir;
    }

    void Jump()
    {
        // Cast ray to ground
        Ray ray = new Ray(transform.position, Vector3.down);
        // Check Ray length to jump
        if(Physics.Raycast(ray, 1.1f))
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void CamLook()
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
    public void TakeDamage(int damage)
    {
        curHP -= damage;
        if(curHP <= 0)
            Die();

        GameUI.instance.UpdateHealthBar(curHP, maxHP);
    }
    void Die()
    {
        GameManager.instance.LoseGame();
    }


    public void GiveHealth(int amountToGive)
    {
        curHP = Mathf.Clamp(curHP + amountToGive, 0, maxHP);
        GameUI.instance.UpdateHealthBar(curHP, maxHP);
    }
    public void GiveAmmo(int amountToGive)
    {
        weapon.curAmmo = Mathf.Clamp(weapon.curAmmo + amountToGive, 0, weapon.maxAmmo);
        GameUI.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo);
    }
}