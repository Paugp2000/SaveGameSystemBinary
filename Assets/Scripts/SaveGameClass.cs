using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameClass
{
    public float[] position;
    public List<float[]> positionCoin;
    public  int coinsNumber = 7;
    public List<bool> setActiveCoin;
    public int dimension = 3;
    public PlayerController controller;
    public CoinController coinController;
    
    public SaveGameClass(PlayerData player, CoinData coin)
    {
        player = new PlayerData(controller);
        coin = new CoinData(coinController);
        position = new float[] { player.positionX, player.positionY, player.positionZ };
        positionCoin = new List<float[]>();
        setActiveCoin = new List<bool>();
        for (int i = 0; i < coinsNumber; i++)
        {
            positionCoin.Add(coin.coinPosition[i]);
            setActiveCoin.Add(coin.coinActive[i]);
        }
    }
}
