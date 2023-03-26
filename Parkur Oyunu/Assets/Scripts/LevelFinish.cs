using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinish : MonoBehaviour
{
    public int levelUnlock;
   private int numberofUnlockedLevels;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            numberofUnlockedLevels = PlayerPrefs.GetInt("levelsUnlocked");
            if (numberofUnlockedLevels<=levelUnlock)
            {
                PlayerPrefs.SetInt("levelsUnlocked",numberofUnlockedLevels+1);
            }
        }
    }


   


}
