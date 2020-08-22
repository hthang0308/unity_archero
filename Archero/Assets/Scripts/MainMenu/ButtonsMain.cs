using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsMain : MonoBehaviour
{
    [SerializeField] Animator changingPanel;
    [SerializeField] GameObject currentEquipment;

    public void LoadScene()
    {
        currentEquipment.SetActive(false);
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
