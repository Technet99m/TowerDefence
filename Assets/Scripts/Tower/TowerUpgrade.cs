using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpgrade : MonoBehaviour
{
    [SerializeField] float costIncrease;

    public TowerData data;
    public float[] Updates;
    public int[] Stages;
    public int[] maxStages;
    public float[] prices;
    public float ColorUpdatePrice;
    public float TowerCost;

    bool interactable;
    private void OnEnable()
    {
        interactable = false;
        TowerCost = PlayerMoney.instance.TowerPrice / 2f;
        Invoke(nameof(Activate), Time.deltaTime);
    }
    void Activate()
    {
        interactable = true;
    }
    private void OnMouseUpAsButton()
    {
        if(interactable)
            UpgradePanelController.instance.SetUp(this);
    }
    private void Awake()
    {
        Stages = new int[] { 0, 0, 0, 0 };
    }
    public void Upgrade(int index)
    {
        if (PlayerMoney.instance.TryBuyForPrice(prices[index]))
        {
            Stages[index]++;
            switch (index)
            {
                case 0:
                    data.Reload *= Updates[index];
                    break;
                case 1:
                    data.Damage *= Updates[index];
                    break;
                case 2:
                    data.Range *= Updates[index];
                    UpgradePanelController.instance.SetUpRange();   
                    break;
                case 3:
                    data.BulletSpeed *= Updates[index];
                    break;
            }
            TowerCost += prices[index] / 2f;
            prices[index] *= costIncrease;
            prices[index] = Mathf.Round(prices[index] * 10) / 10;
        }
        else
            NotEnoughMoneyController.instance.Show();
    }
    public void UpgradeColor()
    {
        if (PlayerMoney.instance.TryBuyForPrice(ColorUpdatePrice))
        {
            TowerCost += ColorUpdatePrice / 2f;
            ColorUpdatePrice *= costIncrease;
            data.Effect.stage++;
        }
        else
            NotEnoughMoneyController.instance.Show();
    }
    public void SetColorTo(int i)
    {
        if (PlayerMoney.instance.TryBuyForPrice(PlayerMoney.instance.ColorPrice))
        {
            if (data.Effect.type == EffectType.No)
                TowerCost += PlayerMoney.instance.ColorPrice / 2f;
            data.SetNewEffect((EffectType)(i + 1));
        }
        else
            NotEnoughMoneyController.instance.Show();
    }
    public void MakeSmart()
    {
        if (PlayerMoney.instance.TryBuyForPrice(PlayerMoney.instance.SmartPrice))
        {
            TowerCost += PlayerMoney.instance.SmartPrice / 2;
            data.smart = true;
        }
        else
            NotEnoughMoneyController.instance.Show();
    }

    public void SellTower()
    {
        PlayerMoney.instance.AddMoney(TowerCost);
        Destroy(gameObject);
    }
}
