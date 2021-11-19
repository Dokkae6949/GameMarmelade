using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Player_Movement : Scr_Player_Functions
{
    private Scr_Player_Settings PlayerSettings;

    private void Start()
    {
        PlayerSettings = GetComponent<Scr_Player_Settings>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        Vector3 moveTo = transform.TransformDirection(new Vector3(input.x, 0, input.y).normalized * PlayerSettings.float_move_speed);

        PlayerSettings.rb.velocity = moveTo;
    }
}