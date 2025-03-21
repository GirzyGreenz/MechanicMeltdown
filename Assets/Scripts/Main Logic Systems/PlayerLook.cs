/* 
 * PLAYER MOVE
 * Rotates the Player object (horizontally) and the camera (vertically)
 * according to mouse input
 */
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float lookSpeed = 3.0f;
    private Vector2 rotation = Vector2.zero;
    public CursorState cursorState;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if (cursorState.cursorVisible == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            rotation.y += Input.GetAxis("Mouse X");
            rotation.x += -Input.GetAxis("Mouse Y");
            rotation.x = Mathf.Clamp(rotation.x, -15f, 15f);
            Camera.main.transform.localRotation = Quaternion.Euler(rotation.x * lookSpeed, 0, 0);
        }

        transform.eulerAngles = new Vector2(0, rotation.y) * lookSpeed;
        
    }
}
