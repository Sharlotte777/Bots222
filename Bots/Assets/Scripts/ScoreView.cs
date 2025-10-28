using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private CheckerValue _checkerValue;
    [SerializeField] private ScoreCounter _counter;

    private Text _text;

    private void OnEnable()
    {
        _checkerValue.ValueChanged += UpdateView;
    }

    private void OnDisable()
    {
        _checkerValue.ValueChanged -= UpdateView;
    }

    public void UpdateView()
    {
        _text.text = _counter.Score.ToString();
    }

    public void SetText(Text text)
    {
        _text = text;
    }
}