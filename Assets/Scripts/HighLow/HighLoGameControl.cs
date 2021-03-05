using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLoGameControl : GameControl
{

    public override void EndRound()
    {
        // set ace as high
        if (this.player.HandCardValue == 1)
            this.player.HandCardValue = 14;

        if (this.dealer.HandCardValue == 1)
            this.dealer.HandCardValue = 14;

        Debug.Log(this.bet);

        if (this.player.HandCardValue > this.dealer.HandCardValue)
        {
            this.player.AdjustMoney(this.bet);
            this.CurrentMoneyText.text = "Money: " + this.player.GetMoney().ToString();
            this.CurrentStatusText.text = "You Win!";
            Debug.Log("You Win!");
        }
        else if (this.player.HandCardValue == this.dealer.HandCardValue)
        {
            this.CurrentMoneyText.text = "Money: " + this.player.GetMoney().ToString();
            this.CurrentStatusText.text = "You Tie!";
            Debug.Log("You Tie!");
        }
        else if(this.player.HandCardValue < this.dealer.HandCardValue)
        {
            this.player.AdjustMoney(this.bet*-1);
            this.CurrentMoneyText.text = "Money: " + this.player.GetMoney().ToString();
            this.CurrentStatusText.text = "You Lose!";
            Debug.Log("You Lose!");
        }


        
        Debug.Log(this.player.GetMoney());

        

    }
}
    
