using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSetupController : MonoBehaviour
{
    int obstacleCount;
    [SerializeField]SpriteRenderer range;

    private void Start()
    {
        obstacleCount = 0;
        var tmp =  GetComponent<TowerData>();
        transform.GetChild(1).GetComponent<Animator>().Play("Enable");
        transform.GetChild(1).localScale = new Vector3(tmp.Range, tmp.Range, 1);
    }
    private void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10;
        if (obstacleCount > 0)
            range.color = ColorConverter.forbid;
        else
            range.color = ColorConverter.allow;
        if(obstacleCount == 0 && Input.GetMouseButtonUp(0))
        {
            Set(false);
        }
        if(Input.GetMouseButtonUp(1))
        {
            PlayerMoney.instance.AddMoney(PlayerMoney.instance.TowerPrice);
            Destroy(gameObject);
        }
    }
    public void Set(bool init)
    {
        range.color = Color.white;
        if(!init)transform.GetChild(1).GetComponent<Animator>().Play("Disable");
        GetComponent<TowerAim>().enabled = true;
        GetComponent<TowerUpgrade>().enabled = true;
        enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Obstacle")|| col.CompareTag("Tower")) 
            obstacleCount++;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Obstacle") || col.CompareTag("Tower"))
            obstacleCount--;
    }
}
