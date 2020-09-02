using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePanel : BaseMonoBehaviour
{
    [SerializeField]
    private GameObject PauseUI;
    public void Exit()
    {
        Debug.Log("Application is now exit");
        Application.Quit();
    }
    public void Pause()
    {
        Time.timeScale = 0;
        PauseUI.SetActive(true);
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Resume()
    {
        Time.timeScale = 1;
        PauseUI.SetActive(false);
    }
    public void BackToStartMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}

