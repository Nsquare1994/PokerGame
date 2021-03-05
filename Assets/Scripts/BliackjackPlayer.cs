using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BliackjackPlayer : PlayerScript
{
    List<CardScript> aces = new List<CardScript>();

    // override starting hand due to different game
    public override void Startinghand()
    {
        GetCard();
        GetCard();
    }

    public void aceCheck()
    {

    }
}
