using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackmissile : MonoBehaviour
{
    public GameObject enemyMissilePrefab;

    public float speed;

    private int timeCount;

    void Start()
    {

    }

    void Update()
    {
        timeCount += 1;   

        if(timeCount % 600 == 0)
        {
            //敵ミサイルの生成
            GameObject enemyMissile = Instantiate(enemyMissilePrefab, transform.position, Quaternion.identity);

            Rigidbody2D enemyMissileRb = enemyMissile.GetComponent<Rigidbody2D>();

            //ミサイルを飛ばす方向を決める
            enemyMissileRb.AddForce(-transform.up * speed);

            //３秒後にミサイルを破壊する
            Destroy(enemyMissile, 5.0f);

        }
    }
}
