using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public static CoinController instance;  
    public static GameObject coinPrefab;
    public  List <GameObject> coins = new List <GameObject>();

    private void Awake()
    {
        coins = GameObject.FindGameObjectsWithTag("Coin").ToList();
    }
}
