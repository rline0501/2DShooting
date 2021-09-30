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
        //ボタンの感知を止める
        btnTitle.interactable = false;

        //ボタンにメソッドを登録して使えるようにする。
        btnTitle.onClick.AddListener(OnClickTitle);

        //シーケンス機能を使える状態にする。
        Sequence sequence = DOTween.Sequence();

        //ScoreLabelSetが指定した位置まで移動する
        sequence.Append(scoreLabelSet.DOMoveX(0, 1.0f));

        //移動が終わった場合、FinalScoreLabelにSaveDataにあるtotalScoreをDotweenを使って加算表示する。
        sequence.Append(txtFinalScoreBoad.DOCounter(0, ScoreData.instance.totalScore, 1.5f));

        //TODO 画面下にキャラクターのリザルトセリフを表示

        //２秒間待ってから ボタンの感知を復活させる
        sequence.AppendInterval(2.0f).OnComplete(() => { btnTitle.interactable = true; });

        //ボタンを押すとタイトル画面に移行する
        OnClickTitle();
    }

    public void OnClickTitle()
    {
        SceneManager.LoadScene("TitleScene");

        Debug.Log("ボタンを押しました");
    }

}

