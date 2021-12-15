using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    public static Transform Player
    {
        get
        {
            if (instance != null)
            {
                return instance.player;
            }
            else
            {
                return null;
            }

        }
    }
    public Transform player;

    private float timeScale = 1f;
    public static float TimeScale
    {
        get
        {
            if (instance != null)
            {
                return instance.timeScale;
            }
            else
            {
                return 0f;
            }

        }
        set
        {
            instance.timeScale = Mathf.Clamp(value, 0, 1);
        }
    }
    private void Awake()
    {
        instance = this;
    }
}
