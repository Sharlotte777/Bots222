using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private Base _base;
    [SerializeField] private Text _text;

    private void Update() => UpdateView();

    private void UpdateView() => _text.text = _base.GetScore().ToString();
}
