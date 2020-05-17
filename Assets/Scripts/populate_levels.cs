using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class populate_levels : MonoBehaviour
{
    public Dropdown allscenes;
    // Start is called before the first frame update
    void Start()
    {
        List<string> scenes = new List<string>();
        int scenecount = SceneManager.sceneCountInBuildSettings;
        for (int i = 1; i < scenecount; i++){
            scenes.Add(System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i)));
        }
        allscenes.ClearOptions();
        allscenes.AddOptions(scenes);
    }
}
