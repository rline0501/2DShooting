using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveUpDown : EnemyBase
{
    //移動速度
    public float moveSpeed;

    //何秒後に停止するか
    public float stopTime = 2;

    private GameObject target;

    private float timeCount;

    //何秒間止まっているかの監視
    private float stopTimeCount = 0;

    //停止後、何秒後に再び動き出すか
    private float nextStartTime = 3;

    //止まっているかどうか。trueなら停止中
    private bool stopKey = false;

    private Vector2 pos;

    void Start()
    {
        pos = transform.position;
    }

    void StopGo()
    {
        timeCount += Time.deltaTime;

        //停止する時間になった上で、今停止していない場合
        if (timeCount >= stopTime)
        {
            stopKey = true;

        
            //停止している時間を数えつつ
            stopTimeCount += Time.deltaTime;
            //停止させる
            //rb.velocity = Vector2.zero;
            
            //停止している時間が再び動き出す時間を超えた場合
            if(stopTimeCount >= nextStartTime)
            {
                if (target != null)
                {
                    //プレイヤーの方に向きを変える
                    this.gameObject.transform.LookAt(target.transform.position);
                }

                stopKey = false;

            }

        }
    }

    protected override void Update()
    {
        //画面外に行った時に消す処理
        base.Update();

        StopGo();

        if (stopKey == false)

            transform.Translate(0, -moveSpeed * Time.deltaTime, 0) ;
    }
}
