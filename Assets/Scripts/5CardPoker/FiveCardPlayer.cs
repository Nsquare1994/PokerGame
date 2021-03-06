using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiveCardPlayer : PlayerScript
{
    public override void Startinghand()
    {
        //5 Card deal card
        GetCard();
        GetCard();      
        GetCard();     
        GetCard();     
        GetCard();     
    }

    public void HandSeq()
    {
        // high card < pair < 2 pairs < three of a kind < straight < flush < fullhouse < four of a kind < straight flush < royal flush
    }

    private void Start()
    {
        
    }
}
