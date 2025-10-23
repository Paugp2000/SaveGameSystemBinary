using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystemController : MonoBehaviour
{
    public static PlayerController player;
    public static CoinController coin;
    public static SaveSystemController instance;
    public static SaveGameClass saved;
    protected List<float[]> positioncoinLoad = new List<float[]>();
    void Awake()
    {
        Directory.CreateDirectory(Application.persistentDataPath + "/SavedData");
        player = GetComponent<PlayerController>();
        coin = GetComponent<CoinController>();  
    }
    public void saveSystemBinary(SaveGameClass saveData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/SavedData/game.dat";
        FileStream stream = new FileStream(path, FileMode.Create);
        SaveGameClass saveGame = new SaveGameClass(player, coin); 
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
        loadSavedSystem().position[0] = player.GetComponent<GameObject>().transform.position.x;
        loadSavedSystem().position[1] = player.GetComponent<GameObject>().transform.position.y;
        loadSavedSystem().position[2] = player.GetComponent<GameObject>().transform.position.z;
        loadSavedSystem().positionCoin = positioncoinLoad;
        for (int i = 0; i < loadSavedSystem().coinsNumber; i++) {
                positioncoinLoad[i][0] = coin.GetComponent<GameObject>().GetComponentAtIndex(i).transform.position.x;
                positioncoinLoad[i][1] = coin.GetComponent<GameObject>().GetComponentAtIndex(i).transform.position.y;
                positioncoinLoad[i][2] = coin.GetComponent<GameObject>().GetComponentAtIndex(i).transform.position.z;
        }
        for (int i = 0; i < loadSavedSystem().coinsNumber; i++)
        {
                if (loadSavedSystem().setActiveCoin[i] == true)
            {
                coin.GetComponent<GameObject>().GetComponentAtIndex(i).gameObject.SetActive(true);
            }
            else
            {
                coin.GetComponent<GameObject>().GetComponentAtIndex(i).gameObject.SetActive(false);
            }
        }

    }
    public class SaveGameClass
    {
        public float[] position;
        public List<float[]> positionCoin;
        public int coinsNumber = 7;
        public List<bool> setActiveCoin;

        public SaveGameClass(PlayerController player, CoinController coin)
        {
            position = new float[] { player.GetComponent<GameObject>().transform.position.x, player.GetComponent<GameObject>().transform.position.y, player.GetComponent<GameObject>().transform.position.z };
            for (int i = 0; i < coinsNumber; i++)
            {
                positionCoin[i] = new float[] { coin.GetComponent<GameObject>().GetComponentAtIndex(i).transform.position.x, coin.GetComponent<GameObject>().GetComponentAtIndex(i).transform.position.y, coin.GetComponent<GameObject>().GetComponentAtIndex(i).transform.position.z };
            }
            for (int i = 0; i < coinsNumber; i++)
            {
                setActiveCoin[i] = coin.GetComponent<GameObject>() != null;
            }
        }
    }
    
}
