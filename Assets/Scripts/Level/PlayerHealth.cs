using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
    int Health;

    [SerializeField] Text text;

    private void Awake()
    {
        instance = this;
        Health = 101;
        MinusHealth();
    }
    public void MinusHealth()
    {
        Health--;
        text.text = Health.ToString();
    }
}
