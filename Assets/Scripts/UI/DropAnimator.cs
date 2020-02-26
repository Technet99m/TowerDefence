using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropAnimator : MonoBehaviour
{
    bool isShowing;
    public void Press()
    {
        if (isShowing) Hide();
        else Show();
    }
    public void Show()
    {
        GetComponent<Animator>().Play("Enable");
        isShowing = true;
    }

    public void Hide()
    {
        GetComponent<Animator>().Play("Disable");
        isShowing = false;
    }
}
