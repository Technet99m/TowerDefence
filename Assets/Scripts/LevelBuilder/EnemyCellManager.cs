using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCellManager : MonoBehaviour
{
    [SerializeField] Dropdown shape, color;
    [SerializeField] Image graphics;
    [SerializeField] InputField Count, Health, Speed, Money, Damage;
    public EnemyData data;
    public int count;

    public void ChangeColorTo()
    {
        graphics.color = ColorConverter.ToColor((Colors)color.value);
    }
    public void Delete()
    {
        Destroy(gameObject);
    }
    public void GrabData()
    {
        data = new EnemyData();
        data.shape = (Shapes)shape.value;
        data.color = (Colors)color.value;
        data.damage = float.Parse(Damage.text);
        data.money = float.Parse(Money.text);
        data.speed = float.Parse(Speed.text);
        data.health = float.Parse(Health.text);
        count = int.Parse(Count.text);
    }
    public void SetSiblingIndex(int i)
    {
        if ((transform.GetSiblingIndex() == 0 && i == -1) || transform.GetSiblingIndex() == LevelBuilder.instance.button.GetSiblingIndex()-1 && i==1)
            return;
        transform.SetSiblingIndex(transform.GetSiblingIndex() + i);
    }
}
