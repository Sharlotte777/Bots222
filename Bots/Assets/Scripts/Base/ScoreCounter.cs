using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public event Action ScoreIsChanged;

    public int Score { get; private set; }

    public void AddScore()
    { 
        Score++;
        ScoreIsChanged?.Invoke();
    }
}
