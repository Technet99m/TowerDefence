using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveDataHolder : MonoBehaviour
{
    public WaveData data;

    public void Select()
    {
        LevelBuilder.instance.selected = this;
        LevelBuilder.instance.SetupCells();
    }
    public void SetSiblingIndex(int i)
    {
        if ((transform.GetSiblingIndex() == 0 && i == -1) || transform.GetSiblingIndex() == LevelBuilder.instance.waveAdd.GetSiblingIndex() - 1 && i == 1)
            return;
        transform.SetSiblingIndex(transform.GetSiblingIndex() + i);
        var label = transform.GetChild(0).GetComponentInChildren<Text>();
        label.text = "Wave " + transform.GetSiblingIndex().ToString();
        label = transform.parent.GetChild(transform.GetSiblingIndex()-i).GetChild(0).GetComponentInChildren<Text>();
        label.text = "Wave " + label.transform.parent.parent.GetSiblingIndex().ToString();
    }
    public void Delete()
    {
        Destroy(gameObject);
    }
}
