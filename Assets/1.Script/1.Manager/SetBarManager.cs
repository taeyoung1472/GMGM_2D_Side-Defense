using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBarManager : MonoSingleton<SetBarManager>
{
    public SliderSystem fatiqueBar;


    public void SetFatiquerBar(float value)
    {
        Instance.fatiqueBar.SetValue(value);
    }
}
