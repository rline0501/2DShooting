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

        if(timeCount % 100 == 0)
        {
            //敵ミサイルの生成
            GameObject enemyMissile = Instantiate(enemyMissilePrefab, transform.position, Quaternion.identity);

            Rigidbody enemyMissileRb = enemyMissile.GetComponent<Rigidbody>();

            //ミサイルを飛ばす方向を決める
            enemyMissileRb.AddForce(transform.forward * speed);

            //３秒後にミサイルを破壊する
            Destroy(enemyMissile, 3.0f);

        }
    }
}
