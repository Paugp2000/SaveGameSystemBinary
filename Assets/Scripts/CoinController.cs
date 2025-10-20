using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    PlayerController playerController;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player")==true){
            playerController = collider.GetComponent<PlayerController>();
            Destroy(gameObject);
            playerController.PickUpCoin();
        }
    }
}
