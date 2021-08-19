using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMissile : MonoBehaviour
{

    public GameObject missilePrefab;

    //弾幕の速度
    public float missileSpeed;

    //弾幕の効果音
    public AudioClip attackSound;

    public int shootCooltime;

    private int timeCount;

    void Update()
    {
        timeCount += 1;

        if (Input.GetButton("Jump"))
        {
            if(timeCount % shootCooltime == 0)
            {
                //Prefabからミサイルオブジェクトを作成し、それをmissileという名前の匣に入れる
                GameObject missile = Instantiate(missilePrefab, transform.position, Quaternion.identity);

                Rigidbody2D missileRb = missile.GetComponent<Rigidbody2D>();

                missileRb.AddForce(transform.up * missileSpeed);

                //TODO 弾幕発射音
                //AudioSource.PlayClipAtPoint(attackSound, transform.position);

                //発射した弾幕を３秒後に削除
                Destroy(missile, 3.0f);
            }
        }
    }
}
