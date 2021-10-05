using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public WaveData currentWaveData;

    public List<WaveData> stageWaveDataList = new List<WaveData>();

    public int currentWaveCount;

    public ScoreManager scoreManager;

    [SerializeField]
    private int enemyDestroyCount;

    [SerializeField]
    private GameObject resultPrefab;

    void Start()
    {
        ScoreData.instance.totalScore = 0;

        SetStageWaveData();

        SetWaveData();

        StartCoroutine(observeWave());
    }


    /// <summary>
    /// ステージのWaveのデータを取得して設定
    /// </summary>
    private void SetStageWaveData()
    {
        //TODO ステージ数が増えたら変更する
        stageWaveDataList = DataBaseManager.instance.waveDataSO.waveDatasList;

        currentWaveCount = 0;
    }

    /// <summary>
    /// 次のWaveのデータを取得して設定
    /// </summary>
    private void SetWaveData()
    {
        currentWaveData = stageWaveDataList.Find(x => x.waveNumber == currentWaveCount);

        //foreach (WaveData waveData in stageWaveDataList) {
        //if (waveData.waveNo == currentWaveCount) {
         //currentWaveData = waveData;
        //}
        //}

        //破壊したエネミー数のリセット
        enemyDestroyCount = 0;

        //TODO エネミーの生成（ジェネレータ―に命令を出す）
        StartCoroutine(GenerateEnemies());
    }

    /// <summary>
    /// エネミーの生成
    /// </summary>
    private IEnumerator GenerateEnemies()
    {
        for(int i = 0; i < currentWaveData.enemyNumbers.Length; i++)
        {
            //DataBaseManagerクラスがシングルトンクラスなので、DataBaseManager.instanceと書くとpublicの情報にアクセスできる
            //publicの情報にEnemyDataSOの情報が変数になっているので、そこにアクセスしてその中のListの情報にアクセスする
            //Listの中身を指定した敵の番号で検索をしたいのでFindメソッドを使ってEnemyDataの敵の番号と照合する
            EnemyData enemyData = DataBaseManager.instance.enemyDataSO.enemyDatasList.Find(x => x.number == currentWaveData.enemyNumbers[i]);

            //エネミーの生成
            EnemyBase enemyBase = Instantiate(enemyData.enemyPrefab, transform.position, Quaternion.identity);

            //エネミーの設定
            enemyBase.SetUpEnemy(this, enemyData);

            //エネミー出現位置のelement内番号を持たせる変数
            //enemyPosDataSOのelementの番号と照合させるためのもの
            int enemyPosIndex = 0;

            //記入したenemyPosが-1だった場合
            if(currentWaveData.enemyPos[i] == -1)
            {
                //element0～2の中の出現位置(1～3)をランダムに取得してrandomValueに代入
                int randomValue = Random.Range(0, enemyData.positions.Length);

                //出現位置をrandomValueに代入してある出現位置に上書きする
                enemyPosIndex = enemyData.positions[randomValue];
            }
            else
            {
                //普通に本来の出現位置がそのまま代入される
                enemyPosIndex = currentWaveData.enemyPos[i];
            }
            //位置の変更
            EnemyPosition enemyPosition = DataBaseManager.instance.enemyPositionDataSO.enemyPositionsList.Find(x => x.positionNumber == enemyPosIndex);

            enemyBase.transform.position = enemyPosition.transform.position;

            //Listへ追加



            yield return new WaitForSeconds(1.0f);


        }
    }

    /// <summary>
    /// Wave内のエネミーの破壊数を冠し
    /// </summary>
    /// <returns></returns>
    private IEnumerator observeWave()
    {
        //Waveないに出現するすべてのエネミーが破壊されたか監視
        while(enemyDestroyCount < currentWaveData.enemyNumbers.Length)
        {
            yield return null;
        }

        Debug.Log("監視終わり");

        //Waveを進めるかステージクリアか判定
        CheckNextWave();
    }

    /// <summary>
    ///Waveを進めるか、ステージクリアか判定 
    /// </summary>
    private void CheckNextWave()
    {
        //次のWaveに進む
        currentWaveCount++;

        //ステージにWaveが残っている場合
        if(stageWaveDataList.Count > currentWaveCount)
        {
            if(stageWaveDataList.Count -1 == currentWaveCount)
            {
                Debug.Log("Boss");

                //TODO　ボス出現の演出

            }

            //Waveの設定
            SetWaveData();

            //エネミーの監視開始
            StartCoroutine(observeWave());
        }
        else
        {
            Debug.Log("Stage Clear");
        }
    }

    /// <summary>
    /// エネミーの破壊数の計算
    /// </summary>
    public void AddDestroyCount()
    {
        enemyDestroyCount++;
    }
   
    public void GenerateResultPopUp()
    {
        //result
        Instantiate(resultPrefab);
    }

}
