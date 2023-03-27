using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    int unlockedLevelNumbers;



    private void Start()
    {
        if (!PlayerPrefs.HasKey("levelsUnlocked"))
        {
            PlayerPrefs.SetInt("levelsUnlocked", 1);
        }
        unlockedLevelNumbers = PlayerPrefs.GetInt("levelsUnlocked");
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
    }


    private void Update()
    {
        unlockedLevelNumbers = PlayerPrefs.GetInt("levelsUnlocked");
        for (int i = 0; i < unlockedLevelNumbers; i++)
        {
            buttons[i].interactable = true;
        }
    }
    //dsafdsf
}
