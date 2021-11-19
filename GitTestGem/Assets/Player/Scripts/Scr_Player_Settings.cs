using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Scr_Player_Settings))]
public class Scr_Player_Settings : MonoBehaviour
{
    [Header("Movement Settings")]
        public float float_move_speed;

    [Header("Camera Settings")]
        public float float_mouse_sensitivity;
        [Tooltip("Camera offset from center of player")]
        public Vector3 cameraOffset;
        [HideInInspector] public float float_mouse_sensMultiplier = 1;
        [HideInInspector] public float float_mouse_xRotation;
        [HideInInspector] public float float_mouse_disiredX;

    [Header("References")]
        public Rigidbody rb;
}
