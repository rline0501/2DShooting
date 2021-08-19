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
        float moveX = 0;

        float moveY = 0;

        moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Translate(moveX, moveY, 0);

        MoveClamp();
    }

    void MoveClamp()
    {
        pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, -moveLimitX-4, moveLimitX);
        pos.y = Mathf.Clamp(pos.y, -moveLimitY, moveLimitY);

        transform.position = pos;

    }
}
