using UnityEngine;
using UnityEngine.UI;

[RequireComponent((typeof(FlagPlacer)))]
[RequireComponent((typeof(ControllerOfUnits)))]
[RequireComponent((typeof(ScoreView)))]
[RequireComponent((typeof(CreatorUnit)))]
[RequireComponent(typeof(Storage))]
public class Base : MonoBehaviour
{
    private const int NumberOfNewUnit = 3;
    private const int NumberOfNewBase = 5;

    private FlagPlacer _flagPlacer;
    private CreatorUnit _creatorUnit;
    private ControllerOfUnits _controllerOfUnits;
    private ScoreView _scoreView;
    private Storage _scoreCounter;

    private void Awake()
    {
        _flagPlacer = GetComponent<FlagPlacer>();
        _controllerOfUnits = GetComponent<ControllerOfUnits>();
        _creatorUnit = GetComponent<CreatorUnit>();
        _scoreView = GetComponent<ScoreView>();
        _scoreCounter = GetComponent<Storage>();
    }

    private void OnEnable()
    {
        _scoreCounter.ValueChanged += HandleScoreChange;
    }

    private void OnDisable()
    {
        _scoreCounter.ValueChanged -= HandleScoreChange;
    }

    public void InstallText(Text text)
    {
        _scoreView.SetText(text);
    }

    public void PlaceFlag(Vector3 position)
    {
        if (_flagPlacer.Flag != null)
        {
            _flagPlacer.MoveFlag(position);
        }
        else
        {
            _flagPlacer.PlaceFlag(position);
        }
    }

    private void HandleScoreChange()
    {
        if ((_scoreCounter.Score >= NumberOfNewBase) && (_controllerOfUnits.GetCount() > 1))
        {
            if (_flagPlacer.Flag.Placed == true)
            {
                _controllerOfUnits.SendRobotToFlag();
                _scoreCounter.SpendPoints(NumberOfNewBase);
                _scoreCounter.ActiveEvent();
            }
        }
        else
        {
            if ((_flagPlacer.Flag.Placed == false) || ((_flagPlacer.Flag.Placed == true) && (_controllerOfUnits.GetCount() == 1)))
            {
                if (_scoreCounter.Score >= NumberOfNewUnit)
                {
                    _creatorUnit.CreateUnit();
                    _scoreCounter.SpendPoints(NumberOfNewUnit);
                    _scoreCounter.ActiveEvent();
                }
            }
        }
    }

    public Vector3 GetFlagPosition()
    {
        return _flagPlacer.Flag.Position;
    }

    public void AddScore()
    {
        _scoreCounter.AddScore();
        _scoreCounter.ActiveEvent();
    }
}