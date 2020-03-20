using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour
{
    TextMesh fps;
    void Start()
    {
        fps = gameObject.AddComponent<TextMesh>();
        transform.position = Vector3.zero;
        fps.transform.SetParent(Camera.main.transform);
        fps.color = Color.red;
        fps.fontSize = 20;
    }

    void Update()
    {
        if (Time.frameCount % 10 == 0)
            fps.text = "FPS: " + (1f / Time.deltaTime).ToString("N2");
    }
}
