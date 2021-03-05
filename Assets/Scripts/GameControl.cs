using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;


public class GameControl : MonoBehaviour
{
    public PlayerScript player;
    public PlayerScript dealer;
    public GameObject deck;

    public Button StartButton;
    public Button AutoplayButton;

    bool AutoplayFlag = false;
    private float timer = 2.1f;
    private float pauseTime = 2.0f;

    public int bet = 0;

    public virtual void StartGame()
    {
        // reset hand
        this.player.ResetHand();
        this.dealer.ResetHand();
        // shuffle
        this.deck.GetComponent<DeckScript>().shuffle();
        //deal card
        this.deck.GetComponent<DeckScript>().currentIndex = 0;
        this.player.Startinghand();
        this.dealer.Startinghand();
        EndRound();
    }

    public virtual void EndRound()
    {

    }

    public void Autoplay()
    {    
        // change autoplay status
        if (this.AutoplayFlag)
            this.AutoplayFlag = false;
        else
            this.AutoplayFlag = true;  
    }

    private void Start()
    {
        this.StartButton.onClick.AddListener(() => StartGame());
        this.AutoplayButton.onClick.AddListener(() => Autoplay());

    }

    private void Update()
    {
        // if autoplay = true && money >0
        if(this.AutoplayFlag) // && palyer.money > bet)
        {
            this.timer += Time.deltaTime;

            if(this.timer>this.pauseTime)
            {
                StartGame();
                this.timer = 0.0f;
            }
        }
        
    }
}
  

