using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endgame : MonoBehaviour
{
    public GameMaster gameMaster;
    void OnTriggerEnter(){
        gameMaster.LevelComplete();
    }
}
