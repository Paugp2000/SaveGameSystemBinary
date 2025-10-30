using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public static CoinController instance;
    public static GameObject coinPrefab;
    public List<GameObject> coins = new List<GameObject>();
    public SaveSystemController saveSystem;
    public int playerCoins;
    private void Awake()
    {
        coins = GameObject.FindGameObjectsWithTag("Coin").ToList();
        checkCoins();
    }
    public void activeCoins()
    {
        for (int i = 0; i < coins.Count; i++)
        {
            if (saveSystem.loadSavedSystem().coinActiveSaved[i] == true)
            {
                coins[i].SetActive(true);
           
            }
            else
            {
                coins[i].SetActive(false);
                
            }
        }
        checkCoins();
    }
    void checkCoins()
    {
        playerCoins = coins.Count;
        for (int i = 0; i < coins.Count; i++)
        {
            
            if (coins[i].activeInHierarchy == true)
            {
                playerCoins--;
            }
        }
    }
}
