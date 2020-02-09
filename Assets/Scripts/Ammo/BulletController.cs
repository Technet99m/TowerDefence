using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    public Shapes shape;
    public Colors color;
    float speed, damage;
    public Vector2 target;
    public void Initialize(float Damage, float Speed)
    {
        speed = Speed;
        damage = Damage;
        var tmp = GetComponent<SpriteRenderer>();
        tmp.color = ColorConverter.ToColor(color);
        tmp.sprite = sprites[(int)shape];
        transform.up = transform.parent.right;
        transform.parent = null;
    }

    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime); ;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("Enemy"))
        {
            EnemyData tmp = coll.GetComponent<EnemyDataHolder>().data;
            if (tmp.Color == color && tmp.Shape == shape)
            {
                coll.GetComponent<EnemyHealth>().GetDamage(damage);
            }
        }
    }
}
