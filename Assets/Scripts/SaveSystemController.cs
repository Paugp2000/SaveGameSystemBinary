using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystemController : MonoBehaviour
{
    public static PlayerController player;
    public static CoinController coin;
    void Awake()
    {
        Directory.CreateDirectory(Application.persistentDataPath + "/SavedData");
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
    public class SaveGameClass
    {
        public float[] position;
        List<float[]> positionCoin;
        List<bool> setActiveCoin;
        int coinsNumber = 7;

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
