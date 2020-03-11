using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyTower : MonoBehaviour
{
    [SerializeField] GameObject tower;
    [SerializeField] Sprite[] sprites;
    public void Buy(int s)
    {
        if (PlayerMoney.instance.TryBuyForPrice(PlayerMoney.instance.TowerPrice))
        {
            var Tower = Instantiate(tower);
            Tower.GetComponent<TowerData>().Shape = (Shapes)s;
            Tower.GetComponent<SpriteRenderer>().sprite = sprites[s];
            GetComponent<DropAnimator>().Hide();
        }
    }
    
}
