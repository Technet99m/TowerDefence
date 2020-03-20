using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanelController : MonoBehaviour
{
    public static UpgradePanelController instance;

    [SerializeField] UpgradeButtonController[] buttons;
    [SerializeField] Image preview;
    [SerializeField] Button[] colors;
    [SerializeField] UpgradeColorController ucc;
    [SerializeField] AimModeController amc;
    [SerializeField] GameObject askingPanel;
    [SerializeField] Text towerPrice;
    public TowerUpgrade current;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        gameObject.SetActive(false);
    }
    public void Disable()
    {
        gameObject.SetActive(false);
    }
    public void SetUp(TowerUpgrade tower)
    {
        gameObject.SetActive(true);
        if (current != null)
            HideRange();
        current = tower;
        preview.sprite = tower.GetComponent<SpriteRenderer>().sprite;
        preview.color = ColorConverter.ToColor(tower.data.Effect.type);
        ucc.SetUp();
        amc.SetUp();
        // TODO description

        SetUpButtons();
        
        current.transform.GetChild(1).GetComponent<Animator>().Play("Enable");
        GetComponent<Animator>().Play("Enable");
    } 
    public void SetUpRange()
    {
        current.transform.GetChild(1).localScale = Vector3.one * current.data.Range;
    }
    public void SetUpTowerPrice()
    {
        towerPrice.text = current.TowerCost.ToString("N1");
    }
    public void SetUpButtons()
    {
        foreach (var button in buttons)
        {
            button.SetUp();
        }
    }
    public void SetUpColorsButtons()
    {
        for (int i = 0; i < colors.Length; i++)
            colors[i].interactable = (int)current.data.Effect.type != (i + 1);


    }
    public void HideRange()
    {
        current.transform.GetChild(1).GetComponent<Animator>().Play("Disable");
    }
    int selectedColor;
    public void SetColorTo(int i)
    {
        if (PlayerMoney.instance.isEnough(PlayerMoney.instance.ColorPrice))
        {
            selectedColor = i;
            askingPanel.SetActive(true);
        }
        else
            NotEnoughMoneyController.instance.Show();
    }
    public void SetColor()
    {
        current.SetColorTo(selectedColor);
        preview.color = ColorConverter.ToColor(current.data.Effect.type);
        ucc.SetUp();
        UpgradePanelController.instance.SetUpTowerPrice();
    }
    public void Sell()
    {
        current.SellTower();
    }
}
