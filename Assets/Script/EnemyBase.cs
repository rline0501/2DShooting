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
        //�X�N���v�g���A�^�b�`����Ă���Q�[���I�u�W�F�N�g���Q�[����ʂɉf��Ȃ��ʒu�܂ňړ�������
        if (transform.position.x <= -14.0f)
        {
            //�X�N���v�g���A�^�b�`����Ă���Q�[���I�u�W�F�N�g��j��
            Destroy(gameObject);

        }
    }
}
