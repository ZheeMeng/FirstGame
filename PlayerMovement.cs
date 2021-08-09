using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    Vector2 lastClickedPos;
    bool moving;
    
    private void Update()
    {
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
            transform.position = Vector2.MoveTowards(transform.position, lastClickedPos, step);
        }

        else
        {
            moving = false;
        }
    }    
}
