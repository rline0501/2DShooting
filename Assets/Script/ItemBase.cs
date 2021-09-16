using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    public float moveSpeed;

    protected Vector2 pos;


    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetItem();  
        }
    }

    protected void Update()
    {
        transform.Translate(0, -moveSpeed * Time.deltaTime, 0);
    }

    protected void FixedUpdate()
    {
        //�X�N���v�g���A�^�b�`����Ă���Q�[���I�u�W�F�N�g���Q�[����ʂɉf��Ȃ��ʒu�܂ňړ�������
        if (transform.position.x <= -10.0f || transform.position.y <= -6.0f)
        {
            //�f�X�g���C����
            Destroy(gameObject);
        }
    }

    protected virtual void GetItem()
    {
        //�e�N���X�ł��ꂼ��̏����������ɏ���
        //�I�u�W�F�N�g������
        this.gameObject.SetActive(false);

    }
}
