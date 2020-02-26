using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoney : MonoBehaviour
{
    public static PlayerMoney instance;
    public float Money;

    [SerializeField] Text text;

    private void Awake()
    {
        instance = this;
        Money = 0;
        ChangeMoney(0);
    }
    public void ChangeMoney(float change)
    {
        Money += change;
        text.text = Money.ToString("N2");
    }
}
