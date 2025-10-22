using System;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private const int NumberOfNewUnit = 3;
    private const int NumberOfNewBase = 5;

    [SerializeField] private FlagPlacer _flagPlacer;
    [SerializeField] private ControllerOfUnits _controllerOfUnits;

    public int Score { get; private set; }

    public event Action ScoreIsChanged;
    public event Action ScoreIsCollectedForUnit;
    public event Action ScoreIsCollectedForBase;

    private void Update()
    {
        if ((Score >= NumberOfNewBase) && (_controllerOfUnits.GetCount() > 1))
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
            if ((_flagPlacer.Flag.IsPlaced == false) || ((_flagPlacer.Flag.IsPlaced == true) && (_controllerOfUnits.GetCount() == 1)))
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