using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : BaseMonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    private void OnEnable()
    {
        text.text = GameManager.instance.player.money.moneyValue.ToString();

        string path = Application.persistentDataPath + "/SaveData/Coins";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        GeneralWrapper<int> totalCoin = new GeneralWrapper<int>();
        totalCoin.value = 0;

        FileStream file;
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(path + "/Coins.dat"))
        {
            file = File.Open(path + "/Coins.dat", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), totalCoin);
            Debug.Log(totalCoin.value);

            totalCoin.value += GameManager.instance.player.money.moneyValue;
            file.Close();
        }

        file = File.Create(path + "/Coins.dat");

        string coinData = JsonUtility.ToJson(totalCoin, true);
        bf.Serialize(file, coinData);
        file.Close();
    }
    public void SceneMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
