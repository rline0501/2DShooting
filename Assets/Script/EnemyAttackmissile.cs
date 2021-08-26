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
            //�G�~�T�C���̐���
            GameObject enemyMissile = Instantiate(enemyMissilePrefab, transform.position, Quaternion.identity);

            Rigidbody enemyMissileRb = enemyMissile.GetComponent<Rigidbody>();

            //�~�T�C�����΂����������߂�
            enemyMissileRb.AddForce(transform.forward * speed);

            //�R�b��Ƀ~�T�C����j�󂷂�
            Destroy(enemyMissile, 3.0f);

        }
    }
}
