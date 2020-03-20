using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotEnoughMoneyController : MonoBehaviour
{
    public static NotEnoughMoneyController instance;

    [SerializeField] string description;
    [SerializeField] GameObject adDescription;
    [SerializeField] Text adText;
    [SerializeField] GameObject adButton;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        gameObject.SetActive(false);
    }

    public void Show()
    {
        if(AdsManager.instance!=null && AdsManager.instance.isReady)
        {
            adText.text = $"{description} {AdsManager.instance.Reward}";
            adDescription.SetActive(true);
            adButton.SetActive(true);
        }
        else
        {
            adDescription.SetActive(false);
            adButton.SetActive(false);
        }
        gameObject.SetActive(true);
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
    public void WatchAd()
    {
        gameObject.SetActive(false);
    }
}
