using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] Vector2 topBorder, BottomBorder;
    [SerializeField] float zoomSensivity, swipeSensivity;

    Vector2 offset;
    float distance;
    [SerializeField]float minSize, maxSize;
    Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
        UpdateOffset();
    }
    void Update()
    {
        if (Input.touchCount == 1 && Input.touches[0].phase == TouchPhase.Moved)
        {
            transform.Translate(ScreenToWorld(Input.touches[0].deltaPosition) * -1 * swipeSensivity);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, topBorder.x + offset.x, BottomBorder.x - offset.x),
                Mathf.Clamp(transform.position.y, BottomBorder.y + offset.y, topBorder.y - offset.y), transform.position.z);
        }
        if (Input.touchCount == 2)
        {
            if (Input.touches[0].phase == TouchPhase.Began || Input.touches[1].phase == TouchPhase.Began)
                distance = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
            else
            {
                float newDistance = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
                cam.orthographicSize -= (newDistance - distance) * zoomSensivity;
                cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minSize, maxSize);
                distance = newDistance;
                Debug.Log($"{distance} count:{Input.touchCount}");
                UpdateOffset();
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, topBorder.x + offset.x, BottomBorder.x - offset.x),
                Mathf.Clamp(transform.position.y, BottomBorder.y + offset.y, topBorder.y - offset.y), transform.position.z);
            }
        }
    }
    public void UpdateOffset()
    {
        offset = cam.ViewportToWorldPoint(new Vector3(1, 1)) - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f));
    }
    public Vector2 ScreenToWorld(Vector2 v)
    {
        return v / new Vector2(Screen.currentResolution.width, Screen.currentResolution.height) * offset;
    }
}
