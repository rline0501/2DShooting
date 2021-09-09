using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject[] playerIcon;

    private int destroyCount = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("–½’†");

        if(other.gameObject.CompareTag("EnemyMissile"))
        {
            Debug.Log(other.gameObject.name);

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
