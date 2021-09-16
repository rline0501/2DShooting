using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    public float moveSpeed;

    private Vector2 pos;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        transform.Translate(0, -moveSpeed * Time.deltaTime, 0);
    }

    private void FixedUpdate()
    {
        //スクリプトがアタッチされているゲームオブジェクトがゲーム画面に映らない位置まで移動したら
        if (transform.position.x <= -10.0f || transform.position.y <= -6.0f)
        {
            //デストロイする
            Destroy(gameObject);
        }
    }
}
