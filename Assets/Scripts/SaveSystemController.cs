using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystemController : MonoBehaviour
{
    public PlayerData player;
    public CoinData coin;
    public static SaveSystemController instance;
    public static SaveGameClass saved;
    protected List<float[]> positioncoinLoad = new List<float[]>();
    public List<float[]> positionCoin = new List<float[]>();
    public List<bool> setActiveCoin = new List<bool>();
    void Awake()
    {
        Directory.CreateDirectory(Application.persistentDataPath + "/SavedData");
    }
    
    public void saveSystemBinary(SaveGameClass data)
    { 
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/SavedData/game.dat";
        FileStream stream = new FileStream(path, FileMode.Create);
        saved = new SaveGameClass(player, coin);
        SaveGameClass saveGame = saved;
        formatter.Serialize(stream, saveGame);
        stream.Close();
    }
    public SaveGameClass loadSavedSystem()
    {
        string path = Application.persistentDataPath + "/SavedData/game.dat";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            SaveGameClass data = formatter.Deserialize(stream) as SaveGameClass;
            stream.Close(); 
            return data;
        }
        else
        {
            return null;
        }
    }
    public void LoadInGameSave()
    {
        loadSavedSystem().position[0] = player.positionX;
        loadSavedSystem().position[1] = player.positionY;
        loadSavedSystem().position[2] = player.positionZ;
        loadSavedSystem().positionCoin = positioncoinLoad;
        for (int i = 0; i < loadSavedSystem().coinsNumber; i++) {
                positioncoinLoad[i][0] = coin.coins[i].transform.position.x;
                positioncoinLoad[i][1] = coin.coins[i].transform.position.y;
                positioncoinLoad[i][2] = coin.coins[i].transform.position.z;
        }
        for (int i = 0; i < loadSavedSystem().coinsNumber; i++)
        {
                if (loadSavedSystem().setActiveCoin[i] == true)
            {
                coin.coins[i].SetActive(true);
            }
            else
            {
                coin.coins[i].SetActive(false);
            }
        }

    }
}
