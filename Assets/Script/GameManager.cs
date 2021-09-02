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

    void Start()
    {
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
        for(int i = 0; i < currentWaveData.enemys.Length; i++)
        {
            //�G�l�~�[�̐���
            EnemyBase enemyBase = Instantiate(currentWaveData.enemys[i], transform.position, Quaternion.identity);

            //�G�l�~�[�̐ݒ�
            enemyBase.SetUpEnemy(this);

            //�ʒu�̕ύX


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
        while(enemyDestroyCount < currentWaveData.enemys.Length)
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
   
}
