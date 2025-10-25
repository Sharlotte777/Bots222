using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private const int NumberOfNewUnit = 3;
    private const int NumberOfNewBase = 5;

    [SerializeField] private FlagPlacer _flagPlacer;
    [SerializeField] private ControllerOfUnits _controllerOfUnits;

    public event Action ValueChanged;
    public event Action ValueCollectedForUnit;
    public event Action ValueCollectedForBase;

    public int Score { get; private set; }

    private void Update()
    {
        if ((Score >= NumberOfNewBase) && (_controllerOfUnits.GetCount() > 1))
        {
            if (_flagPlacer.Flag.Placed == true)
            {
                AddScore();
                ValueCollectedForBase?.Invoke();
                Score = 0;
                ValueChanged?.Invoke();
            }
        }
        else
        {
            if ((_flagPlacer.Flag.Placed == false) || ((_flagPlacer.Flag.Placed == true) && (_controllerOfUnits.GetCount() == 1)))
            {
                if (Score >= NumberOfNewUnit)
                {
                    AddScore();
                    ValueCollectedForUnit?.Invoke();
                    Score = 0;
                    ValueChanged?.Invoke();
                }
            }
        }
    }

    public void AddScore()
    { 
        Score++;
        ValueChanged?.Invoke();
    }
}