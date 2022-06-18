using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursorController : MonoBehaviour
{
    public bool lockStateMoused = true;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            lockStateMoused = !lockStateMoused;
        }
        if (lockStateMoused)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
