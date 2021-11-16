using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float maxSpeed = 1.0f;
    float rotation = 0.0f;
    GameObject cam;
    Rigidbody myRigidbody;
    
    bool isOnGround;
    public GameObject groundChecker;
    public LayerMask groundLayer;
    public float jumpForce = 300.0f;

    float rotationSpeed = 2.0f;
    float camRotationSpeed = 1.5f;
    float camRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;


        cam = GameObject.Find("Main Camera");
        myRigidbody = GetComponent<Rigidbody>();
    }





    void Update()
    {
        isOnGround = Physics.CheckSphere(groundChecker.transform.position, 0.1f, groundLayer);

        if (isOnGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.AddForce(transform.up * jumpForce);
        }
    

      

        transform.position = transform.position + (transform.forward * Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime);
        
        rotation = rotation + Input.GetAxis("Mouse X") * rotationSpeed;
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f));

        camRotation = camRotation + Input.GetAxis("Mouse Y") * camRotationSpeed;
        
        camRotation = Mathf.Clamp(camRotation, -40.0f, 40.0f);
       
       cam.transform.localRotation = Quaternion.Euler(new Vector3(camRotation, 0.0f, 0.0f));    
    }
}
