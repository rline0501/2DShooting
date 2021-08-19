using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 18f;

    public float moveLimitX;

    public float moveLimitY;

    private Vector2 pos;

    void Update()
    {
        Move();

        MoveClamp();
    }


    private void Move()
    {
        float moveX = 0;

        float moveY = 0;

        if (Input.GetButton("LowSpeed"))
        {
            moveX = Input.GetAxis("Horizontal") * moveSpeed / 3 * Time.deltaTime;

            moveY = Input.GetAxis("Vertical") * moveSpeed / 3 * Time.deltaTime;

        }
        else
        {
            moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

            moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        }

        transform.Translate(moveX, moveY, 0);
    }


    void MoveClamp()
    {
        pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, -moveLimitX-4, moveLimitX);
        pos.y = Mathf.Clamp(pos.y, -moveLimitY, moveLimitY);

        transform.position = pos;

    }

    private void lowSpeed()
    {

    }
}
