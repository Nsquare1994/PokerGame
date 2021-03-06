using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLoGameControl : GameControl
{

    public override void EndRound()
    {
        if (this.Player.HandCardValues[0] == 1)
            this.Player.HandCardValues[0] = 14;

        if (this.Dealer.HandCardValues[0] == 1)
            this.Dealer.HandCardValues[0] = 14;

        if (this.Player.HandCardValues[0] > this.Dealer.HandCardValues[0])
        {
            this.Player.AdjustMoney(this.Bet);
            this.CurrentStatusText.text = "You Win!";
            Debug.Log("You Win!");
        }
        else if (this.Player.HandCardValues[0] == this.Dealer.HandCardValues[0])
        {        
            this.CurrentStatusText.text = "You Tie!";
            Debug.Log("You Tie!");
        }
        else if(this.Player.HandCardValues[0] < this.Dealer.HandCardValues[0])
        {
            this.Player.AdjustMoney(this.Bet * -1);      
            this.CurrentStatusText.text = "You Lose!";
            Debug.Log("You Lose!");
        }
    }
}
    
