using UnityEngine;
using System;

[System.Serializable]
public class PlayerProgress
{
    public string savedlevel;

    public PlayerProgress(string level){
        savedlevel = level;
    }
}