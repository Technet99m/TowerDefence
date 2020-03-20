using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Button startWave;
    [SerializeField] Text waveNumber;
    [SerializeField] GameObject dropdown, gameSpeed;
    public static UIManager instance;
    private void Awake()
    {
        instance = this;
    }

    public void WaveEnded(int nextWave)
    {
        startWave.interactable = true;
        waveNumber.text = "Wave "+ nextWave.ToString();
        waveNumber.color = Color.black;
        dropdown.SetActive(true);
        gameSpeed.SetActive(false);
    }
    public void WaveStarted()
    {
        startWave.interactable = false;
        waveNumber.color = Color.white;
        dropdown.SetActive(false);
        gameSpeed.SetActive(true);
    }
}
