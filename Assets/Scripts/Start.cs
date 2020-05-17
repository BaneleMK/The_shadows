using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Start : MonoBehaviour
{
    public GameObject LoadingLevel;
    public GameObject LoadingLevelTester;
    public Text LevelSelection;
    public Text LevelSelectionTester;

    public void closetab(){
        LoadingLevel.SetActive(false);
    }

    public void closetab_tester(){
        LoadingLevelTester.SetActive(false);
    }

    public void openloadtab_normal(){
        LoadingLevel.SetActive(true);
    }

    public void openloadtab_tester(){
        LoadingLevelTester.SetActive(true);
    }

    public void LoadSelectedTester(){
        SceneManager.LoadScene(LevelSelectionTester.text);
    }

    
    public void LoadSelected(){
        if (LevelSelection.text != null && !LevelSelection.Equals("") && !LevelSelection.text.Contains("<LOCKED>")){
            if (LevelSelection.text.Contains("<SOLVED>"))
                SceneManager.LoadScene(LevelSelection.text.Substring(9));
            else
                SceneManager.LoadScene(LevelSelection.text.Substring(11));
        }
    }

    public void StartNewGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void continue_game(){
          SceneManager.LoadScene(SaveandLoad.loadsave());
   }
}