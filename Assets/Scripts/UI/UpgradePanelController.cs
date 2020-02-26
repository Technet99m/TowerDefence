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

    public TowerUpgrade current;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void SetUp(TowerUpgrade tower)
    {
        current = tower;
        preview.sprite = tower.GetComponent<SpriteRenderer>().sprite;
        preview.color = ColorConverter.ToColor(tower.data.Effect.type);
        
        // TODO description
        
        //Disable selected color
        for(int i = 0;i<colors.Length;i++)
        {
            colors[i].interactable = !(i==(int)tower.data.Effect.type-1);
        }
        ButtonsSetUp();
        GetComponent<Animator>().Play("Enable");
    } 
    public void ButtonsSetUp()
    {
        foreach (var button in buttons)
        {
            button.SetUp();
        }
    }
}
