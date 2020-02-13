using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    Shapes shape;
    Colors color;
    float speed, damage;
    public Vector2 target;
    public void Initialize(float Damage, float Speed,Shapes sh,Colors col)
    {
        speed = Speed;
        damage = Damage;
        shape = sh;
        color = col;
        var tmp = GetComponent<SpriteRenderer>();
        tmp.color = ColorConverter.ToColor(color);
        tmp.sprite = sprites[(int)shape];
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
                coll.GetComponent<EnemyHealth>().GetDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
