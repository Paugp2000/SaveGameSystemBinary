using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{
    public SaveSystemController save;
    public SaveGameClass saveGame;
    public PlayerController playerController;
    public CoinController coinController;
    public void GuardarPartida()
    {
        save.saveSystemBinary(saveGame);
    }
    public void CargarPartida()
    {
        playerController.changePosition();
        coinController.activeCoins();
    }
}
