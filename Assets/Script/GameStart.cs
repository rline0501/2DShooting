using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
   public void OnStartButtonClicked()
    {
        //ボタンを押すとStage1が始まる
        SceneManager.LoadScene("Stage1");
    }
}
