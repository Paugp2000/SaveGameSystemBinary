using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public class PlayerData 
{
    public float positionX, positionY, positionZ;
    public PlayerData (PlayerController player)
    {
        positionX = player.positionX;
        Debug.Log(positionX);
        positionY = player.positionY;
        Debug.Log(positionY);
        positionZ = player.positionZ;
        Debug.Log(positionZ);
    }
}
