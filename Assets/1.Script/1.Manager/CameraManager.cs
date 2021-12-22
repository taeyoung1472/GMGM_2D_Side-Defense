using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Vector3 originPos;
    float pow;
    float time;
    public void Start()
    {
        originPos = transform.localPosition;
    }
    public void Update()
    {
        if (pow != 0)
        {
            transform.localPosition = Random.insideUnitSphere * pow + originPos;
        }
    }
    public void Shake(float _pow, float time)
    {
        StartCoroutine(ShakeCol(_pow, time));
    }
    public IEnumerator ShakeCol(float _pow, float time)
    {
        pow = _pow;
        yield return new WaitForSeconds(time);
        pow = 0;
        transform.localPosition = originPos;
    }
}
