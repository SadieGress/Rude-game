using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    void Awake(){
        Cursor.lockState = CursorLockMode.Locked;
    }

    public Transform cam; 
    float rotX = 0, rotY = 0, sensitivity = 400; 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            Cursor.lockState = CursorLockMode.None;
        }
        rotX += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        rotY += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        rotY = Mathf.Clamp(rotY, -70, 70);
        cam.parent.rotation = Quaternion.Euler(0f, rotX, 0f);
        cam.rotation = Quaternion.Euler(-rotY, rotX, 0f);
    }
}
