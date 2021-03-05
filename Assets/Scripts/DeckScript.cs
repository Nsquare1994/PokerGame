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
        CardSeq = Enumerable.Range(0, 52).OrderBy(x => rnd.Next()).Take(52).ToList();

    }

    public int Deal(CardScript cardScript)
    {
        

        cardScript.SetCardStripe(cards[CardSeq[currentIndex]]);
        cardScript.SetCardValue((CardSeq[currentIndex] % 13) + 1);
        cardScript.SetCardSuit(CardSeq[currentIndex] / 13);
        currentIndex++;

        //Debug.Log(cardScript.GetCardValue());
        //Debug.Log(cardScript.GetCardSuit());

        

        return cardScript.GetCardValue();
    }

    public Sprite ResetCardStripe()
    {
        return cards[52];
    }

}
