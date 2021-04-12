using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float horizontalInput;
    private float verticalInput;
    private float mouseX;
    private float mouseY;
    private bool jumpKeyWasPressed;
    private float yaw;
    private float pitch;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Cursor.visible = true;
        Debug.Log(_rigidbody.rotation.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            jumpKeyWasPressed = true;
        }
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        mouseX = Input.mousePosition.x;
        mouseY = Input.mousePosition.y;
        // Debug.Log(mouseX);
        mouseX = Input.GetAxis("Mouse X");
        Debug.Log(mouseX);
    }

    void FixedUpdate()
    {
        // ratio = mouseX/Screen.width-0.5f;
        _rigidbody.velocity = new Vector3(
            horizontalInput,
            GetComponent<Rigidbody>().velocity.y,
            verticalInput);
        // _rigidbody.angularVelocity = new Vector3(
        //     0,mouseX,0
        // );
        yaw += 2f * Input.GetAxis("Mouse X");
        pitch -= 2f * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);


        if (jumpKeyWasPressed){
            // Debug.Log("Space Key was Pressed Down");
            _rigidbody.AddForce(Vector3.up*7,
                ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }        
    }

}
