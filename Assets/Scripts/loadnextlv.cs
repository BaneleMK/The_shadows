
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadnextlv : MonoBehaviour
{
   public void loadnextlevel(){
     if (SceneManager.sceneCountInBuildSettings > SceneManager.GetActiveScene().buildIndex + 1){
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
     } else {
          SceneManager.LoadScene(0);
          SaveandLoad.savenextdata();
     }
       
   }

   public void saveandquit(){
          SaveandLoad.savedata();
          SceneManager.LoadScene("menu");
   }

   public void saveandquitnext(){
          loadnextlevel();
          SaveandLoad.savenextdata();
          SceneManager.LoadScene("menu");
   }

   public void quit(){
          SceneManager.LoadScene("menu");
   }
}
