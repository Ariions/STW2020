using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private InputController playerInput;

    private GameObject player;

    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;
    public float cameraHight = 7f;
    public float camaeraDistance = 5f;

    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerInput = GetComponent<InputController>();
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float mouseX = playerInput.VerticalMouse;
        float mouseY = -playerInput.HorizontalMouse;

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        Quaternion playerRotation = Quaternion.Euler(0.0f, rotY, 0.0f);
        
        player.transform.rotation = playerRotation;
        transform.rotation = localRotation;

        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }


        Vector3 temp = player.transform.position - (player.transform.forward * camaeraDistance);

        temp.y = cameraHight;
        


        // Assign value to Camera position
        transform.position = temp;
    }
}
