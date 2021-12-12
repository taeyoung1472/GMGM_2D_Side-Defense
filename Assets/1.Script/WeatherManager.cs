using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    [SerializeField] private GameObject rain, dust;
    [SerializeField] private AudioSource rainAudio, dustaudo;
    int newSoundValue, preSoundValue;
    private void Update()
    {
        rainAudio.volume = Mathf.Lerp(rainAudio.volume, newSoundValue, Time.deltaTime);
    }
    public void StartRain()
    {
        newSoundValue = 1;
        rain.SetActive(true);
    }
    public void StopRain()
    {
        newSoundValue = 0;
        rain.SetActive(false);
    }
    public void StartDust()
    {
        dust.SetActive(true);
    }
    public void StopDust()
    {
        dust.SetActive(false);
    }
}