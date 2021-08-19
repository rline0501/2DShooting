using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMissile : MonoBehaviour
{

    public GameObject missilePrefab;

    //�e���̑��x
    public float missileSpeed;

    //�e���̌��ʉ�
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
                //Prefab����~�T�C���I�u�W�F�N�g���쐬���A�����missile�Ƃ������O�̙��ɓ����
                GameObject missile = Instantiate(missilePrefab, transform.position, Quaternion.identity);

                Rigidbody2D missileRb = missile.GetComponent<Rigidbody2D>();

                missileRb.AddForce(transform.up * missileSpeed);

                //TODO �e�����ˉ�
                //AudioSource.PlayClipAtPoint(attackSound, transform.position);

                //���˂����e�����R�b��ɍ폜
                Destroy(missile, 3.0f);
            }
        }
    }
}
