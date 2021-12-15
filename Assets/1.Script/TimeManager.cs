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
    //[SerializeField] private WeatherManager weatherManager;
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
                        //weatherManager.StopRain();
                    }
                    else
                    {
                        isRain = true;
                        //weatherManager.StartRain();
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
            timeText.text = string.Format("Day : {0} Hour : {1} Min : {2}  Value : {3}", day, hour, min,value);
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
            //if(value=0)
        {

        }
        //switch (hour)
        //{
         
        //    case 1:
        //        intenSityValue.intensity = 0.74f;//Mathf.Lerp(0, 10, Time.deltatime);//0.8f;
        //        break;
        //    case 2:
        //        intenSityValue.intensity = 0.74f;
        //        break;
        //    case 3:
        //        intenSityValue.intensity = 0.68f;
        //        break;
        //    case 4:
        //        intenSityValue.intensity = 0.62f;
        //        break;
        //    case 5:
        //        intenSityValue.intensity = 0.56f;
        //        break;
        //    case 6:
        //        intenSityValue.intensity = 0.50f;
        //        break;
        //    case 7:
        //        intenSityValue.intensity = 0.44f;
        //        break;
        //    case 8:
        //        intenSityValue.intensity = 0.38f;
        //        break;
        //    case 9:
        //        intenSityValue.intensity = 0.32f;
        //        break;
        //    case 10:
        //        intenSityValue.intensity = 0.26f;
        //        break;
        //    case 11:
        //        intenSityValue.intensity = 0.2f;
        //        break;
        //    case 12:
        //        intenSityValue.intensity = 0.14f;
        //        break;
        //    case 13:
        //        intenSityValue.intensity = 0.2f;
        //        break;
        //    case 14:
        //        intenSityValue.intensity = 0.26f;
        //        break;
        //    case 15:
        //        intenSityValue.intensity = 0.32f;
        //        break;
        //    case 16:
        //        intenSityValue.intensity = 0.38f;
        //        break;
        //    case 17:
        //        intenSityValue.intensity = 0.44f;
        //        break;
        //    case 18:
        //        intenSityValue.intensity = 0.50f;
        //        break;
        //    case 19:
        //        intenSityValue.intensity = 0.56f;
        //        break;
        //    case 20:
        //        intenSityValue.intensity = 0.62f;
        //        break;
        //    case 21:
        //        intenSityValue.intensity = 0.68f;
        //        break;
        //    case 22:
        //        intenSityValue.intensity = 0.74f;
        //        break;
        //    case 23:
        //        intenSityValue.intensity = 0.8f;
        //        break;
        //    case 0:
        //        intenSityValue.intensity = 0.8f;
        //        break;

        //}
    }
}
