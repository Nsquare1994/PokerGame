using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuControlScript : MonoBehaviour
{
    public int Money;

    public void changeScene(string sceneName)
    {
        PlayerPrefs.SetInt("Money", Money);
        SceneManager.LoadScene(sceneName);      
    }

    private void Start()
    {
        
    }


}
