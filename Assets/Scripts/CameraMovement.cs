using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform player, target;

    public float distance = 10f;

    public float mouseSensitivity = 100f;

    float mouseX;
    float mouseY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            mouseX += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            mouseY -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            mouseY = Mathf.Clamp(mouseY, -5, 80);

            //Vector3 direction = new Vector3(0, 0, -distance);
            //Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);

            //transform.position = player.position + rotation * direction;
            transform.LookAt(target);

            target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            player.rotation = Quaternion.Euler(0, mouseX, 0);
        }
    }
}
