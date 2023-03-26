using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pausebutton : MonoBehaviour
{
  
    public GameObject PauseMenu;
   
  
    public void PauseGame()
    {
        
            Time.timeScale = 0f;
            AudioListener.pause = true;
            PauseMenu.SetActive(true);
     }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        AudioListener.pause =false;
        PauseMenu.SetActive(false);
    }
    public void AnaMenu()
    {
        SceneManager.LoadScene(0);
       
    }


}
