using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    PlayerController playerController;
    public static CoinController instance;  
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player")==true){
            playerController = collider.GetComponent<PlayerController>();
            gameObject.SetActive(false);
            playerController.PickUpCoin();
        }
    }
}
