using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObject/Gun", fileName = "GunInfo")]
public class GunInfo : ScriptableObject
{
    public string gunName;
    public string desc;
    public float shootDelay, recoil, reloadTime;
    public int magazin;
    public bool[] isCanPart;
    public GameObject bullet;
    public FireMode fireMode;
    public AudioClip shootAudio, reloadAudio, useAudio;
    public enum FireMode
    {
        semi,
        burst,
        auto
    }
}
