using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
   public void OnStartButtonClicked()
    {
        //�{�^����������Stage1���n�܂�
        SceneManager.LoadScene("Stage1");
    }
}
