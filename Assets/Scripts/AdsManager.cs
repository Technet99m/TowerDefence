using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsManager : MonoBehaviour
{
    public static AdsManager instance;
    public float Reward 
    {
        get 
        {
            return 10; 
        }
    }
    public bool isReady;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }
}
