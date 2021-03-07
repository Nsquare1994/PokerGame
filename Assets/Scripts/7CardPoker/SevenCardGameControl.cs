using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SevenCardGameControl : GameControl
{
    public GameObject[] SelectedCards;

    private List<List<int>> AllPossibleHand = new List<List<int>>
    {
        new List<int>{0,1,2,3,4},
        new List<int>{0,1,2,3,5},
        new List<int>{0,1,2,3,6},
        new List<int>{0,1,2,4,5},
        new List<int>{0,1,2,4,6},
        new List<int>{0,1,2,5,6},
        new List<int>{0,1,3,4,5},
        new List<int>{0,1,3,4,6},
        new List<int>{0,1,3,5,6},
        new List<int>{0,1,4,5,6},
        new List<int>{0,2,3,4,5},
        new List<int>{0,2,3,4,6},
        new List<int>{0,2,3,5,6},
        new List<int>{0,2,4,5,6},
        new List<int>{0,3,4,5,6},
        new List<int>{1,2,3,4,5},
        new List<int>{1,2,3,4,6},
        new List<int>{1,2,4,5,6},
        new List<int>{1,2,4,5,6},
        new List<int>{1,3,4,5,6},
        new List<int>{2,3,4,5,6}
    };
  
    private string GetAutoCompareHandScore(PlayerScript CurrentPlayer)
    {
        List<int> TempValues = new List<int>();
        List<string> TempSuits = new List<string>();
        List<string> AllPossibleScores = new List<string>();

        for(int i = 0; i< this.AllPossibleHand.Count; i++)
        {
            TempValues.Clear();
            TempSuits.Clear();
            for (int j = 0; j < 5; j++)
            {
                TempValues.Add(CurrentPlayer.HandCardValues[AllPossibleHand[i][j]]);
                TempSuits.Add(CurrentPlayer.HandCardSuits[AllPossibleHand[i][j]]);
            }
            AllPossibleScores.Add(Rank.CurrentHandRankScore(TempValues, TempSuits));
        }
        string MaxScore = AllPossibleScores[0];
        for(int i = 0; i < 20; i++)
        {
            if (this.Rank.CompareRank(AllPossibleScores[i], AllPossibleScores[i + 1]) == 1)
                continue;
            else if (this.Rank.CompareRank(AllPossibleScores[i], AllPossibleScores[i + 1]) == 0)
                continue;
            else if (this.Rank.CompareRank(AllPossibleScores[i], AllPossibleScores[i + 1]) == -1)
                MaxScore = AllPossibleScores[i + 1];
        }
        return MaxScore;
    }

    public override void EndRound()
    {
        if(Rank.CompareRank(GetAutoCompareHandScore(Player), GetAutoCompareHandScore(Dealer)) == 1)
        {
            this.Player.AdjustMoney(this.Bet);
            this.CurrentStatusText.text = "You Win!";
            Debug.Log("You Win!");
        }
        else if(Rank.CompareRank(GetAutoCompareHandScore(Player), GetAutoCompareHandScore(Dealer)) == 0)
        {
            this.CurrentStatusText.text = "You Tie!";
            Debug.Log("You Tie!");
        }
        else if (Rank.CompareRank(GetAutoCompareHandScore(Player), GetAutoCompareHandScore(Dealer)) == -1)
        {
            this.Player.AdjustMoney(this.Bet * -1);
            this.CurrentStatusText.text = "You Lose!";
            Debug.Log("You Lose!");
        }
    }

    public override void StartGame()
    {
        base.StartGame();
    }
}
