using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FatiqueBar : MonoBehaviour
{
    public RectTransform _fillImage;

    Tween _t = null;

    public void SetHP(float value)
    {
        if (_t != null && _t.IsActive()) // Ʈ���� �������̶�� 
        {
            _t.Kill(); //�ߴ��ϰ�
        }
        value = Mathf.Clamp(value, 0f, 1f); //value����
        _t = _fillImage.DOScaleX(value, 0.1f); // 

    }
}

//FatiqueBar
