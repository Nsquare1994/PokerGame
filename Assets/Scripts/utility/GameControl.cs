using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Timers;
using UnityEngine.Events;



public class GameControl : MonoBehaviour
{
    public PlayerScript player;
    public PlayerScript dealer;
    public GameObject deck;

    public Button StartButton;
    public Button AutoplayButton;
    public Button Bet50Button;
    public Button Bet100Button;
    public Button Bet500Button;
    public Button RestBetButton;

    public Text AutoplayStatusText;
    public Text CurrentMoneyText;
    public Text CurrentBetText;
    public Text CurrentStatusText;

    public Toggle SameBet;
    bool AutoplayFlag = false;
    
    public int bet = 0;


    public virtual void StartGame()
    {             
        if (this.bet == 0)
        {
            this.CurrentStatusText.text = "No Bet!";
            Debug.Log("No Bet!");
            return;
        }
        if ((this.player.GetMoney() < this.bet) && AutoplayFlag)
        {
            
            this.CurrentStatusText.text = "Not enough money!";
            Debug.Log("Not enough money!");
            CancelInvoke("StartGame");
            return;
        }
              
        this.player.ResetHand();
        this.dealer.ResetHand();
        this.deck.GetComponent<DeckScript>().shuffle();
        this.deck.GetComponent<DeckScript>().currentIndex = 0;
        this.player.Startinghand();
        this.dealer.Startinghand();
        EndRound();
        if (!SameBet.isOn)
        {
            this.bet = 0;
            this.CurrentBetText.text = "Bet: " + this.bet.ToString();

        }      
    }

    public virtual void EndRound()
    {
        this.bet = 0;
    }

    public void Autoplay()
    {
        if (this.AutoplayFlag)
        {
            this.AutoplayFlag = false;
            this.AutoplayStatusText.text = "Autoplay: Off";
        }
        else
        {
            this.AutoplayFlag = true;
            this.AutoplayStatusText.text = "Autoplay: On";
        }

        if (this.AutoplayFlag && (this.player.GetMoney() >= this.bet) && (this.player.GetMoney()!=0) && (this.bet!=0))
        {
            if (this.bet == 0)
            {
                this.CurrentStatusText.text = "No Bet!";
                Debug.Log("No Bet!");
                return;
            }
            InvokeRepeating("StartGame", 0, 2);
        }
        else
            CancelInvoke("StartGame");
    }

    private void Start()
    {
        this.CurrentMoneyText.text = "Money: " + this.player.GetMoney().ToString();
        this.CurrentBetText.text = "Bet: " + this.bet.ToString();

        this.StartButton.onClick.AddListener(() => StartGame());
        this.AutoplayButton.onClick.AddListener(() => Autoplay());
        this.Bet50Button.onClick.AddListener(() => Bet());
        this.Bet100Button.onClick.AddListener(() => Bet());
        this.Bet500Button.onClick.AddListener(() => Bet());
        this.RestBetButton.onClick.AddListener(() => ResetBet());
        this.SameBet.onValueChanged.AddListener((value) => OnSameBetChanged(value));      
    }

    private void OnSameBetChanged(bool value)
    {
        if (value)
        {
            this.player.AdjustMoney(this.bet * -1);
            this.CurrentMoneyText.text = this.CurrentMoneyText.text = "Money: " + this.player.GetMoney().ToString();
        }
        else
            ResetBet();
    }

    private void ResetBet()
    {
        this.CurrentMoneyText.text = "Money: " + this.player.GetMoney().ToString();
        this.bet = 0;
        this.CurrentBetText.text = "Bet: " + this.bet.ToString();
    }

    private void Bet()
    {
        int amount = int.Parse(EventSystem.current.currentSelectedGameObject.name.ToString());
        if (amount > this.player.GetMoney())
        {
            this.CurrentStatusText.text = "Not enough money!";
            Debug.Log("Not enough money!");
            return;
        }
        else
        {
            this.bet += amount;
            this.CurrentMoneyText.text = this.CurrentMoneyText.text = "Money: " + (this.player.GetMoney()-this.bet).ToString();
            this.CurrentBetText.text = "Bet: " + this.bet.ToString();          
        }

    }

}
  

