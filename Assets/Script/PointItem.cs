using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointItem : ItemBase
{

    public int itemScore;

    protected override void GetItem()
    {
        //�|�C���g�A�C�e���l�����������̃|�C���g���f�[�^��ŃX�R�A�ɉ��Z
        ScoreData.instance.totalScore += itemScore;

        //�|�C���g�A�C�e���l�����������̃|�C���g�����Z���ꂽ�X�R�A���{�[�h�ɕ\��
        GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>().DisplayScore();

        //�I�u�W�F�N�g������
        base.GetItem();
    }


}
