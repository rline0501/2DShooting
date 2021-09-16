using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject[] playerIcon;

    private int destroyCount = 0;

    public SpriteRenderer sr;



    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("����");

        if(other.gameObject.CompareTag("EnemyMissile"))
        {
            Debug.Log(other.gameObject.name);

            this.gameObject.SetActive(false);

            destroyCount += 1;

            UpdatePlayerIcons();

            //�R���[�`���̃��\�b�h�����s����B�R���[�`���̒��ɏ����Ȃ��Ⴂ���Ȃ��̂Œ��ׂ悤
            //gameObject.layer = LayerMask.NameToLayer("Invincible");

            StartCoroutine(InvTime());
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
        float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
        sr.color = new Color(1f, 1f, 1f, level);

        yield return new WaitForSeconds(3.0f);

        //�v���C���[�̖��G���I�����A�_�ł��I������B
        gameObject.layer = LayerMask.NameToLayer("Player");
    }
}
