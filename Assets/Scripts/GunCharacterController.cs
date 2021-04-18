﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCharacterController : MonoBehaviour
{
    [Header("Gun Stats")]
    public Transform gunPivot;
    public Animator gunAnimator;
    public GunBehaviour currentGun = null;
    int pickID = 0;
    bool canShoot = true;

    void OnTriggerEnter(Collider collider){
        if(collider.CompareTag("ItemPicker")){
            ItemPickerBehaviour item = collider.GetComponent<ItemPickerBehaviour>();
            pickID = item.itemID;
            GameMenuManager.instance.SetItemText(item.itemName);
        }   
    }

    void OnTriggerExit(Collider collider){
        if(collider.CompareTag("ItemPicker")){
            pickID = 0;
            GameMenuManager.instance.HideItemText();
        }
    }

    void Update(){
        if(pickID != 0 && Input.GetMouseButtonDown(1)){
            SetGun();
        }

        if(canShoot && currentGun != null && Input.GetMouseButtonDown(0)){
            StartCoroutine("ShootGun");
        }

    }

    IEnumerator ShootGun(){
        canShoot = false;
        gunAnimator.Play("ShootGun");
        yield return new WaitForSeconds(currentGun.shootDelay);
        canShoot = true;
    }

    void SetGun(){

        if(currentGun == null){
            GameMenuManager.instance.SetAim(true);
        }else{
            PoolManager.instance.RecycleGun(currentGun.gameObject);
        }
        currentGun = PoolManager.instance.GetGun(pickID).GetComponent<GunBehaviour>();
        currentGun.transform.SetParent(gunPivot);
        currentGun.transform.localPosition = Vector3.zero;
        currentGun.transform.localRotation = Quaternion.identity;
        currentGun.transform.localScale = new Vector3(1,1,1);
        gunAnimator.Play("GetGun");
    }
}
