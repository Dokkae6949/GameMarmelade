using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Player_Camera : Scr_Player_Functions
{
    private Scr_Player_Settings PlayerSettings;

    private void Start()
    {
        PlayerSettings = GetComponent<Scr_Player_Settings>();

        LockCursor(true);
    }

    void Update()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
            Look();

        if (Input.GetKeyDown(KeyCode.Escape))
                LockCursor(!GetCursorLockState());
    }

    private void Look()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Mouse X") * PlayerSettings.float_mouse_sensitivity * PlayerSettings.float_mouse_sensMultiplier,
                                    Input.GetAxisRaw("Mouse Y") * PlayerSettings.float_mouse_sensitivity * PlayerSettings.float_mouse_sensMultiplier);

        //Find current look rotation
        Vector3 rot = Camera.main.transform.localRotation.eulerAngles;
        PlayerSettings.float_mouse_disiredX = rot.y + input.x;

        //Rotate, and also make sure we dont over- or under-rotate.
        PlayerSettings.float_mouse_xRotation -= input.y;
        PlayerSettings.float_mouse_xRotation = Mathf.Clamp(PlayerSettings.float_mouse_xRotation, -90f, 90f);

        // set cam position
        Camera.main.transform.position = transform.position + PlayerSettings.cameraOffset;

        //Perform the rotations
        Camera.main.transform.localRotation = Quaternion.Euler(PlayerSettings.float_mouse_xRotation, PlayerSettings.float_mouse_disiredX, 0);
        transform.localRotation = Quaternion.Euler(0, PlayerSettings.float_mouse_disiredX, 0);
    }

}
