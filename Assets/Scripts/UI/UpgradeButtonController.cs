using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtonController : MonoBehaviour
{
    [SerializeField] Slider progress;
    [SerializeField] int index;
    public void SetUp()
    {
        TowerUpgrade tmp = UpgradePanelController.instance.current;
        progress.value = tmp.Stages[index] / (float)tmp.maxStages[index];
    }
    public void ButtonPressed()
    {
        UpgradePanelController.instance.current.Upgrade(index);
        UpgradePanelController.instance.SetUpButtons();
    }
}
