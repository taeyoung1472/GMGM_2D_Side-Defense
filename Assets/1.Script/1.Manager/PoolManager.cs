using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public Transform Holder { get { return holder; } }
    [SerializeField] private Transform holder;
    [SerializeField] private Transform[] instance;
    public Transform Instance(int type) { return instance[type]; }
    public GameObject Get(int type)
    {
        if (instance[type].childCount > 0)
        {
            return instance[type].GetChild(0).gameObject;
        }
        else
            return null;
    }
}
