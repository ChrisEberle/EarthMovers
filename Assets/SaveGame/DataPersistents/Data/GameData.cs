using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public Vector3 playerPosition;
    public int money;
    

    public GameData()
    {
        this.money = 1000;
        playerPosition = Vector3.zero;
    }
}
