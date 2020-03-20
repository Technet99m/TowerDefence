using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropAnimator : MonoBehaviour
{
    bool isShowing;
    [SerializeField] Sprite pressed, normal;
    public void Press()
    {
        if (isShowing) Hide();
        else Show();
    }
    public void Show()
    {
        if (!isShowing)
        {
            GetComponent<Animator>().Play("Enable");
            isShowing = true;
            GetComponent<Image>().sprite = pressed;
        }
    }

    public void Hide()
    {
        if (isShowing)
        {
            GetComponent<Animator>().Play("Disable");
            isShowing = false;
            GetComponent<Image>().sprite = normal;
        }
    }
}
