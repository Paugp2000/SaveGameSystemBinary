using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SaveSystemController;

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
        saveGame = save.loadSavedSystem();
        save.LoadInGameSave();
    }
}
