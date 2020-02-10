using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveDataHolder : MonoBehaviour
{
    public WaveData data;

    public void Select()
    {
        LevelBuilder.instance.selected = this;
    }
}
