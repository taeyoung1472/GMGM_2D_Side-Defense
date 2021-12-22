using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    
    public Light intenSityValue;
    private int day, hour, min;
    private float value; public float lightValue = 1;
    bool isDay, isRain;
    [SerializeField] private int timeScale, dayTime, nightTime, rainPercent;
    [SerializeField] private Text timeText;
    [SerializeField] private WeatherManager weatherManager;
    private void Start()
    {
        intenSityValue.intensity = 1f;
        timeText.text = string.Format("Day : {0} Hour : {1} Min : {2}", day, hour, min);
        StartCoroutine(TimeSystem());
    }
    void Update()
    {
        intenSityValue.intensity = Mathf.Lerp(intenSityValue.intensity, lightValue, Time.deltaTime / timeScale);
    }
    IEnumerator TimeSystem()
    {
        while (true)
        {
            
            TurnDelight();
            yield return new WaitForSeconds(1f);
            value += timeScale;
            min += timeScale;
            if(value>=1440)
            {
                value=0;
            }
               
            if (min >= 60)
            {
                min -= 60;
                hour++;
                if (Random.Range(0,100) < rainPercent)
                {
                    if (isRain)
                    {
                        weatherManager.StartRain();
                        isRain = false;
                    }
                    else
                    {
                        weatherManager.StopRain();
                        isRain = true;
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
    void TurnDelight()
    {
        if (hour >= 12 && hour <= 24)//아침7시~오후19시 밝아짐
        {
            lightValue += 1f / ((60f / timeScale) * 12);
            //intenSityValue.intensity += 1f / ((60f / timeScale) * 12);
        }
        else if (hour >= 0 && hour < 12)//오후19시~아침 7시 어두워짐
        {
            lightValue -= 1f / ((60f / timeScale) * 12);
            //intenSityValue.intensity -= 1f / ((60f / timeScale) * 12);
        }
    }
}
