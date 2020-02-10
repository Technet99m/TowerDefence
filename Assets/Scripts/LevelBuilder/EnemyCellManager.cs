using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCellManager : MonoBehaviour
{
    [SerializeField] Dropdown shape, color;
    [SerializeField] Image graphics;

    public void ChangeColorTo()
    {
        graphics.color = ColorConverter.ToColor((Colors)color.value);
    }

    public void Delete()
    {
        Destroy(gameObject);
    }

    public void SetSiblingIndex(int i)
    {
        if ((transform.GetSiblingIndex() == 0 && i == -1) || transform.GetSiblingIndex() == LevelBuilder.instance.button.GetSiblingIndex()-1 && i==1)
            return;
        transform.SetSiblingIndex(transform.GetSiblingIndex() + i);
    }
}
