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
        //�X�N���v�g���A�^�b�`����Ă���Q�[���I�u�W�F�N�g���Q�[����ʂɉf��Ȃ��ʒu�܂ňړ�������
        if (transform.position.x <= -10.0f || transform.position.y <= -6.0f)
        {
            //�X�N���v�g���A�^�b�`����Ă���Q�[���I�u�W�F�N�g��j��
            Destroy(gameObject);

        }
    }
}
