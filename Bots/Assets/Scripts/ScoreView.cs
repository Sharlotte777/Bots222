using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private Base _base;
    [SerializeField] private Text _text;
    [SerializeField] private ScoreCounter _counter;

    private void OnEnable()
    {
        _counter.ScoreIsChanged += UpdateView;
    }

    private void OnDisable()
    {
        _counter.ScoreIsChanged -= UpdateView;
    }

    private void UpdateView() => _text.text = _base.GetScore().ToString();
}
