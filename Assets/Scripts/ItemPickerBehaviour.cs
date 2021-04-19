using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickerBehaviour : MonoBehaviour
{
    [Header("Item Assets")]
    public int itemID;
    public string itemName;
    public float groundOffset = 0.072f;
    GameObject item;
    void Start(){
        item = PoolManager.instance.GetGun(itemID);
        item.transform.SetParent(this.transform);  
        item.transform.localPosition = new Vector3(0,groundOffset,0);
        item.transform.localRotation = Quaternion.Euler(0,0,90);
        itemName = item.GetComponent<GunBehaviour>().data.gunName;
    }
}
