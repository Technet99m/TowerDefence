using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    public Vector2[] bottomBorders;
    [SerializeField] Vector2 topBorder, BottomBorder;
    [SerializeField] float sensivity;

    Vector2 offset;
    float distance;
    float minSize, maxSize;
    private void Start()
    {
        minSize = 5;
        UpdateOffset();
        UpdateCameraBorders(0);
    }
    public void UpdateOffset()
    {
        offset = Camera.main.ViewportToWorldPoint(new Vector3(1, 1)) - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f));
    }
    public void UpdateCameraBorders(int stage)
    {
        BottomBorder = bottomBorders[stage];
        maxSize = 5 + 2 * stage;
    }
    public void Update()
    {
        if (Input.touchCount == 1 && Input.touches[0].phase == TouchPhase.Moved)
        {
            transform.Translate(ScreenToWorld(Input.touches[0].deltaPosition) * -1);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, topBorder.x + offset.x, BottomBorder.x - offset.x),
                Mathf.Clamp(transform.position.y, BottomBorder.y + offset.y, topBorder.y - offset.y),transform.position.z);
        }
        if(Input.touchCount == 2)
        {
            if (Input.touches[0].phase == TouchPhase.Began || Input.touches[1].phase == TouchPhase.Began)
                distance = Vector2.Distance(ScreenToWorld(Input.touches[0].position), ScreenToWorld(Input.touches[1].position));
            else
            {
                float newDistance = Vector2.Distance(ScreenToWorld(Input.touches[0].position), ScreenToWorld(Input.touches[1].position));
                Camera.main.orthographicSize -= (newDistance - distance) * sensivity;
                Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minSize, maxSize);
                distance = newDistance;
                UpdateOffset();
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, topBorder.x + offset.x, BottomBorder.x - offset.x),
                Mathf.Clamp(transform.position.y, BottomBorder.y + offset.y, topBorder.y - offset.y), transform.position.z);
            }
        }
    }
    public Vector2 ScreenToWorld(Vector2 v)
    {
        return v / new Vector2(Screen.currentResolution.width, Screen.currentResolution.height) * offset;
    }
}
