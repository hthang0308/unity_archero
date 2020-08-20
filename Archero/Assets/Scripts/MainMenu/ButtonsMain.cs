using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsMain : MonoBehaviour
{
    [SerializeField] Animator changingPanel;

    public void LoadScene()
    {
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
