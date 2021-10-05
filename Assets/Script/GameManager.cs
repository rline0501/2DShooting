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
    /// �X�e�[�W��Wave�̃f�[�^���擾���Đݒ�
    /// </summary>
    private void SetStageWaveData()
    {
        //TODO �X�e�[�W������������ύX����
        stageWaveDataList = DataBaseManager.instance.waveDataSO.waveDatasList;

        currentWaveCount = 0;
    }

    /// <summary>
    /// ����Wave�̃f�[�^���擾���Đݒ�
    /// </summary>
    private void SetWaveData()
    {
        currentWaveData = stageWaveDataList.Find(x => x.waveNumber == currentWaveCount);

        //foreach (WaveData waveData in stageWaveDataList) {
        //if (waveData.waveNo == currentWaveCount) {
         //currentWaveData = waveData;
        //}
        //}

        //�j�󂵂��G�l�~�[���̃��Z�b�g
        enemyDestroyCount = 0;

        //TODO �G�l�~�[�̐����i�W�F�l���[�^�\�ɖ��߂��o���j
        StartCoroutine(GenerateEnemies());
    }

    /// <summary>
    /// �G�l�~�[�̐���
    /// </summary>
    private IEnumerator GenerateEnemies()
    {
        for(int i = 0; i < currentWaveData.enemyNumbers.Length; i++)
        {
            //DataBaseManager�N���X���V���O���g���N���X�Ȃ̂ŁADataBaseManager.instance�Ə�����public�̏��ɃA�N�Z�X�ł���
            //public�̏���EnemyDataSO�̏�񂪕ϐ��ɂȂ��Ă���̂ŁA�����ɃA�N�Z�X���Ă��̒���List�̏��ɃA�N�Z�X����
            //List�̒��g���w�肵���G�̔ԍ��Ō������������̂�Find���\�b�h���g����EnemyData�̓G�̔ԍ��Əƍ�����
            EnemyData enemyData = DataBaseManager.instance.enemyDataSO.enemyDatasList.Find(x => x.number == currentWaveData.enemyNumbers[i]);

            //�G�l�~�[�̐���
            EnemyBase enemyBase = Instantiate(enemyData.enemyPrefab, transform.position, Quaternion.identity);

            //�G�l�~�[�̐ݒ�
            enemyBase.SetUpEnemy(this, enemyData);

            //�G�l�~�[�o���ʒu��element���ԍ�����������ϐ�
            //enemyPosDataSO��element�̔ԍ��Əƍ������邽�߂̂���
            int enemyPosIndex = 0;

            //�L������enemyPos��-1�������ꍇ
            if(currentWaveData.enemyPos[i] == -1)
            {
                //element0�`2�̒��̏o���ʒu(1�`3)�������_���Ɏ擾����randomValue�ɑ��
                int randomValue = Random.Range(0, enemyData.positions.Length);

                //�o���ʒu��randomValue�ɑ�����Ă���o���ʒu�ɏ㏑������
                enemyPosIndex = enemyData.positions[randomValue];
            }
            else
            {
                //���ʂɖ{���̏o���ʒu�����̂܂ܑ�������
                enemyPosIndex = currentWaveData.enemyPos[i];
            }
            //�ʒu�̕ύX
            EnemyPosition enemyPosition = DataBaseManager.instance.enemyPositionDataSO.enemyPositionsList.Find(x => x.positionNumber == enemyPosIndex);

            enemyBase.transform.position = enemyPosition.transform.position;

            //List�֒ǉ�



            yield return new WaitForSeconds(1.0f);


        }
    }

    /// <summary>
    /// Wave���̃G�l�~�[�̔j�󐔂�����
    /// </summary>
    /// <returns></returns>
    private IEnumerator observeWave()
    {
        //Wave�Ȃ��ɏo�����邷�ׂẴG�l�~�[���j�󂳂ꂽ���Ď�
        while(enemyDestroyCount < currentWaveData.enemyNumbers.Length)
        {
            yield return null;
        }

        Debug.Log("�Ď��I���");

        //Wave��i�߂邩�X�e�[�W�N���A������
        CheckNextWave();
    }

    /// <summary>
    ///Wave��i�߂邩�A�X�e�[�W�N���A������ 
    /// </summary>
    private void CheckNextWave()
    {
        //����Wave�ɐi��
        currentWaveCount++;

        //�X�e�[�W��Wave���c���Ă���ꍇ
        if(stageWaveDataList.Count > currentWaveCount)
        {
            if(stageWaveDataList.Count -1 == currentWaveCount)
            {
                Debug.Log("Boss");

                //TODO�@�{�X�o���̉��o

            }

            //Wave�̐ݒ�
            SetWaveData();

            //�G�l�~�[�̊Ď��J�n
            StartCoroutine(observeWave());
        }
        else
        {
            Debug.Log("Stage Clear");
        }
    }

    /// <summary>
    /// �G�l�~�[�̔j�󐔂̌v�Z
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
