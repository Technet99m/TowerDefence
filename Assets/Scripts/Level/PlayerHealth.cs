using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
    [SerializeField]int health;
    public int Health 
    {
        get { return health; }
        set 
        {
            health = value;
            counter.SetCounterTo(value);
        }
    }

    [SerializeField] CounterFitter counter;

    private void Awake()
    {
        instance = this;
        health = 101;
        MinusHealth();
    }
    public void MinusHealth()
    {
        health--;
        counter.SetCounterTo(health);
    }
}
