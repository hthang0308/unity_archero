using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;

public class CoinSaveLoad : MonoBehaviour
{
    public static CoinSaveLoad instance;
    [HideInInspector] public int coins;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public TextMeshProUGUI textBox;
    private void OnEnable()
    {
        string path = Application.persistentDataPath + "/SaveData/Coins";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        GeneralWrapper<int> totalCoin = new GeneralWrapper<int>();

        FileStream file;
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(path + "/Coins.dat"))
        {
            file = File.Open(path + "/Coins.dat", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), totalCoin);
            Debug.Log(totalCoin.value);
            file.Close();
        }
        else
        {
            file = File.Create(path + "/Coins.dat");

            string coinData = JsonUtility.ToJson(0, true);
            bf.Serialize(file, coinData);
            file.Close();
        }

        coins = totalCoin.value;
        textBox.text = totalCoin.value.ToString();
    }

    public void SaveCoinsData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/SaveData/Coins" + "/Coins.dat");
        GeneralWrapper<int> totalCoin = new GeneralWrapper<int>();
        totalCoin.value = coins;
        string coinData = JsonUtility.ToJson(totalCoin, true);
        bf.Serialize(file, coinData);
        textBox.text = totalCoin.value.ToString();
        file.Close();
    }



}
