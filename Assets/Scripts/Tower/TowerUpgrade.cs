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

    private void OnMouseUpAsButton()
    {
        UpgradePanelController.instance.SetUp(this);
    }
    private void Start()
    {
        Stages = new int[] { 0, 0, 0, 0 };
    }
    public void Upgrade(int index)
    {
        Stages[index]++;
        switch(index)
        {
            case 0:
                data.Reload *= Updates[index];
                break;
            case 1:
                data.Damage *= Updates[index];
                break;
            case 2:
                data.Range *= Updates[index];
                break;
            case 3:
                data.BulletSpeed *= Updates[index];
                break;
        }
        PlayerMoney.instance.ChangeMoney(-prices[index]);
        prices[index] *= costIncrease;
    }
}
