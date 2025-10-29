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
    const int coinNum = 7;
    public CoinData (CoinController controller)
    {
        for (int i = 0; i < coinNum; i++)
        {
            coins.Add(controller.coins[i]);
        }
        for (int i = 0; i < coinNum; i++)
        {
            coinPosition[i] = new float[] {
            coins[i].transform.position.x,
            coins[i].transform.position.y,
            coins[i].transform.position.z };
            if (coins[i].activeInHierarchy == true)
            {
                coinActive[i] = true;   
            }
            else
            {
                coinActive[i] = false;
            }
        }
    }
}
