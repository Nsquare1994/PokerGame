using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SevenCardPlayer : PlayerScript
{
    public override void Startinghand()
    {
        GetCard();
        GetCard();
        GetCard();
        GetCard();
        GetCard();
        GetCard();
        GetCard();
    }
}
