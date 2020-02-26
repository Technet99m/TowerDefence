using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningAnim : MonoBehaviour
{
    LineRenderer line;
    
    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        line.material.SetTextureOffset("_MainTex", Vector2.right * Time.time);
        float distance = 0;
        for(int i = 1; i<line.positionCount;i++)
        {
            distance += Vector2.Distance(line.GetPosition(i), line.GetPosition(i - 1));
        }
        line.material.mainTextureScale = new Vector2(distance/2, 1);
    }
}
