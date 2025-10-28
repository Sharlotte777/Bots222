using System;
using UnityEngine;

public class CheckerValue : MonoBehaviour
{
    private const int NumberOfNewUnit = 3;
    private const int NumberOfNewBase = 5;

    [SerializeField] private FlagPlacer _flagPlacer;
    [SerializeField] private ControllerOfUnits _controllerOfUnits;
    [SerializeField] private ScoreCounter _scoreCounter;

    public event Action ValueChanged;
    public event Action ValueCollectedForUnit;
    public event Action ValueCollectedForBase;

    private void Update()
    {
        if ((_scoreCounter.Score >= NumberOfNewBase) && (_controllerOfUnits.GetCount() > 1))
        {
            if (_flagPlacer.Flag.Placed == true)
            {
                AddValue();
                ValueCollectedForBase?.Invoke();
                _scoreCounter.Reset();
                ValueChanged?.Invoke();
            }
        }
        else
        {
            if ((_flagPlacer.Flag.Placed == false) || ((_flagPlacer.Flag.Placed == true) && (_controllerOfUnits.GetCount() == 1)))
            {
                if (_scoreCounter.Score >= NumberOfNewUnit)
                {
                    AddValue();
                    ValueCollectedForUnit?.Invoke();
                    _scoreCounter.Reset();
                    ValueChanged?.Invoke();
                }
            }
        }
    }

    public void AddValue()
    {
        _scoreCounter.AddScore();
        ValueChanged?.Invoke();
    }
}