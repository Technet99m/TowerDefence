using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimModeController : MonoBehaviour
{
    [SerializeField] Sprite[] logos;
    [SerializeField] string[] descriptoins;
    [SerializeField] Text label;
    [SerializeField] Image logo;
    [SerializeField] GameObject aimMode, smartBtn;

    Targeting type;
    public void SetUp()
    {
        if (UpgradePanelController.instance.current.data.smart)
        {
            smartBtn.SetActive(false);
            aimMode.SetActive(true);
            type = UpgradePanelController.instance.current.data.aim.aimType;
            logo.sprite = logos[(int)type];
            label.text = descriptoins[(int)type];
        }
        else
        {
            smartBtn.SetActive(true);
            aimMode.SetActive(false);
        }
    }
    public void NextType()
    {
        type = (Targeting)(((int)type + 1) % logos.Length);
        UpgradePanelController.instance.current.data.aim.aimType = type;
        SetUp();
    }
    public void MakeSmart()
    {
        UpgradePanelController.instance.current.MakeSmart();
        SetUp();
    }
}
