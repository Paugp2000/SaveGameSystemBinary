using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    PlayerController playerController;
    public static CoinController instance;  
    public static GameObject coinPrefab;
    private int coinCount = 7;
    public  List <GameObject> coins = new List <GameObject>();

    private void Awake()
    {
        coins = GameObject.FindGameObjectsWithTag("Coin").ToList();
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player")==true){
            playerController = collider.GetComponent<PlayerController>();
            gameObject.SetActive(false);
            playerController.PickUpCoin();
        }
    }
}
