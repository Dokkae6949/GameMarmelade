using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera sceneCamera;
    
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 movement;

    Vector2 mousePosition;

    public Weapon weapon;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
        }

        movement = new Vector2(movement.x, movement.y).normalized;
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
      rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

      // Player aims to Mouse pointer
      Vector2 aimDirection = mousePosition - rb.position;
      float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
      rb.rotation = aimAngle;
    }
}
