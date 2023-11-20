using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFPSCamera : MonoBehaviour
{
    [Header("----- Camera Settings -----")]
    [SerializeField] float sensitivity;
    [SerializeField] int lockVerMin;
    [SerializeField] int lockVerMax;
    [SerializeField] bool invertY;

    float xRotation;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; 
    }

    void Update()
    {
        // Get Input
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivity; 

        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity; 

        if (invertY)
        {
            xRotation += mouseY;
        }
        else
        {
            xRotation -= mouseY;
        }

        //Clamp the Camera Rotation on the X-Axis (for strafing)

        xRotation = Mathf.Clamp(xRotation, lockVerMin, lockVerMax);

        // Rotate the Camera on X-Axis

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        // Rotate the Player on Y-Axis

        transform.parent.Rotate(Vector3.up * mouseX);

    }
}
