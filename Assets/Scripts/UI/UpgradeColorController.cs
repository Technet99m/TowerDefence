using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeColorController : MonoBehaviour
{
    [SerializeField] Text price;
    [SerializeField] Slider progress;
    public void SetUp()
    {
        GetComponent<Button>().interactable = UpgradePanelController.instance.current.data.Effect.type != EffectType.No;
        price.text = UpgradePanelController.instance.current.ColorUpdatePrice.ToString("N1");
        progress.value = (UpgradePanelController.instance.current.data.Effect.stage-1) / Effect.MAX_STAGE;
        UpgradePanelController.instance.SetUpTowerPrice();
    }

    public void UpgradeColor()
    {
        UpgradePanelController.instance.current.UpgradeColor();
        SetUp();
    }
}
