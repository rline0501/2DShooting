using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerHealth : MonoBehaviour
{
    public GameObject[] playerIcon;

    private int destroyCount = 0;

    public SpriteRenderer sr;



    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("命中");

        if(other.gameObject.CompareTag("EnemyMissile"))
        {
            Debug.Log(other.gameObject.name);

            destroyCount += 1;

            UpdatePlayerIcons();

            //コルーチンのメソッドを実行する。コルーチンの中に書かなきゃいけないので調べよう
            //gameObject.layer = LayerMask.NameToLayer("Invincible");

            StartCoroutine(InvTime());

           // this.gameObject.SetActive(false);
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
        //プレイヤーを無敵にする
        gameObject.layer = LayerMask.NameToLayer("Invincible");

        //プレイヤーを無敵中点滅させる
        //float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
        //sr.color = new Color(1f, 1f, 1f, level);


        //Tween変数を用意してTweenへのループ停止命令を受け付けるようにする（ないと一生点滅ループする）
        Tween tween = sr.DOFade(0.0f, 0.15f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);

        yield return new WaitForSeconds(3.0f);

        //tween停止
        tween.Kill();

        //srの変化が中途半端な状態で止まらないようにColor（RGB＋透明度）を初期値に戻す
        sr.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        //プレイヤーの無敵を終了し、点滅も終了する。
        gameObject.layer = LayerMask.NameToLayer("Player");

        //this.gameObject.SetActive(true);
    }
}
