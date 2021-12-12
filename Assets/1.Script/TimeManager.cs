using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeManager : MonoBehaviour
{
    private int day, hour, min;
    bool isDay, isRain;
    [SerializeField] private int timeScale, dayTime, nightTime, rainPercent;
    [SerializeField] private Text timeText;
    [SerializeField] private WeatherManager weatherManager;
    private void Start()
    {
        timeText.text = string.Format("Day : {0} Hour : {1} Min : {2}", day, hour, min);
        StartCoroutine(Time());
    }
    IEnumerator Time()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            min += timeScale;
            if (min >= 60)
            {
                min -= 60;
                hour++;
                if (Random.Range(0,100) < rainPercent)
                {
                    if (isRain)
                    {
                        isRain = false;
                        weatherManager.StopRain();
                    }
                    else
                    {
                        isRain = true;
                        weatherManager.StartRain();
                    }
                }
                if(hour < nightTime && hour >= dayTime)
                {
                    isDay = true;
                }
                else
                {
                    isDay = false;
                }
                if (hour >= 24)
                {
                    hour = 0;
                    day++;
                }
            }
            timeText.text = string.Format("Day : {0} Hour : {1} Min : {2}", day, hour, min);
        }
    }
}
