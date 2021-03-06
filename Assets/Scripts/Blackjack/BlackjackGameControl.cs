using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class BlackjackGameControl : GameControl
{
    public Button HitButton;
    public Button StandButton;

    public Slider AutoplayValueSlide;

    // Start is called before the first frame update
    void Start()
    {
        this.HitButton.onClick.AddListener(() => HitPressed());
        this.StandButton.onClick.AddListener(() => StandPressed());
        this.StartButton.onClick.AddListener(() => StartGame());
        this.AutoplayButton.onClick.AddListener(() => AutoplayClicked());
        this.Bet50Button.onClick.AddListener(() => BetButtonPressed());
        this.Bet100Button.onClick.AddListener(() => BetButtonPressed());
        this.Bet500Button.onClick.AddListener(() => BetButtonPressed());
        this.RestBetButton.onClick.AddListener(() => ResetBetPressed());
    }

    private void StandPressed()
    {
        if (Dealer.HandCardValues.Sum() >= Player.HandCardValues.Sum())
            EndRound();
        else
            HitDealer();
    }

    private void HitDealer()
    {
        while(Dealer.HandCardValues.Sum() < Player.HandCardValues.Sum() && Dealer.cardIndex < 10)
        {
            Dealer.GetCard();
            if (Dealer.HandCardValues.Sum() >= Player.HandCardValues.Sum())
                EndRound();
        }
    }

    private void HitPlayer()
    {
        if (Player.HandCardValues.Sum() > AutoplayValueSlide.value)
            StandPressed();
        while (Player.HandCardValues.Sum() < AutoplayValueSlide.value && Dealer.cardIndex < 10)
        {
            Dealer.GetCard();
            if (Dealer.HandCardValues.Sum() >= AutoplayValueSlide.value)
                EndRound();
        }
    }

    private void HitPressed()
    {
        if(Player.cardIndex<10)
        {
            Player.GetCard();
            if (Player.HandCardValues.Sum() > 20)
                EndRound();
        }
    }

    public override void EndRound()
    {
        bool PlayerBust = Player.HandCardValues.Sum() > 21;
        bool DealerBust = Dealer.HandCardValues.Sum() > 21;
        bool Player21 = Player.HandCardValues.Sum() == 21;
        bool Dealer21 = Dealer.HandCardValues.Sum() == 21;

        //bool EndGame = true;

        if (!PlayerBust && !DealerBust && !Player21 && !Dealer21)
            return;

        if(PlayerBust || (!DealerBust && Dealer.HandCardValues.Sum() > Player.HandCardValues.Sum()))
        {
            Debug.Log("You Lose!");
            Player.AdjustMoney(Bet * -1);
        }
        else if(DealerBust || (!PlayerBust && Player.HandCardValues.Sum() > Dealer.HandCardValues.Sum()))
        {
            Debug.Log("You Win!");
            Player.AdjustMoney(Bet);
        }
        else if(Player.HandCardValues.Sum() == Dealer.HandCardValues.Sum())
        {
            Debug.Log("You Tie!");       
        }

    }
}
