using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private Text score;
   


    /// <summary>
    /// “¾“_‚ð•\Ž¦‚·‚é
    /// </summary>
  public void DisplayScore()
    {
        score.text = ScoreData.instance.totalScore.ToString();
    }
}
