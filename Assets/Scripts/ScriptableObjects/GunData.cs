using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GunData", order = 1)]
public class GunData : ScriptableObject
{
    public string gunName;
    public int gunID;
    public int bulletID;
    public float shootDelay = 1.2f;
    public float bulletSpeed = 500;
    public float explosionRadius = 5f;
    public float effectForce = 300f;
    public float effectTime = 3f;
    public bool isParabolic = true;
    public string soundName;
}
