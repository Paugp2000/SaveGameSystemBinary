using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

[Serializable]
public class SaveGameClass
{

    public float[] position = new float[3];
    public List<bool> coinActiveSaved;



    public SaveGameClass(PlayerData player, CoinData coin)
    {
        coinActiveSaved = new List<bool>();
        position = player.position;
        for (int i = 0; i < coin.coins.Count; i++)
        {
            coinActiveSaved.Add(coin.coinActive[i]);
        }
        Debug.Log("Clase guardada");
    }
}
