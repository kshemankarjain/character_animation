using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_events : MonoBehaviour
{
   public void replaygame()
   {
        
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
       
   }

    public void quitgame() 
    {
        Application.Quit();
    }
}
