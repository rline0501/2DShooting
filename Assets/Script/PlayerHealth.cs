using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject[] playerIcon;

    private int destroyCount = 0;

    private void OnTriggerEnter(Collid other)
    {
        if(other.gameObject CompareTag("EnemyMissile"))
        {
            this.gameObject.SetActive(false);

            destroyCount += 1;

            UpdatePlayerIcons();
        }
    }

    void UpdatePlayerIcons()
    {
        for(int i = 0; i < playerIcon.Length; i++)
        {
            if(destroyCount <= i)
            {
                playerIcon[i].SetActive(true);
            }
            else
            {
                playerIcon[i].SetActive(false);
            }
        }
    }
}
