using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointItem : ItemBase
{

    public int itemScore;

    protected override void GetItem()
    {
        //ポイントアイテム獲得をした分のポイントをデータ上でスコアに加算
        ScoreData.instance.totalScore += itemScore;

        //ポイントアイテム獲得をした分のポイントが加算されたスコアをボードに表示
        GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>().DisplayScore();

        //オブジェクトを消す
        base.GetItem();
    }


}
