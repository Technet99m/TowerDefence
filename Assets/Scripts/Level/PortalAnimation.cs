using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalAnimation : MonoBehaviour
{
    [SerializeField] Transform[] parts;
    [SerializeField] float[] speeds;

    private void Update()
    {
        for (int i = 0; i < parts.Length; i++)
            parts[i].Rotate(new Vector3(0, 0, speeds[i] * Time.deltaTime));
    }
}
