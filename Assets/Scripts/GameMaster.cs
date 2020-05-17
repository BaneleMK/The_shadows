using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    // whats the point of this bool?
    // bool gameon = true;
    public GameObject GameUI;
    public GameObject LevelCompUI;
    public float restartdelay = 1f;

    public void LevelComplete(){
        LevelCompUI.SetActive(true);
        GameUI.SetActive(false);
    }
    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMenu(){
       SceneManager.LoadScene(0);
    }

    void Update(){
        if (Input.GetKey(KeyCode.Escape)){
            LoadMenu();
        }
    }
}
