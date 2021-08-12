using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 18f;

    private Vector2 pos;

    void Update()
    {
        float moveX = 0;

        float moveY = 0;

        moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Translate(moveX, moveY, 0);
    }
}
