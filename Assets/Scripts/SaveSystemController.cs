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
        saved = new SaveGameClass(player);
        formatter.Serialize(stream, saved);
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
}
