using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public DeckScript deck;
    public CardScript card;

    public GameObject[] HandCard;

    public int cardIndex = 0;

    public int score = 0;

    int money = 1000;

    public virtual void Startinghand()
    {
        GetCard();
    }

    public int GetCard()
    {
        
        int CardValue = deck.Deal(HandCard[cardIndex].GetComponent<CardScript>());

        this.HandCard[cardIndex].GetComponent<Renderer>().enabled = true;

        this.score += CardValue;

        this.cardIndex++;

        

        return score;
    }

    public void ResetHand()
    {
        for(int i=0; i< HandCard.Length; i++)
        {
            HandCard[i].GetComponent<CardScript>().ResetCard();
            HandCard[i].GetComponent<Renderer>().enabled = false;
        }

        cardIndex = 0;
        score = 0;
    }
}
