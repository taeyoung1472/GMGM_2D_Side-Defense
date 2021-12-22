using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObject/Parts", fileName = "PartInfo")]
public class PartInfo : MonoBehaviour
{
    public float recoilFix, magazinFix;
    public PartType partType;
    public enum PartType
    {
        Optic,
        Muzzel,
        Tactical,
        Grip,
        Stock,
        Magazin
    }
}
