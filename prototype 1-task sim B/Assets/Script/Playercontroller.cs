using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public float speed = 10.0f;
    public float turnSpeed;
    // projectile
    //Left and Right Input
public float hInput;
//Forward and Back Input
public float vInput;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       // Getting button press values for Horizontal and Vertical Inputs
       hInput=Input.GetAxis("Horizontal");
       vInput=Input.GetAxis("Vertical");
       
       // Makes the vehicle go left and right
       transform. Rotate(Vector3.up,  turnSpeed * hInput * Time.deltaTime); 
       // Makes the vehicle go forward and back
       transform. Translate(Vector3. forward * speed* Time.deltaTime * vInput);
    }
}
