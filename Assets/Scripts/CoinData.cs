using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CoinData
{
    public List<float[]> coinPosition;
    public List<GameObject> coins;
    public List<bool> coinActive;

    public CoinData(CoinController controller)
    {
        coins = new List<GameObject>();
        coinActive = new List<bool>();
        for (int i = 0; i < controller.coins.Count; i++)
        {
            coins.Add(controller.coins[i]);
        }
        for (int j = 0; j < controller.coins.Count; j++)
        {
            if (coins[j].activeInHierarchy == true)
            {
                coinActive.Add(true);
            }
            else
            {
                coinActive.Add(false);
            }
        }
    }
}
