using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ResultPopUp : MonoBehaviour
{
    [SerializeField]
    private Text txtFinalScoreBoad;

    [SerializeField]
    private Transform scoreLabelSet;

    [SerializeField]
    private Button btnTitle;

    
    void Start()
    {
        PlayResult();
    }

    public void PlayResult()
    {
        //�{�^���̊��m���~�߂�
        btnTitle.interactable = false;

        //�{�^���Ƀ��\�b�h��o�^���Ďg����悤�ɂ���B
        btnTitle.onClick.AddListener(OnClickTitle);

        //�V�[�P���X�@�\���g�����Ԃɂ���B
        Sequence sequence = DOTween.Sequence();

        //ScoreLabelSet���w�肵���ʒu�܂ňړ�����
        sequence.Append(scoreLabelSet.DOMoveX(0, 1.0f));

        //�ړ����I������ꍇ�AFinalScoreLabel��SaveData�ɂ���totalScore��Dotween���g���ĉ��Z�\������B
        sequence.Append(txtFinalScoreBoad.DOCounter(0, ScoreData.instance.totalScore, 1.5f));

        //TODO ��ʉ��ɃL�����N�^�[�̃��U���g�Z���t��\��

        //�Q�b�ԑ҂��Ă��� �{�^���̊��m�𕜊�������
        sequence.AppendInterval(2.0f).OnComplete(() => { btnTitle.interactable = true; });

        //�{�^���������ƃ^�C�g����ʂɈڍs����
        OnClickTitle();
    }

    public void OnClickTitle()
    {
        SceneManager.LoadScene("TitleScene");

        Debug.Log("�{�^���������܂���");
    }

}

