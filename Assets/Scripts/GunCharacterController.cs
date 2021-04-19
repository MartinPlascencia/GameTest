using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCharacterController : MonoBehaviour
{
    [Header("Gun Stats")]
    public Transform gunPivot;
    public Animator gunAnimator;
    public Transform bulletPivot;
    [System.NonSerialized]
    public GunBehaviour currentGun = null;
    [Header("Scene Assets")]
    public CubeManager cubeManager;
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

        if(Input.GetKeyDown("f")){
            cubeManager.RestartPositions();
        }

    }

    IEnumerator ShootGun(){
        canShoot = false;
        currentGun.muzzleParticles.Play(true);

        GameObject bullet = PoolManager.instance.GetBullet(currentGun.data.bulletID);
        bullet.GetComponent<BulletBehaviour>().gunParent = currentGun;
        bullet.transform.parent = null;
        //bullet.transform.localScale = new Vector3(1,1,1);
        bullet.transform.position = currentGun.bulletPivot.position;
        bullet.transform.rotation = currentGun.bulletPivot.rotation;
        //bullet.transform.position = bulletPivot.position;
        //bullet.transform.rotation = bulletPivot.rotation;

        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = Vector3.zero;
        bulletRigidbody.angularVelocity = Vector3.zero;
        bulletRigidbody.AddForce(bullet.transform.forward *  currentGun.data.bulletSpeed);
        //if(currentGun.bulletID == 1)
        if(currentGun.data.isParabolic)
            bulletRigidbody.AddForce(new Vector3(0,currentGun.data.bulletSpeed * 0.3f,0));

        gunAnimator.Play("ShootGun");

        yield return new WaitForSeconds(currentGun.data.shootDelay);
        canShoot = true;
    }

    void SetGun(){

        if(currentGun == null){
            GameMenuManager.instance.SetAim(true);
        }else{
            PoolManager.instance.RecycleItem(currentGun.gameObject);
        }
        currentGun = PoolManager.instance.GetGun(pickID).GetComponent<GunBehaviour>();
        currentGun.transform.SetParent(gunPivot);
        currentGun.transform.localPosition = Vector3.zero;
        currentGun.transform.localRotation = Quaternion.identity;
        currentGun.transform.localScale = new Vector3(1,1,1);
        gunAnimator.Play("GetGun");
    }
}
