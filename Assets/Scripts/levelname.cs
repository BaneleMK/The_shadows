using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelname : MonoBehaviour
{
    public Text Level_name;
    // Start is called before the first frame update
    void Awake(){
        Level_name.text = SceneManager.GetActiveScene().name;
    }
}
