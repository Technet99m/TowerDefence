using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSetupController : MonoBehaviour
{
    int obstacleCount;
    SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        obstacleCount = 0;
        var tmp =  GetComponent<TowerData>();
        transform.GetChild(1).localScale = new Vector3(tmp.Range, tmp.Range, 1);
    }
    private void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10;
        if (obstacleCount > 0)
            sr.color = Color.red;
        else
            sr.color = Color.green;
        if(obstacleCount == 0 && Input.GetMouseButtonUp(0))
        {
            Set();
        }
        if(Input.GetMouseButtonUp(1))
        {
            PlayerMoney.instance.AddMoney(PlayerMoney.instance.TowerPrice);
            Destroy(gameObject);
        }
    }
    void Set()
    {
        transform.GetChild(1).localScale = Vector3.zero;
        GetComponent<TowerAim>().enabled = true;
        GetComponent<TowerUpgrade>().enabled = true;
        GetComponent<SpriteRenderer>().color = Color.white;
        Camera.main.GetComponent<CameraController>().enabled = true;
        enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Obstacle")) 
            obstacleCount++;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Obstacle"))
            obstacleCount--;
    }
}
