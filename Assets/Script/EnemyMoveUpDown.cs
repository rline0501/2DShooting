using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveUpDown : EnemyBase
{
    //ˆÚ“®‘¬“x
    public float moveSpeed;

    //‰½•bŒã‚É’â~‚·‚é‚©
    public float stopTime = 2;

    private GameObject target;

    private float timeCount;

    //‰½•bŠÔ~‚Ü‚Á‚Ä‚¢‚é‚©‚ÌŠÄ‹
    private float stopTimeCount = 0;

    //’â~ŒãA‰½•bŒã‚ÉÄ‚Ñ“®‚«o‚·‚©
    private float nextStartTime = 3;

    //~‚Ü‚Á‚Ä‚¢‚é‚©‚Ç‚¤‚©Btrue‚È‚ç’â~’†
    private bool stopKey = false;

    private Vector2 pos;

    void Start()
    {
        pos = transform.position;
    }

    void StopGo()
    {
        timeCount += Time.deltaTime;

        //’â~‚·‚éŠÔ‚É‚È‚Á‚½ã‚ÅA¡’â~‚µ‚Ä‚¢‚È‚¢ê‡
        if (timeCount >= stopTime)
        {
            stopKey = true;

        
            //’â~‚µ‚Ä‚¢‚éŠÔ‚ğ”‚¦‚Â‚Â
            stopTimeCount += Time.deltaTime;
            //’â~‚³‚¹‚é
            //rb.velocity = Vector2.zero;
            
            //’â~‚µ‚Ä‚¢‚éŠÔ‚ªÄ‚Ñ“®‚«o‚·ŠÔ‚ğ’´‚¦‚½ê‡
            if(stopTimeCount >= nextStartTime)
            {
                if (target != null)
                {
                    //ƒvƒŒƒCƒ„[‚Ì•û‚ÉŒü‚«‚ğ•Ï‚¦‚é
                    this.gameObject.transform.LookAt(target.transform.position);
                }

                stopKey = false;

            }

        }
    }

    protected override void Update()
    {
        //‰æ–ÊŠO‚És‚Á‚½‚ÉÁ‚·ˆ—
        base.Update();

        StopGo();

        if (stopKey == false)

            transform.Translate(0, -moveSpeed * Time.deltaTime, 0) ;
    }
}
