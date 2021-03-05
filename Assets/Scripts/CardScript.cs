using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{
    public int value = 0;
    public int suit;
    public int GetCardValue()
    {
        return value;
    }

    public void SetCardValue(int NewValue)
    {
        value = NewValue;
    }

    public string GetCardSuit()
    {
        // 0 = club, 1 = diamond, 2 = heart, 3 = spade
        if (suit == 0)
            return "club";
        else if (suit == 1)
            return "diamond";
        else if (suit == 2)
            return "heart";
        else
            return "spade";
    }

    public void SetCardSuit(int NewSuit)
    {
        suit = NewSuit;
    }

    public void SetCardStripe(Sprite newSprite)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
    }

    public void ResetCard()
    {
        Sprite reset = GameObject.Find("deck").GetComponent<DeckScript>().ResetCardStripe();
        gameObject.GetComponent<SpriteRenderer>().sprite = reset;
        value = 0;
    }
}
