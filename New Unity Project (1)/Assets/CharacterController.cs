using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float maxSpeed = 1.0f;
    float rotation = 0.0f;
    GameObject cam;
    
    float rotationSpeed = 2.0f;
    float camRotationSpeed = 1.5f;
    float camRotation;

    void Start()
    {
        cam = GameObject.Find("Main Camera");
    }





    void Update()
    {
        transform.position = transform.position + (transform.forward * Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime);
        
        rotation = rotation + Input.GetAxis("Mouse X") * rotationSpeed;
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f));

        camRotation = camRotation + Input.GetAxis("Mouse Y") * camRotationSpeed;
        cam.transform.localRotation = Quaternion.Euler(new Vector3(camRotation, 0.0f, 0.0f));    
    }
}
