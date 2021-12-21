using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
   private Light intenSityValue;
    private int day, hour, min;
    private float value,lightValue;
    bool isDay, isRain;
    [SerializeField] private int timeScale, dayTime, nightTime, rainPercent;
    [SerializeField] private Text timeText;
     void Start()
    {
        intenSityValue.intensity= 0.4f;
        lightValue = 0.4f;
        timeText.text = string.Format("Day : {0} Hour : {1} Min : {2}", day, hour, min);
        StartCoroutine(TimeSystem());
    }
    void Update()
    {
        
        intenSityValue.intensity = Mathf.Lerp(intenSityValue.intensity, lightValue, 0.01f);
        //intenSityValue.intensity = Mathf.Lerp(intenSityValue.intensity, lightValue, Time.deltaTime / timeScale);
    }
    IEnumerator TimeSystem()    
    {
        while (true)
        {
            TurnDelight();
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
    //void TurnDelight()
    //{
    //    if (hour >= 12 && hour <= 24)//아침7시~오후19시 밝아짐
    //    {
    //        lightValue += 1f / ((60f / timeScale) * 12);
    //        //intenSityValue.intensity += 1f / ((60f / timeScale) * 12);
    //    }
    //    else if (hour >= 0 && hour < 12)//오후19시~아침 7시 어두워짐
    //    {
    //        lightValue -= 1f / ((60f / timeScale) * 12);
    //        //intenSityValue.intensity -= 1f / ((60f / timeScale) * 12);
    //    }
    //}
    void TurnDelight()
    {
        if(hour>=5&&hour<17)//오전5시~오후4시 밝아짐
        {
            lightValue += 1f / ((60f / timeScale) * 12);

        }
       else if(hour<5||hour>=17)//오후5시~오전4시 어두워짐
        {
            lightValue -= 1f / ((60f / timeScale) * 12);
        }   
    }
}
