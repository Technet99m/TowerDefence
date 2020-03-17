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
    public bool isLightend,isFreezed,isPoisoned;

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
    #region Lightning
    public void LightningStrike()
    {
        HP.GetDamage(lightningDamage);
        isLightend = true;
        SetUpColor();
        Invoke(nameof(Unstrike), 0.3f);
    }
    void Unstrike()
    {
        isLightend = false;
        SetUpColor();
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
            if(target && line != null)
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
    #endregion
    IEnumerator Poison(int stage)
    {
        isPoisoned = true;
        float endTime = Time.time + stage * 1.25f;
        var wait = new WaitForSeconds(1 / 5f);
        SetUpColor();
        while (Time.time< endTime)
        {
            HP.GetDamage(poisonDamage);
            Debug.Log(HP.health);
            yield return wait;
        }
        isPoisoned = false;
        SetUpColor();
    }
    IEnumerator Freeze(int stage)
    {
        isFreezed = true;
        SetUpColor();
        dataHolder.data.speed = startSpeed / 3f;
        yield return new WaitForSeconds(stage * 1f);
        dataHolder.data.speed = startSpeed;
        isFreezed = false;
        SetUpColor();
    }
    void SetUpColor()
    {
        var sp = GetComponent<SpriteRenderer>();
        if (isLightend)
            sp.color = ColorConverter.ToColor(EffectType.Lightning);
        else if (isPoisoned)
            sp.color = ColorConverter.ToColor(EffectType.Poison);
        else if (isFreezed)
            sp.color = ColorConverter.ToColor(EffectType.Freeze);
        else
            sp.color = ColorConverter.black;
    }
}
