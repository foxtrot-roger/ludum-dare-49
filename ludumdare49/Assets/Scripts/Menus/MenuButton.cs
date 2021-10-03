using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{

    Text text;
    Color normalColor;

    public Color SelectedColor;

    void Start()
    {
        text = GetComponentInChildren<Text>();
        normalColor = text.color;
    }

    void OnEnable()
    {
        Normal();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Hover();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Normal();
    }

    public void OnSelect(BaseEventData eventData)
    {
        Hover();
    }

    public void OnDeselect(BaseEventData eventData)
    {
        Normal();
    }

    public void Normal()
    {
        if (text != null)
            text.color = normalColor;
    }
    public void Hover()
    {
        if (text != null)
            text.color = SelectedColor;
    }
}