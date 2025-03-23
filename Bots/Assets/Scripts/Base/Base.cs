using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Scanner))]
[RequireComponent(typeof(Sender))]
[RequireComponent(typeof(ScoreCounter))]
public class Base : MonoBehaviour
{
    [SerializeField] private List<Robot> _units;

    private ScoreCounter _scoreCounter;
    private Scanner _scanner;
    private Sender _sender;

    private void Awake()
    {
        _scanner = GetComponent<Scanner>();
        _scoreCounter = GetComponent<ScoreCounter>();
        _sender = GetComponent<Sender>();
        _sender.GetUnits(_units);
        _scanner.GetSender(_sender);
    }

    public int GetScore() => _scoreCounter.Score;
    public void AddScore() => _scoreCounter.AddScore();
}
