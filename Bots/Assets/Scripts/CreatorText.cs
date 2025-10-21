using UnityEngine;
using UnityEngine.UI;

public class CreatorText : MonoBehaviour
{
    private Base _base;
    private int _additionalValue = 50;

    public CreatorText(Base basa)
    {
        _base = basa;
    }

    public void CreateText()
    {
        Vector3 position = _base.transform.position;
        GameObject textObject = new GameObject();
        Text text = textObject.AddComponent<Text>();
        text.text = "0";
        text.color = Color.black;
        text.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        RectTransform rectTransform = textObject.GetComponent<RectTransform>();
        rectTransform.SetParent(GameObject.Find("Canvas").transform);
        position.y += _additionalValue;
        rectTransform.position = position;
        rectTransform.rotation = Quaternion.Euler(0,180,0);
        rectTransform.sizeDelta = new Vector2(30, 30);
        text.alignment = TextAnchor.MiddleCenter;
        _base.InstallText(text);
    }
}