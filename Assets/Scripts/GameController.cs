using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SaveSystemController;

public class GameController : MonoBehaviour
{
    public SaveSystemController save;
    public SaveGameClass saveGame;
    private void Awake()
    {
        player = GetComponent<PlayerController>();
        coin = GetComponent<CoinController>();
        saveGame = new SaveGameClass(player, coin);
    }
    public void GuardarPartida()
    {
        save.saveSystemBinary(saveGame);
    }
    public void CargarPartida()
    {
        saveGame = save.loadSavedSystem();
        save.LoadInGameSave();
    }
}
