using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterFitter : MonoBehaviour
{
    [SerializeField] Text counter;
    [SerializeField] RectTransform bg;
    [SerializeField] int minDigits;
    [SerializeField] float minSize, deltaSize;
    public void SetCounterTo(int to)
    {
        counter.text = to.ToString();
        int digits = 1;
        for (; to >= 10; digits++)
            to /= 10;
        if (digits <= minDigits)
        {
            bg.sizeDelta = new Vector2(minSize, bg.sizeDelta.y);
        }
        else
        {
            bg.sizeDelta = new Vector2(minSize + (digits - minDigits) * deltaSize, bg.sizeDelta.y);
        }
    }
    public void SetCounterTo(float to, int digitsAfterDot)
    {
        counter.text = to.ToString($"N{digitsAfterDot}");
        int digits = 1;
        for (; to >= 10; digits++)
            to /= 10;
        digits += digitsAfterDot + 1;
        if (digits <= minDigits)
        {
            bg.sizeDelta = new Vector2(minSize, bg.sizeDelta.y);
        }
        else
        {
            bg.sizeDelta = new Vector2(minSize + (digits - minDigits) * deltaSize, bg.sizeDelta.y);
        }
    }
    public void SetText()
    {
        SetCounterTo(int.Parse(counter.text));
    }
}
