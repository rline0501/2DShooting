using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveRightLeft : EnemyBase
{
    //ˆÚ“®‘¬“x
    public float moveSpeed;

    private Vector2 pos;

    void Start()
    {
        pos = transform.position;
    }

   protected override void Update()
    {
        base.Update();

        transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
    }
}
