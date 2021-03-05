using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighLoGameControl : GameControl
{

    public override void EndRound()
    {
        // set ace as high
        if (this.player.score == 1)
            this.player.score = 14;

        if (this.dealer.score == 1)
            this.dealer.score = 14;


        if (this.player.score > this.dealer.score)
            Debug.Log("You Win!");
        else if (this.player.score == this.dealer.score)
            Debug.Log("You Tie!");
        else
            Debug.Log("You Lose!");

    }
}
    
