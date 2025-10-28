using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public int Score { get; private set; }

    public void Reset()
    {
        Score = 0;
    }

    public void AddScore()
    { 
        Score++;
    }
}