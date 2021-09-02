using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour

{
    //private GameManager gameManager;

    void Start()
    {

    }
    void SetUpEnemy()
    {

    }

    void Update()
    {
        //スクリプトがアタッチされているゲームオブジェクトがゲーム画面に映らない位置まで移動したら
        if (transform.position.x <= -14.0f)
        {
            //スクリプトがアタッチされているゲームオブジェクトを破壊
            Destroy(gameObject);

        }
    }
}
