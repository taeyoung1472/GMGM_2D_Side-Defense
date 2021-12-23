using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    
    public Light intenSityValue;
    private int day, hour, min;
    private float value;
    bool isDay, isRain;
    [SerializeField] private int timeScale, dayTime, nightTime, rainPercent;
    [SerializeField] private Text timeText;
    private void Start()
    {
        intenSityValue.intensity = 1f;
        timeText.text = string.Format("Day : {0} Hour : {1} Min : {2}", day, hour, min);
        StartCoroutine(Time());
    }
  void Update()
    {
       
    }
    IEnumerator Time()
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
                        isRain = false;
                    }
                    else
                    {
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
        if(value<720 && 0 <= value)
        {
            intenSityValue.intensity -= 0.0208333333333333f;
        }
        else if(value>=720)
        {
            intenSityValue.intensity += 0.0208333333333333f;
        }
        
    }
}
