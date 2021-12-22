using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingBase : MonoBehaviour
{
    [Header("Pooling ฐüทร")]
    [SerializeField] protected int poolIndex;
    [SerializeField] protected PoolManager poolManager;
    Coroutine col; 
    protected void Start()
    {
        poolManager = GameManager.Instance.PoolManager;
        print(GameManager.Instance.gameObject.name);
    }
    protected IEnumerator Pool()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
        transform.SetParent(poolManager.Instance(poolIndex));
        StopCoroutine(col);
    }
}
