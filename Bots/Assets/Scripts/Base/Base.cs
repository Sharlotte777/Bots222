using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ScoreCounter))]
public class Base : MonoBehaviour
{
    [SerializeField] private List<Robot> _units;

    private ScoreCounter _scoreCounter;

    public string Name { get; private set; }

    public List<Robot> GetUnits() => _units;

    private void Awake()
    {
        _scoreCounter = GetComponent<ScoreCounter>();
    }

    public int GetScore() => _scoreCounter.Score;

    public void AddScore() => _scoreCounter.AddScore();
}
