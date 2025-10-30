using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI contadorMonedas;
    [SerializeField] PlayerController playerController;
    [SerializeField] CoinController coinController;

    private void Update()
    {
        contadorMonedas.text = coinController.playerCoins.ToString();
    }
}
