using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class partSystem : MonoBehaviour
{
    PartInfo[] currentPart;
    public void SetPart(PartInfo _part)
    {
        switch (_part.partType)
        {
            case PartInfo.PartType.Stock:
                currentPart[0] = _part;
                break;
            case PartInfo.PartType.Optic:
                currentPart[1] = _part;
                break;
            case PartInfo.PartType.Tactical:
                currentPart[2] = _part;
                break;
            case PartInfo.PartType.Muzzel:
                currentPart[3] = _part;
                break;
            case PartInfo.PartType.Grip:
                currentPart[4] = _part;
                break;
        }
    }
    public PartInfo GetPartInfo(int index)
    {
        return currentPart[index];
    }
}