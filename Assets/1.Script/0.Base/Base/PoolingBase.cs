using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingBase : MonoBehaviour
{
    [Header("Pooling ฐüทร")]
    [SerializeField] protected float poolingTime = 5;
    [SerializeField] protected int poolIndex;
    [SerializeField] protected PoolManager poolManager;
    protected virtual void Start()
    {
        SetPool();
    }
    protected virtual void SetPool()
    {
        StartCoroutine(Pool());
        poolManager = GameManager.Instance.PoolManager;
    }
    protected IEnumerator Pool()
    {
        yield return new WaitForSeconds(poolingTime);
        gameObject.SetActive(false);
        transform.SetParent(poolManager.Instance(poolIndex));
    }
}
