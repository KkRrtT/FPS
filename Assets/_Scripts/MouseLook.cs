using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sens = 100f;
    public float xRot;
    public Transform playerBody;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sens * Time.deltaTime;
        playerBody.Rotate(Vector3.up * mouseX);
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90);
        transform.localRotation = Quaternion.Euler(xRot, 0, 0);
    }
}
