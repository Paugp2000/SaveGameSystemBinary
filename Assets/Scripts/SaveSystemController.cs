using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystemController : MonoBehaviour
{
    public PlayerController player;
    public CoinController coin;
    public static SaveSystemController instance;
    public static SaveGameClass saved;
    protected List<float[]> positioncoinLoad = new List<float[]>();
    public List<float[]> positionCoin = new List<float[]>();
    public List<bool> setActiveCoin = new List<bool>();
    void Awake()
    {
        Directory.CreateDirectory(Application.persistentDataPath + "/SavedData");
        player = PlayerController.instance;
        coin = CoinController.instance;
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
        loadSavedSystem().position[0] = player.transform.position.x;
        loadSavedSystem().position[1] = player.transform.position.y;
        loadSavedSystem().position[2] = player.transform.position.z;
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
    [Serializable]
    public class SaveGameClass
    {
        public float[] position;
        public List<float[]> positionCoin;
        public int coinsNumber = 7;
        public List<bool> setActiveCoin;

        public SaveGameClass(PlayerController player, CoinController coin)
        { 
            position = new float[] { player.transform.position.x, player.transform.position.y, player.transform.position.z };
            positionCoin = new List<float[]>();
            setActiveCoin = new List<bool>();
            for (int i = 0; i < coinsNumber; i++)
            {
                GameObject coinObj = coin.coins[i]; // Asegúrate de tener esta lista en CoinController

                positionCoin.Add(new float[] {
            coinObj.transform.position.x,
            coinObj.transform.position.y,
            coinObj.transform.position.z
        });

                setActiveCoin.Add(coinObj.activeSelf);
            }
            if (player != null && coin != null)
            {
               new SaveGameClass(player, coin);
            }
            else
            {
                Debug.LogError("Player o CoinController no están inicializados");
            }
        }
    }
    
}
