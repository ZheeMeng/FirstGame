using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 4f;
    Vector2 lastClickedPos;
    bool moving;
    Vector2 movement;
    printf("poop");
    
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(lastClickedPos, Vector2.zero);

        if (Input.GetMouseButtonDown(0))
        {
            lastClickedPos = mousePos;
            moving = true;
        }

        if (moving && (Vector2)transform.position != lastClickedPos && hit.collider != null)
        {
            float step = speed * Time.deltaTime;
            Quaternion rotationDirection = Quaternion.LookRotation(Vector3.forward, movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationDirection, rotationSpeed);
            transform.position = Vector2.MoveTowards(transform.position, lastClickedPos, step);

        }

        else
        {
            moving = false;
        }
    }    
}
