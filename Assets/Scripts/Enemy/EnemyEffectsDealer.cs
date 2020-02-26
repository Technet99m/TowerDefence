using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEffectsDealer : MonoBehaviour
{
    [SerializeField] EnemyDataHolder dataHolder;
    [SerializeField] EnemyHealth HP;
    [SerializeField] float lightningRadius,lightningDamage, poisonDamage;
    [SerializeField] LayerMask lightningMask;
    [SerializeField] GameObject lightningLine;
    public bool isLightend;

    float startSpeed;
    Coroutine lightning, poison,freeze;
    public void Start()
    {
        startSpeed = dataHolder.data.speed;
    }
    public void DealEffect(Effect effect)
    {
        switch (effect.type)
        {
            case EffectType.Lightning:
                lightning = StartCoroutine(Lightning(effect.stage));
                break;
            case EffectType.Freeze:
                if(freeze!=null)
                    StopCoroutine(freeze);
                freeze = StartCoroutine(Freeze(effect.stage));
                break;
            case EffectType.Poison:
                if (poison != null)
                    StopCoroutine(poison);
                poison = StartCoroutine(Poison(effect.stage));
                break;

        }
    }
    public void LightningStrike()
    {
        GetComponent<SpriteRenderer>().color = ColorConverter.ToColor(EffectType.Lightning);
        HP.GetDamage(lightningDamage);
        isLightend = true;
        Invoke(nameof(Unstrike), 0.3f);
    }
    void Unstrike()
    {
        GetComponent<SpriteRenderer>().color = Color.black;
        isLightend = false;
    }
    public EnemyEffectsDealer FindNearestNotStriked()
    {
        Collider2D nearest = null;
        float nearestDistance = lightningRadius;
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, lightningRadius, lightningMask.value);
        foreach(var col in enemies)
        {
            if (Vector2.Distance(transform.position, col.transform.position) < nearestDistance && col.GetComponent<EnemyDataHolder>().data.shape == dataHolder.data.shape 
                && !col.GetComponent<EnemyEffectsDealer>().isLightend)
            {
                nearest = col;
                nearestDistance = Vector2.Distance(transform.position, col.transform.position);
            }
        }
        if (nearest)
            return nearest.GetComponent<EnemyEffectsDealer>();
        else
            return null;
    }
    IEnumerator Lightning(int stage)
    {
        var line = Instantiate(lightningLine).GetComponent<LineRenderer>();
        Destroy(line.gameObject, 1/8f* (2 + stage));
        EnemyEffectsDealer target = this;
        for(int i = 0;i<2+stage;i++)
        {
            target = target.FindNearestNotStriked();
            if(target)
            {
                target.LightningStrike();
                line.positionCount++;
                line.SetPosition(i, target.transform.position);
                line.SetPosition(0, transform.position);
            }
            else
            {
                break;
            }
            yield return new WaitForSeconds(1 / 8f);
        }
        yield return new WaitForSeconds(1 / 8f);
        if(line)
            Destroy(line.gameObject);
    }
    IEnumerator Poison(int stage)
    {
        float endTime = Time.time + stage * 1f;
        var wait = new WaitForSeconds(1 / 5f);
        GetComponent<SpriteRenderer>().color = ColorConverter.ToColor(EffectType.Poison);
        while (Time.time< endTime)
        {
            HP.GetDamage(0.1f);
            yield return wait;
        }
        GetComponent<SpriteRenderer>().color = Color.black;
    }
    IEnumerator Freeze(int stage)
    {
        GetComponent<SpriteRenderer>().color = ColorConverter.ToColor(EffectType.Freeze);
        dataHolder.data.speed = startSpeed / 3f;
        yield return new WaitForSeconds(stage * 1f);
        dataHolder.data.speed = startSpeed;
        GetComponent<SpriteRenderer>().color = Color.black;
    }
}
