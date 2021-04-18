using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager instance;
    public List<GunBehaviour> gunPrefabList;
    List<GunBehaviour> gunList = new List<GunBehaviour>();

    void Awake(){
        instance = this;
    }

    public GameObject GetGun(int id){
        GameObject prefabGun = null;

        foreach(GunBehaviour gun in gunList){
            if(gun.gunCode == id && !gun.gameObject.activeSelf){
                prefabGun = gun.gameObject;
                prefabGun.gameObject.SetActive(true);
            }
        }

        if(prefabGun == null){
            foreach(GunBehaviour gun in gunPrefabList){
                if(gun.gunCode == id){
                    prefabGun = gun.gameObject;
                }
            }
            prefabGun = Instantiate(prefabGun,Vector3.zero,Quaternion.identity);
        }
        
        gunList.Add(prefabGun.GetComponent<GunBehaviour>());
        return prefabGun;
    }

    public void RecycleGun(GameObject gun){
        gun.SetActive(false);
        gun.transform.SetParent(this.transform);
    }
}
