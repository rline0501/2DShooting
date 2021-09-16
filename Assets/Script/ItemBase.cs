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
        //スクリプトがアタッチされているゲームオブジェクトがゲーム画面に映らない位置まで移動したら
        if (transform.position.x <= -10.0f || transform.position.y <= -6.0f)
        {
            //デストロイする
            Destroy(gameObject);
        }
    }

    protected virtual void GetItem()
    {
        //各クラスでそれぞれの処理をここに書く
        //オブジェクトを消す
        this.gameObject.SetActive(false);

    }
}
