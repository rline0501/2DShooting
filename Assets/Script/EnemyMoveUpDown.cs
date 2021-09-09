using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveUpDown : EnemyBase
{
    //�ړ����x
    public float moveSpeed;

    //���b��ɒ�~���邩
    public float stopTime = 2;

    private GameObject target;

    private float timeCount;

    //���b�Ԏ~�܂��Ă��邩�̊Ď�
    private float stopTimeCount = 0;

    //��~��A���b��ɍĂѓ����o����
    private float nextStartTime = 3;

    //�~�܂��Ă��邩�ǂ����Btrue�Ȃ��~��
    private bool stopKey = false;

    private Vector2 pos;

    void Start()
    {
        pos = transform.position;
    }

    void StopGo()
    {
        timeCount += Time.deltaTime;

        //��~���鎞�ԂɂȂ�����ŁA����~���Ă��Ȃ��ꍇ
        if (timeCount >= stopTime)
        {
            stopKey = true;

        
            //��~���Ă��鎞�Ԃ𐔂���
            stopTimeCount += Time.deltaTime;
            //��~������
            //rb.velocity = Vector2.zero;
            
            //��~���Ă��鎞�Ԃ��Ăѓ����o�����Ԃ𒴂����ꍇ
            if(stopTimeCount >= nextStartTime)
            {
                if (target != null)
                {
                    //�v���C���[�̕��Ɍ�����ς���
                    this.gameObject.transform.LookAt(target.transform.position);
                }

                stopKey = false;

            }

        }
    }

    protected override void Update()
    {
        //��ʊO�ɍs�������ɏ�������
        base.Update();

        StopGo();

        if (stopKey == false)

            transform.Translate(0, -moveSpeed * Time.deltaTime, 0) ;
    }
}
