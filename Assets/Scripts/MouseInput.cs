using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    [SerializeField] [Range(0.0f, 1.0f)] private float camSens;
    [SerializeField] private float lookXLimit = 90.0f;
    private Vector3 lastMouse = new Vector3(255, 255, 255);
    private float rotationX = 0;
    private float rotationY = 0;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) // temorary
        {
            Cursor.lockState = CursorLockMode.None;
        }
        if (Input.GetMouseButton(0)) // temporary as well
        {
            Cursor.lockState = CursorLockMode.Locked;
        }


        rotationX += -Input.GetAxis("Mouse Y") * camSens;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        rotationY += Input.GetAxis("Mouse X") * camSens;
        Camera.main.transform.rotation = Quaternion.Euler(rotationX, rotationY, 0); // leave Camera.main or target explicitly?
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * camSens, 0);
    }
}
