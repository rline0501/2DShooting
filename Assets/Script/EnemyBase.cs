using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    private GameManager gameManager;

    public int scorePoint;

    //�G��HP
    public int enemyHp;

    public GameObject[] itemPrefab;
 
    public virtual void SetUpEnemy(GameManager gameManager, EnemyData enemyData)
    {
        this.gameManager = gameManager;

        //

        //SO�̃f�[�^�𔽉f���čĐݒ肷��
        this.enemyHp = enemyData.hp;
        this.scorePoint = enemyData.point;
    }

    protected virtual void Update()
    {
        //�X�N���v�g���A�^�b�`����Ă���Q�[���I�u�W�F�N�g���Q�[����ʂɉf��Ȃ��ʒu�܂ňړ�������
        if (transform.position.x <= -10.0f || transform.position.y <= -6.0f)
        {
            //���j���Ă��Ȃ��i��ʊO�ɍs�����j�G���f�X�g���C����
            //Destroy(gameObject);
            DestroyEnemy(false);

        }
    }

    protected virtual void DestroyEnemy(bool isPlayerDestroy)
    {
        //�v���C���[�̍U����Destroy���ꂽ���ǂ���
        if(isPlayerDestroy == true)
        {
            //���_�����Z����
            ScoreData.instance.totalScore += scorePoint;

            //ScoreManager�ɓ��_�𑗂�
            gameManager.scoreManager.DisplayScore();

            //���j���ɃA�C�e���𐶐�����i���\�b�h�j
            GameObject dropItem = itemPrefab[Random.Range(0, itemPrefab.Length)];

            Instantiate(dropItem, transform.position, Quaternion.identity);
        }

        //���_�̗L���Ɋւ�炸�f�X�g���C����
        Destroy(gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        //�~�T�C�������������ꍇ
        if (collision.gameObject.tag == ("Missile"))
        {

            //�G�l�~�[��HP���P���炷
            enemyHp -= 1;

            //�~�T�C����j�󂷂�
            Destroy(collision.gameObject);
                
            if(enemyHp == 0)
            {
                //���j�����G���f�X�g���C����
                DestroyEnemy(true);

            }
        }
    }
}
