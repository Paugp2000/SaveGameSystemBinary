using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[Serializable]
public class PlayerData 
{
    public float[] position = new float[3]; 
   
    public PlayerData (PlayerController player)
    {
        position[0] = player.positionX;
       
        position[1] = player.positionY;
        
        position[2] = player.positionZ;
        
    }
}
