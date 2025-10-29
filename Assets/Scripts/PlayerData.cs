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
        positionX = player.GetComponent<Transform>().position.x;
        Debug.Log(positionX);
        positionY = player.GetComponent<Transform>().position.y;
        Debug.Log(positionY);
        positionZ = player.GetComponent<Transform>().position.z;    
        Debug.Log(positionZ);
    }
}
