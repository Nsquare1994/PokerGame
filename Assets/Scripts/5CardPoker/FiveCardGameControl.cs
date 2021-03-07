using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiveCardGameControl : GameControl
{
    public override void EndRound()
    {
        this.Rank = new HandRank();
        if(this.Rank.CompareRank(this.Rank.CurrentHandRankScore(this.Player.HandCardValues, this.Player.HandCardSuits)
                                ,this.Rank.CurrentHandRankScore(this.Dealer.HandCardValues, this.Dealer.HandCardSuits)) == 1)
        {
            this.Player.AdjustMoney(this.Bet);
            this.CurrentStatusText.text = "You Win!";
            Debug.Log("You Win!");
        }
        else if(this.Rank.CompareRank(this.Rank.CurrentHandRankScore(this.Player.HandCardValues, this.Player.HandCardSuits)
               ,this.Rank.CurrentHandRankScore(this.Dealer.HandCardValues, this.Dealer.HandCardSuits)) == 0)
        {
            this.CurrentStatusText.text = "You Tie!";
            Debug.Log("You Tie!");
        }
        else if (this.Rank.CompareRank(this.Rank.CurrentHandRankScore(this.Player.HandCardValues, this.Player.HandCardSuits)
               , this.Rank.CurrentHandRankScore(this.Dealer.HandCardValues, this.Dealer.HandCardSuits)) == -1)
        {
            this.Player.AdjustMoney(this.Bet * -1);
            this.CurrentStatusText.text = "You Lose!";
            Debug.Log("You Lose!");
        }
    }
}
