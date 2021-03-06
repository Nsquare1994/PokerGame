using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerScript : MonoBehaviour
{
    public DeckScript deck;
    public CardScript card;

    private Tuple<int, string> handCardValueSuits;

    public GameObject[] HandCard;

    public int cardIndex = 0;

    public List<int> HandCardValues;
    public List<string> HandCardSuits;

    public int money = 1000;

    public virtual void Startinghand()
    {
        GetCard();
    }

    public void GetCard()
    {
        Debug.Log(cardIndex);
        Debug.Log(HandCard.Length);
        this.handCardValueSuits = this.deck.Deal(this.HandCard[this.cardIndex].GetComponent<CardScript>());
        
        Debug.Log("show card");
        this.HandCardValues.Add(handCardValueSuits.Item1);
        this.HandCardSuits.Add(handCardValueSuits.Item2);
        //this.HandCard[cardIndex].GetComponent<Renderer>().enabled = true;

    }

    public void ResetHand()
    {
        for(int i=0; i< this.HandCard.Length; i++)
        {
            this.HandCard[i].GetComponent<CardScript>().ResetCard();
            this.HandCard[i].GetComponent<Renderer>().enabled = false;
        }

        this.cardIndex = 0;
        this.HandCardValues.Clear();
        this.HandCardSuits.Clear();
    }

    public void AdjustMoney(int newMoney)
    {
        this.money += newMoney;
    }

    public int GetMoney()
    {
        return this.money;
    }

    void Start()
    {
        this.HandCardValues = new List<int>();
        this.HandCardSuits = new List<string>();
    }


    
}
