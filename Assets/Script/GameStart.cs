using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
   public void OnStartButtonClicked()
    {
        //ƒ{ƒ^ƒ“‚ð‰Ÿ‚·‚ÆStage1‚ªŽn‚Ü‚é
        SceneManager.LoadScene("Stage1");
    }
}
