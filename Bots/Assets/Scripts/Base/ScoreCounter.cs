using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private const int NumberOfNewUnit = 3;
    private const int NumberOfNewBase = 5;

    [SerializeField] private FlagPlacer _flagPlacer;

    public int Score { get; private set; }

    public event Action ScoreIsChanged;
    public event Action ScoreIsCollectedForUnit;
    public event Action ScoreIsCollectedForBase;

    private void Update()
    {
        if (Score >= NumberOfNewBase)
        {
            if (_flagPlacer.Flag.IsPlaced == true)
            {
                AddScore();
                ScoreIsCollectedForBase?.Invoke();
                Score = 0;
                ScoreIsChanged?.Invoke();
            }
        }
        else
        {
            if (_flagPlacer.Flag.IsPlaced == false)
            {
                if (Score >= NumberOfNewUnit)
                {
                    AddScore();
                    ScoreIsCollectedForUnit?.Invoke();
                    Score = 0;
                    ScoreIsChanged?.Invoke();
                }
            }
        }
    }

    public void AddScore()
    { 
        Score++;
        ScoreIsChanged?.Invoke();
    }
}