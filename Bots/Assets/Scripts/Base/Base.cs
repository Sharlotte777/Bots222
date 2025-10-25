using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent((typeof(CreatorUnit)))]
public class Base : MonoBehaviour
{
    private ScoreCounter _scoreCounter;
    private FlagPlacer _flafPlacer;
    private CreatorUnit _creatorUnit;
    private ControllerOfUnits _controllerOfUnits;
    private ScoreView _scoreView;

    private void Awake()
    {
        _flafPlacer = GetComponent<FlagPlacer>();
        _controllerOfUnits = GetComponent<ControllerOfUnits>();
        _scoreCounter = GetComponent<ScoreCounter>();
        _creatorUnit = GetComponent<CreatorUnit>();
        _scoreView = GetComponent<ScoreView>();
    }

    private void OnEnable()
    {
        _scoreCounter.ValueCollectedForUnit += _creatorUnit.CreateUnit;
        _scoreCounter.ValueCollectedForBase += _controllerOfUnits.SendRobotToFlag;
    }

    private void OnDisable()
    {
        _scoreCounter.ValueCollectedForUnit -= _creatorUnit.CreateUnit;
        _scoreCounter.ValueCollectedForBase -= _controllerOfUnits.SendRobotToFlag;
    }

    public void AddUnit(Robot robot)
    {
        _controllerOfUnits.AddNewUnit(robot);
    }

    public void InstallText(Text text)
    {
        _scoreView.SetText(text);
    }

    public void SetFlag(Vector3 position)
    {
        if (_flafPlacer.Flag != null)
        {
            _flafPlacer.MoveFlag(position);
        }
        else
        {
            _flafPlacer.PlaceFlag(position);
        }
    }

    public List<Robot> GetUnits()
    {
        List<Robot> units = new List<Robot>();

        foreach (Robot unit in _controllerOfUnits.GetUnits())
        {
            units.Add(unit);
        }

        return units;
    }

    public void AddScore() => _scoreCounter.AddScore();
}
