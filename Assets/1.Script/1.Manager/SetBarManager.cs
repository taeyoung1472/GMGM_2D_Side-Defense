using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBarManager : MonoSingleton<SetBarManager>
{
    public FatiqueBar fatiqueBar;


    public void SetFatiquerBar(float value)
    {
        Instance.fatiqueBar.SetHP(value);
    }
}
