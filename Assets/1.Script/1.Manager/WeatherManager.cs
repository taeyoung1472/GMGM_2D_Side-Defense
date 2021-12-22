using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.RainMaker;
public class WeatherManager : MonoBehaviour
{
    [SerializeField] private RainScript2D rainScript2D;
    private float rainAudio = 0;
    public void Update()
    {
        rainScript2D.RainIntensity = Mathf.Lerp(rainScript2D.RainIntensity, rainAudio, Time.deltaTime);
    }
    public void StartRain()
    {
        rainAudio = 0.5f;
        rainScript2D.EnableWind = true;
    }
    public void StopRain()
    {
        rainAudio = 0;
        rainScript2D.EnableWind = false;
    }
    public void StartDust()
    {

    }
    public void StopDust()
    {

    }
}
