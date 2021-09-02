using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    private GameManager gameManager;

 
    public virtual void SetUpEnemy(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    protected virtual void Update()
    {
        //スクリプトがアタッチされているゲームオブジェクトがゲーム画面に映らない位置まで移動したら
        if (transform.position.x <= -10.0f || transform.position.y <= -6.0f)
        {
            //スクリプトがアタッチされているゲームオブジェクトを破壊
            Destroy(gameObject);

        }
    }
}
