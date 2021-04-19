using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager instance;
    [Header("Pool Assets")]
    public List<GunBehaviour> gunPrefabList;
    List<GunBehaviour> gunList = new List<GunBehaviour>();
    public List<BulletBehaviour> bulletPrefabList;
    List<BulletBehaviour> bulletList = new List<BulletBehaviour>();
    public List<ExplosionBehaviour> explosionPrefabList;
    List<ExplosionBehaviour> explosionList = new List<ExplosionBehaviour>();

    void Awake(){
        instance = this;
    }

    public GameObject GetGun(int id){
        GameObject prefabGun = null;

        foreach(GunBehaviour gun in gunList){
            if(gun.data.gunID == id && !gun.gameObject.activeSelf){
                prefabGun = gun.gameObject;
                prefabGun.gameObject.SetActive(true);
            }
        }

        if(prefabGun == null){
            foreach(GunBehaviour gun in gunPrefabList){
                if(gun.data.gunID == id){
                    prefabGun = gun.gameObject;
                }
            }
            prefabGun = Instantiate(prefabGun,Vector3.zero,Quaternion.identity);
            gunList.Add(prefabGun.GetComponent<GunBehaviour>());
        }
        
        return prefabGun;
    }

    public GameObject GetBullet(int id){
        GameObject prefabBullet = null;

        foreach(BulletBehaviour bullet in bulletList){
            if(bullet.bulletID == id && !bullet.gameObject.activeSelf){
                prefabBullet = bullet.gameObject;
                prefabBullet.gameObject.SetActive(true);
            }
        }

        if(prefabBullet == null){
            foreach(BulletBehaviour bullet in bulletPrefabList){
                if(bullet.bulletID == id){
                    prefabBullet = bullet.gameObject;
                }
            }
            prefabBullet = Instantiate(prefabBullet,Vector3.zero,Quaternion.identity);
            bulletList.Add(prefabBullet.GetComponent<BulletBehaviour>());
        }
        
        prefabBullet.GetComponent<Collider>().enabled = true;
        return prefabBullet;
    }

    public GameObject GetExplosion(int id){
        GameObject prefabExplosion = null;

        foreach(ExplosionBehaviour explosion in explosionList){
            if(explosion.explosionID == id && !explosion.gameObject.activeSelf){
                prefabExplosion = explosion.gameObject;
                prefabExplosion.gameObject.SetActive(true);
            }
        }

        if(prefabExplosion == null){
            foreach(ExplosionBehaviour explosion in explosionPrefabList){
                if(explosion.explosionID == id){
                    prefabExplosion = explosion.gameObject;
                }
            }
            prefabExplosion = Instantiate(prefabExplosion,Vector3.zero,Quaternion.identity);
            explosionList.Add(prefabExplosion.GetComponent<ExplosionBehaviour>());
        }
        
        return prefabExplosion;
    }

    public void RecycleItem(GameObject item){
        Collider collider = item.GetComponent<Collider>();
        if(collider != null)
            collider.enabled = false;

        item.SetActive(false);
        item.transform.SetParent(this.transform);
    }

    public void RecycleParticlesCall(float duration, GameObject particlesObject){
        StartCoroutine(RecycleParticles(duration,particlesObject));
    }

    public IEnumerator RecycleParticles(float duration,GameObject particlesObject){
        //Debug.Log(duration + " duration");
        yield return new WaitForSeconds(duration);
        RecycleItem(particlesObject);

    }

}
