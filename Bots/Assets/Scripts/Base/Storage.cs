using System;
using UnityEngine;

public class Storage : MonoBehaviour
{
    public event Action ValueChanged;

    public int Score { get; private set; }

    public void SpendPoints(int value)
    {
        if (Score > value)
        {
            Score -= value;
        }
        else
        {
            Score = 0;
        }
    }

    public void AddScore()
    { 
        Score++;
    }

    public void ActiveEvent()
    {
        ValueChanged?.Invoke();
    }
}