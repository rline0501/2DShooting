using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private Text score;
   


    /// <summary>
    /// ���_��\������
    /// </summary>
  public void DisplayScore()
    {
        score.text = ScoreData.instance.totalScore.ToString();
    }
}
