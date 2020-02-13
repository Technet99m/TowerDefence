using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyTower : MonoBehaviour
{
    [SerializeField] GameObject tower;
    [SerializeField] Sprite[] sprites;
    [SerializeField]
    UnityEngine.UI.Dropdown towers;

    public void Buy(int s)
    {
        var Tower = Instantiate(tower);
        Tower.GetComponent<TowerData>().Shape = (Shapes)s;
        Tower.GetComponent<SpriteRenderer>().sprite = sprites[s];
        GetComponent<Animator>().Play("Disable");
    }
}
