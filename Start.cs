using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    public void StartNormalGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        Player.NormalMode=true;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void GameControls()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+2);
    }

    public void ControlsToMenu()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-2);
    }
}
