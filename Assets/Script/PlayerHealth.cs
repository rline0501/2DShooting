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
        Debug.Log("命中");

        if(other.gameObject.CompareTag("EnemyMissile"))
        {
            Debug.Log(other.gameObject.name);

            this.gameObject.SetActive(false);

            destroyCount += 1;

            UpdatePlayerIcons();

            //コルーチンのメソッドを実行する。コルーチンの中に書かなきゃいけないので調べよう
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
        //プレイヤーを無敵にする
        gameObject.layer = LayerMask.NameToLayer("Invincible");

        //プレイヤーを無敵中点滅させる
        float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
        sr.color = new Color(1f, 1f, 1f, level);

        yield return new WaitForSeconds(3.0f);

        //プレイヤーの無敵を終了し、点滅も終了する。
        gameObject.layer = LayerMask.NameToLayer("Player");
    }
}
