using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuControlScript : MonoBehaviour
{
 
    public void changeScene(string sceneName)
    { 
        //PlayerPrefs.SetInt()
        SceneManager.LoadScene(sceneName);      
    }

    
       
   
}
