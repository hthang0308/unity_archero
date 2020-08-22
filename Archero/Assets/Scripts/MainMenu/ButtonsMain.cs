using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsMain : MonoBehaviour
{
    [SerializeField] Animator changingPanel;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene()
    {
        Time.timeScale = 0f;
        gameObject.SetActive(false);
        SceneManager.LoadScene("Map1");
    }

    public void ChangeToEquipment()
    {
        changingPanel.SetBool("Equipment", true);
    }

    public void ChangeToMain()
    {
        changingPanel.SetBool("Equipment", false);
    }
}
