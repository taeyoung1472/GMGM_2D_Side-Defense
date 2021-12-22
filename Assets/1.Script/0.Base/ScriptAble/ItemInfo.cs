using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObject/Item", fileName = "ItemInfo")]
public class ItemInfo : ScriptableObject
{
    public string name, stackLimit;
    public Sprite itemSprite;
    public ItemType itemType;
    public int stackAbleCnt;
    public enum ItemType
    {
        useAble,
        DeployAble,
        weapone
    }
}
