using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
    [SerializeField]int Health;

    [SerializeField] CounterFitter counter;

    private void Awake()
    {
        instance = this;
        Health = 101;
        MinusHealth();
    }
    public void MinusHealth()
    {
        Health--;
        counter.SetCounterTo(Health);
    }
}
