﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class HandRank : MonoBehaviour
{
    public string CurrentHandRankScore(List<int> values, List<string> suits)
    {
        string score;
        values.Sort();

        if (IsFlush(suits))
        {
            if (IsStraight(values).Item1)
            {
                Debug.Log("straight flush");
                Debug.Log(IsStraight(values).Item2);
                if(IsStraight(values).Item2)
                    return score = "9" + values[values.Count - 2].ToString();
                else
                    return score = "9" + values[values.Count - 1].ToString();
            }

            else
            {
                Debug.Log("flush");
                Debug.Log(values[values.Count - 1]);
                score = "6";
                for (int i = values.Count - 1; i >= 0; i--)
                    score += values[i].ToString();
                return score;
            }
        }
        else
        {
            if(IsStraight(values).Item1)
            {
                Debug.Log("straight");
                Debug.Log(values[values.Count - 1]);
                if (IsStraight(values).Item2)
                    return score = "5" + values[values.Count - 2].ToString();
                else
                    return score = "5" + values[values.Count - 1].ToString();
            }

            else 
            {
                if (IsFourOfAKind(values).Item1)
                {
                    Debug.Log("4 of a kind");
                    Debug.Log(IsFourOfAKind(values).Item2);
                    return score = "8" + IsFourOfAKind(values).Item2.ToString();
                }
                else
                {
                    if (IsFullHouse(values).Item1)
                    {
                        Debug.Log("fullhouse");
                        Debug.Log(IsFullHouse(values).Item2);
                        return score = "7" + IsFullHouse(values).Item2.ToString();
                    }
                    else
                    {
                        if (IsThreeOfAKind(values).Item1)
                        {
                            Debug.Log("3 of a kind");
                            Debug.Log(IsThreeOfAKind(values).Item2);
                            return score = "4" + IsThreeOfAKind(values).Item2.ToString();
                        }
                        else if (IsTwoPair(values).Item1)
                        {
                            Debug.Log("2pair");
                            Debug.Log(IsTwoPair(values).Item2);
                            Debug.Log(IsTwoPair(values).Item3);
                            Debug.Log(IsTwoPair(values).Item4);
                            return score = "3" + IsTwoPair(values).Item2.ToString()
                                               + IsTwoPair(values).Item3.ToString()
                                               + IsTwoPair(values).Item4.ToString();
                        }
                        else
                        {
                            if (IsPair(values).Item1)
                            {
                                Debug.Log("pair");
                                Debug.Log(IsPair(values).Item2);
                                Debug.Log(IsPair(values).Item3);
                                Debug.Log(IsPair(values).Item4);
                                Debug.Log(IsPair(values).Item5);
                                return score = "2" + IsPair(values).Item2.ToString()
                                                   + IsPair(values).Item3.ToString()
                                                   + IsPair(values).Item4.ToString()
                                                   + IsPair(values).Item5.ToString();
                            }
                            else
                            {
                                Debug.Log("highcard");
                                Debug.Log(values[values.Count - 1]);
                                score = "1";
                                for (int i = values.Count - 1; i >= 0; i--)
                                    score += values[i].ToString();
                                return score;
                            }
                        }
                    }


                }
            }
        }
    }
    public int CompareRank(string PalyerHandRankScore, string DealerHandRankScore)
    {
        int PalyerHandRankScoreRank1 = int.Parse(PalyerHandRankScore.Substring(0, 1));
        int DealerHandRankScoreRank1 = int.Parse(DealerHandRankScore.Substring(0, 1));

        if (PalyerHandRankScoreRank1 > DealerHandRankScoreRank1)
            return 1;
        else if (PalyerHandRankScoreRank1 == DealerHandRankScoreRank1)
        {
            int PalyerHandRankScoreRank2 = int.Parse(PalyerHandRankScore.Substring(1));
            int DealerHandRankScoreRank2 = int.Parse(DealerHandRankScore.Substring(1));

            if (PalyerHandRankScoreRank2 > DealerHandRankScoreRank2)
                return 1;
            else if (PalyerHandRankScoreRank2 == DealerHandRankScoreRank2)
                return 0;
            else
                return -1;
        }
        else if (PalyerHandRankScoreRank1 < DealerHandRankScoreRank1)
            return -1;
        else
            return -32767;
    }
    private Tuple<bool, int> IsFourOfAKind(List<int> values)
    {
        values.Sort();
        if (values[0] == values[1] && values[1] == values[2] && values[2] == values[3])
            return Tuple.Create(true, values[0]);
        else if (values[1] == values[2] && values[2] == values[3] && values[3] == values[4])
            return Tuple.Create(true, values[1]);
        else
            return Tuple.Create(false, 0);
    }
    private Tuple<bool, int> IsFullHouse(List<int> values)
    {
        if (values[0] == values[1] && values[1] == values[2] && values[3] == values[4])
            return Tuple.Create(true, values[0]);
        else if (values[2] == values[3] && values[3] == values[4] && values[0] == values[1])
            return Tuple.Create(true, values[2]);
        else
            return Tuple.Create(false,0);
    }
    private bool IsFlush(List<string> suits)
    {
        if (suits.Distinct().Count() == 1)
            return true;
        else
            return false;
    }
    private Tuple<bool, bool> IsStraight(List<int> values)
    {
        if (values[0] == values[1] - 1 && values[1] == values[2] - 1 && values[2] == values[3] - 1 && values[3] == values[4] - 1)
            return Tuple.Create(true, false);
        else if (values[0] == 2 && values[1] == 3 && values[2] == 4 && values[3] == 5 && values[4] == 14)
            return Tuple.Create(true, true);
        else
            return Tuple.Create(false, false);
    }
    private Tuple<bool, int> IsThreeOfAKind(List<int> values)
    {
        if (values[0] == values[1] && values[1] == values[2])
            return Tuple.Create(true, values[0]);
        else if (values[1] == values[2] && values[2] == values[3])
            return Tuple.Create(true, values[1]);
        else if (values[2] == values[3] && values[3] == values[4])
            return Tuple.Create(true, values[2]);
        else
            return Tuple.Create(false, 0);
    }
    private Tuple<bool, int, int, int> IsTwoPair(List<int> values)
    {
        values.Sort();
        if (values[0] == values[1] && values[2] == values[3])
            return Tuple.Create(true, values[2], values[0], values[4]);
        else if (values[1] == values[2] && values[3] == values[4])
            return Tuple.Create(true, values[3], values[1], values[0]);
        else if (values[0] == values[1] && values[3] == values[4])
            return Tuple.Create(true, values[3], values[0], values[2]);
        else
            return Tuple.Create(false,0,0,0);
    }
    private Tuple<bool, int, int, int, int> IsPair(List<int> values)
    {
        if (values[0] == values[1])
            return Tuple.Create(true, values[0], values[4], values[3], values[2]);
        else if (values[1] == values[2])
            return Tuple.Create(true, values[1], values[4], values[3], values[0]);
        else if (values[2] == values[3])
            return Tuple.Create(true, values[2], values[4], values[1], values[0]);
        else if (values[3] == values[4])
            return Tuple.Create(true, values[3], values[2], values[1], values[0]);
        else
            return Tuple.Create(false,0,0,0,0);
    }
    
}
    

