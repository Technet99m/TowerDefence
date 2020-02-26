using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    Shapes shape;
    Effect effect;
    float speed, damage;
    public Vector2 target;
    public void Initialize(float Damage, float Speed,Shapes sh,Effect ef)
    {
        speed = Speed;
        damage = Damage;
        shape = sh;
        effect = ef;
        var tmp = GetComponent<SpriteRenderer>();
        tmp.sprite = sprites[(int)shape];
        tmp.color = ColorConverter.ToColor(effect.type);
        transform.right = transform.parent.right;
        transform.parent = null;
    }

    private void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime); ;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("Enemy"))
        {
            EnemyData tmp = coll.GetComponent<EnemyDataHolder>().data;
            if ( tmp.shape == shape)
            {
                if (effect.type != EffectType.No)
                    coll.GetComponent<EnemyEffectsDealer>().DealEffect(effect);
                coll.GetComponent<EnemyHealth>().GetDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
