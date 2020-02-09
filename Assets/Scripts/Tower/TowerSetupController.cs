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
        var tmp =  GetComponent<TowerDataHolder>();
        transform.GetChild(1).localScale = new Vector3(tmp.data.Range, tmp.data.Range, 1);
    }
    private void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10;
        if (obstacleCount > 0)
            sr.color = Color.red;
        else
            sr.color = Color.green;
        if(obstacleCount == 0 && Input.GetMouseButtonDown(0))
        {
            sr.color = Color.white;
            transform.GetChild(1).localScale = Vector3.zero;
            GetComponent<TowerAim>().enabled = true;
            this.enabled = false;
        }
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
