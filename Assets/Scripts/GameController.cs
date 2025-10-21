using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SaveSystemController;

public class GameController : MonoBehaviour
{
    public SaveSystemController save;
    public SaveGameClass saveGame;
    PlayerController playerController;

    public void GuardarPartida()
    {
        save.saveSystemBinary(saveGame);
    }
    public void CargarPartida()
    {
        saveGame = save.loadSavedSystem();
        playerController.GetComponent<GameObject>().transform.position = Vector3.zero;
    }
}
