using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class populate_levels_normal : MonoBehaviour
{
    public Dropdown allscenes;
    // Start is called before the first frame update 
    void Start()
    {
        string lastlevel = SaveandLoad.loadsave();
        List<string> scenes = new List<string>();
        int scenecount = SceneManager.sceneCountInBuildSettings;

        if (lastlevel != null){
            for (int i = 1; i < scenecount; i++){
                if (!lastlevel.Equals(System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i)))) {
                    scenes.Add("<SOLVED> "+System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i)));
                }
                else
                {
                    scenes.Add("<UNSOLVED> "+System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i)));
                }
                if (lastlevel.Equals(System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i)))){
                    if (!System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i + 1)).Equals(""))
                        scenes.Add("<LOCKED> " + System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i + 1)));
                    break;
                }
            }
        } else {
            scenes.Add("menu");
        }
        allscenes.ClearOptions();
        allscenes.AddOptions(scenes);
    }
}
