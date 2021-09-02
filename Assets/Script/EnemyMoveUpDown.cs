using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveUpDown : EnemyBase
{
    //�ړ����x
    public float moveSpeed;

    private Vector2 pos;

    void Start()
    {
        pos = transform.position;
    }

    void Update()
    {

        transform.Translate(0, -moveSpeed * Time.deltaTime, 0);
    }
}
