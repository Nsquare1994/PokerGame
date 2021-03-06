using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HandRank : MonoBehaviour
{
    

    private string CurrentHandRank(List<int> values, List<string> suits)
    {

        return "123";
    }

    private bool IsRoyalFlush(List<int> values, List<string> suits)
    {
        values.Sort();
        for(int i =0; i< values.Count(); i++)
        {

        }
        return true;
            
    }

    private bool IsStraightFlush(List<int> values, List<string> suits)
    {
        values.Sort();
        if (values[0] == values[1] - 1 && values[1] == values[2] - 1 && values[2] == values[3] - 1 && values[3] == values[4] - 1
           && (suits.Distinct().Count() == 1))
            return true;
        else
            return false;
    }
    private bool IsFourOfAKind(List<int> values, List<string> suits)
    {
        return true;
    }
    private bool IsFullHouse(List<int> values, List<string> suits)
    {
        return true;
    }
    private bool IsFlush(List<int> values, List<string> suits)
    {
        return true;
    }
    private bool IsStraight(List<int> values, List<string> suits)
    {
        return true;
    }
    private bool IsThreeOfAKind(List<int> values, List<string> suits)
    {
        return true;
    }
    private bool IsTwoPair(List<int> values, List<string> suits)
    {
        return true;
    }
    private bool IsPair(List<int> values, List<string> suits)
    {
        return true;
    }
    private bool IsHighCard(List<int> values, List<string> suits)
    {
        return true;
    }
    
    private Dictionary<int, int> PreProcessCards(List<int> values, List<string> suits)
    {
        Dictionary<int, int> HoldCardsDict = new Dictionary<int, int>();
        for(int i = 0; i < values.Count(); i++)
        {
            if (HoldCardsDict.ContainsKey(values[i]))
                HoldCardsDict[values[i]] = HoldCardsDict[values[i]] + 1;
            else
                HoldCardsDict.Add(values[i], 1);
        }

        return HoldCardsDict;
    }
    private void Start()
    {
        Dictionary<int, Dictionary<string, int>> HoldCardsDict = new Dictionary<int, Dictionary<string, int>>();

    }
}
