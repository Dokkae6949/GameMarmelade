using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Player_Functions : MonoBehaviour
{
    public void LockCursor(bool lockCursor)
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
        }
        else if (Cursor.lockState != CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    /// <returns>Returns a bool based on wether the cursor is locked or not</returns>
    public bool GetCursorLockState()
    {
        if (Cursor.lockState == CursorLockMode.Locked || Cursor.lockState == CursorLockMode.Confined)
            return true;
        else
            return false;
    }
}
