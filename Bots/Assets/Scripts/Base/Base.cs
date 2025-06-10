using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ScoreCounter))]
public class Base : MonoBehaviour
{
    [SerializeField] private List<Robot> _units;

    private ScoreCounter _scoreCounter;
    //private Scanner _scanner;
    //private Sender _sender;

    public string Name { get; private set; }

    public List<Robot> GetUnits() => _units;

    private void Awake()
    {
        //_scanner = GetComponent<Scanner>();
        _scoreCounter = GetComponent<ScoreCounter>();
        //_sender = GetComponent<Sender>();
        //_sender.AssignUnits(_units);
        //_scanner.AssignSender(_sender);
    }

    public int GetScore() => _scoreCounter.Score;
    public void AddScore() => _scoreCounter.AddScore();
}
