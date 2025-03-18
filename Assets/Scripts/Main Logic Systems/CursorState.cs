using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorState : MonoBehaviour {
    
    public bool cursorVisible = false;

    void Update()
    {
        if (cursorVisible == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void makeCursorVisible()
    {
        cursorVisible = true;
        Cursor.visible = true;
    }

    public void makeCursorInvisible()
    {
        cursorVisible = false;
        Cursor.visible = true;
    }
}
