using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuControlScript : MonoBehaviour
{
    public void changeScene(Button button)
    {
        // scene change
        if (button.name == "HighLoButton")
            SceneManager.LoadScene("HighLo");
        else if(button.name == "BlackjackButton")
            SceneManager.LoadScene("Blackjack");
        else if (button.name == "FiveCardButton")
            SceneManager.LoadScene("5CardPoker");
        else if (button.name == "SevenCardButton")
            SceneManager.LoadScene("7CardPoker");
        else if (button.name == "MainMenuButton")
            SceneManager.LoadScene("MainScene");
    }
   
}
