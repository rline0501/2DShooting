using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public GameObject[] playerIcon;

    private int destroyCount = 0;

    public SpriteRenderer sr;

    [SerializeField]
    public GameManager gameManager;
   

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Layer��Invincible�i���G���j�̏ꍇ�͏������s��Ȃ�
        if (gameObject.layer == LayerMask.NameToLayer("Invincible"))
        {
            return;
        }

         Debug.Log("����");

        if(other.gameObject.CompareTag("EnemyMissile"))
        {
            Debug.Log(other.gameObject.name);

            //destroyCount���{�P����
            destroyCount ++;

            UpdatePlayerIcons();

            //�R���[�`���̃��\�b�h�����s����B�R���[�`���̒��ɏ����Ȃ��Ⴂ���Ȃ��̂Œ��ׂ悤
            //gameObject.layer = LayerMask.NameToLayer("Invincible");

            //���G���o�J�n
            StartCoroutine(InvTime());

            Debug.Log(destroyCount);

            //�팂�j�񐔂��R��𒴂������i�c�@�񕜂�destroyCount --�ł̂��ɏ�������j
            if(destroyCount > 3)
            {
                //ResultPopUp�̃v���t�@�u����ʂɌĂяo��������GameManager�Ɏ��s������
                gameManager.GenerateResultPopUp();

                //destroyCount�����Z�b�g
                destroyCount = 0;

                //Player���A�N�e�B�u������
                this.gameObject.SetActive(false);
            }
        }
    }

    void UpdatePlayerIcons()
    {
        for(int i = 0; i < playerIcon.Length; i++)
        {
            if(destroyCount <= i)
            {
                playerIcon[i].SetActive(true);
            }
            else
            {
                playerIcon[i].SetActive(false);
            }
        }
    }

    private IEnumerator InvTime()
    {
        //�v���C���[�𖳓G�ɂ���
        gameObject.layer = LayerMask.NameToLayer("Invincible");

        //�v���C���[�𖳓G���_�ł�����
        //float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
        //sr.color = new Color(1f, 1f, 1f, level);


        //Tween�ϐ���p�ӂ���Tween�ւ̃��[�v��~���߂��󂯕t����悤�ɂ���i�Ȃ��ƈꐶ�_�Ń��[�v����j
        Tween tween = sr.DOFade(0.0f, 0.15f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);

        yield return new WaitForSeconds(3.0f);

        //tween��~
        tween.Kill();

        //sr�̕ω������r���[�ȏ�ԂŎ~�܂�Ȃ��悤��Color�iRGB�{�����x�j�������l�ɖ߂�
        sr.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        //�v���C���[�̖��G���I�����A�_�ł��I������B
        gameObject.layer = LayerMask.NameToLayer("Player");

        //this.gameObject.SetActive(true);
    }
}
