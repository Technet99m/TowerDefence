using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoney : MonoBehaviour
{
    public static PlayerMoney instance;
    [SerializeField] float Money;
    public float TowerPrice, ColorPrice, ColorUpdatePrice;

    [SerializeField] Text text;

    private void Awake()
    {
        instance = this;
        RefreshText();
    }
    void RefreshText()
    {
        text.text = Money.ToString("N2");
    }
    public void AddMoney(float change)
    {
        if (change < 0)
            return;
        Money += change;
        RefreshText();
    }
    public bool TryBuyForPrice(float price)
    {
        if (price < 0)
            return false;
        
        if (Money >= price)
        {
            Money -= price;
            RefreshText();
            return true;
        }
        // Activate Not enough money panel
        return false;
    }
}
