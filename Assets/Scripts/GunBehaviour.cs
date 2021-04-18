using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{
    [Header("Gun Stats")]
    public string gunName;
    public int gunCode;
    public float shootDelay = 1.2f;
    public string soundName;
    [Header("Gun Assets")]
    public Transform bulletPivot;
    public GameObject bullet;
    
}
