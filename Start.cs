using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    #region StartingModes
    public void StartNormalGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        Player.NormalMode=true;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

     public void StartNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
        Player.NextLevel=true;
    }

    public void GameControls()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+3);
    }

    public void ControlsToMenu()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-3);
    }

    public void RestartGame()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }

    public void Exit()
    {
        Application.Quit();
    }
    #endregion
}
