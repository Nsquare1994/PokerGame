using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class DeckScript : MonoBehaviour
{
    public Sprite[] cards;
    public List<int> CardSeq;
    public int currentIndex = 0;
    
    public void shuffle()
    {
        System.Random rnd = new System.Random();
        this.CardSeq = Enumerable.Range(0, 52).OrderBy(x => rnd.Next()).Take(52).ToList();

    }

    public Tuple<int,string>  Deal(CardScript cardScript)
    {
        

        cardScript.SetCardStripe(this.cards[this.CardSeq[this.currentIndex]]);
        cardScript.SetCardValue((this.CardSeq[this.currentIndex] % 13) + 1);
        cardScript.SetCardSuit(this.CardSeq[this.currentIndex] / 13);
        this.currentIndex++;

        //Debug.Log(cardScript.GetCardValue());
        //Debug.Log(cardScript.GetCardSuit());

        

        return Tuple.Create(cardScript.GetCardValue(), cardScript.GetCardSuit());
    }


    public Sprite TurnToCardBack()
    {
        return this.cards[52];
    }

}
