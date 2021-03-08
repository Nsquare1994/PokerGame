using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MainMenuControlScript : MonoBehaviour
{
    public Text CurrentMoneyText;
    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);      
    }

    public void Add1000Money()
    {
        StaticVar.Money += 1000;
        CurrentMoneyText.text = "Money: " + StaticVar.Money;
    }

    private void Start()
    {
        CurrentMoneyText.text = "Money: " + StaticVar.Money;
    }
}


