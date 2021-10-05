using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    private GameManager gameManager;

    public int scorePoint;

    //敵のHP
    public int enemyHp;

    public GameObject[] itemPrefab;
 
    public virtual void SetUpEnemy(GameManager gameManager, EnemyData enemyData)
    {
        this.gameManager = gameManager;

        //

        //SOのデータを反映して再設定する
        this.enemyHp = enemyData.hp;
        this.scorePoint = enemyData.point;
    }

    protected virtual void Update()
    {
        //スクリプトがアタッチされているゲームオブジェクトがゲーム画面に映らない位置まで移動したら
        if (transform.position.x <= -10.0f || transform.position.y <= -6.0f)
        {
            //撃破していない（画面外に行った）敵をデストロイする
            //Destroy(gameObject);
            DestroyEnemy(false);

        }
    }

    protected virtual void DestroyEnemy(bool isPlayerDestroy)
    {
        //プレイヤーの攻撃でDestroyされたかどうか
        if(isPlayerDestroy == true)
        {
            //得点を加算する
            ScoreData.instance.totalScore += scorePoint;

            //ScoreManagerに得点を送る
            gameManager.scoreManager.DisplayScore();

            //撃破時にアイテムを生成する（メソッド）
            GameObject dropItem = itemPrefab[Random.Range(0, itemPrefab.Length)];

            Instantiate(dropItem, transform.position, Quaternion.identity);
        }

        //得点の有無に関わらずデストロイする
        Destroy(gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        //ミサイルが当たった場合
        if (collision.gameObject.tag == ("Missile"))
        {

            //エネミーのHPを１減らす
            enemyHp -= 1;

            //ミサイルを破壊する
            Destroy(collision.gameObject);
                
            if(enemyHp == 0)
            {
                //撃破した敵をデストロイする
                DestroyEnemy(true);

            }
        }
    }
}
