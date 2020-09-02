using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : BaseMonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    private void OnEnable()
    {
        text.text = GameManager.instance.player.money.moneyValue.ToString();
    }
    public void SceneMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
