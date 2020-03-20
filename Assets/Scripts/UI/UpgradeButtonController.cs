using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtonController : MonoBehaviour
{
    [SerializeField] Slider progress;
    [SerializeField] int index;
    [SerializeField] Text price;
    public void SetUp()
    {
        TowerUpgrade tmp = UpgradePanelController.instance.current;
        price.text = tmp.prices[index].ToString("N1");
        progress.value = tmp.Stages[index] / (float)tmp.maxStages[index];
        UpgradePanelController.instance.SetUpTowerPrice();
    }
    public void ButtonPressed()
    {
        UpgradePanelController.instance.current.Upgrade(index);
        UpgradePanelController.instance.SetUpButtons();
    }
}
