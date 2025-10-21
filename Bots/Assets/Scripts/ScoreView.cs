using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private ScoreCounter _counter;

    private Text _text;

    private void OnEnable()
    {
        _counter.ScoreIsChanged += UpdateView;
    }

    private void OnDisable()
    {
        _counter.ScoreIsChanged -= UpdateView;
    }

    public void UpdateView()
    {
        _text.text = _counter.Score.ToString();
    }

    public void SetText(Text text) => _text = text;
}