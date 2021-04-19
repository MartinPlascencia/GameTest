using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [Header("Particles Assets")]
    public int bulletID = 1;
    public int explosionID = 1;
    [System.NonSerialized]
    public GunBehaviour gunParent;

    void OnTriggerEnter(Collider collider){
        if(collider.CompareTag("Ground") || collider.CompareTag("ShootCubes")){
            Explode();
        }
    }

    void Explode(){

        GetComponent<Collider>().enabled = false;
        SoundManager.instance.Play("laserExplosion");
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.Sleep();

        ParticleSystem explosionParticles = PoolManager.instance.GetExplosion(explosionID).GetComponent<ParticleSystem>();
        explosionParticles.transform.position = transform.position;
        explosionParticles.Play();
        PoolManager.instance.RecycleParticlesCall(explosionParticles.main.duration,explosionParticles.gameObject);

        SetBulletEffect();
    }

    void SetBulletEffect(){

        switch(bulletID){
            case 1:
                float power = gunParent.data.effectForce;
                float radius = gunParent.data.explosionRadius;
                Vector3 explosionPos = transform.position;
                Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
                foreach (Collider hit in colliders)
                {   
                    if(hit.tag == "ShootCubes"){
                        Rigidbody rb = hit.GetComponent<Rigidbody>();

                        if (rb != null)
                            rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
                    }
                }
                PoolManager.instance.RecycleItem(this.gameObject);
            break;
            case 2:
                StartCoroutine("ImplodeObjects");
            break;
            case 3:
                StartCoroutine("OrbitObjects");
            break;
        }
    }

    IEnumerator ImplodeObjects(){
        float power = gunParent.data.effectForce;
        float radius = gunParent.data.explosionRadius;
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

        float timePassed = 0f;
        while(timePassed <gunParent.data.effectTime){
            foreach (Collider hit in colliders){
                if(hit.tag == "ShootCubes"){   
                    Rigidbody rb = hit.GetComponent<Rigidbody>();

                    if (rb != null)
                        rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
                }
            }
            timePassed+= Time.deltaTime;
            //Debug.Log("Is imploding " + timePassed);
            yield return null;
        }
        PoolManager.instance.RecycleItem(this.gameObject);
        
    }

    IEnumerator OrbitObjects(){
        float orbitSpeed = gunParent.data.effectForce;
        float radius = gunParent.data.explosionRadius;
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

        GameMenuManager.instance.SetFade();
        float timePassed = 0f;
        while(timePassed <gunParent.data.effectTime){
            foreach (Collider hit in colliders){  
                if(hit.tag == "ShootCubes"){
                    Rigidbody rb = hit.GetComponent<Rigidbody>();
                    if (rb != null){
                        rb.MovePosition (Quaternion.AngleAxis(orbitSpeed, hit.transform.forward) * (rb.transform.position - explosionPos) + explosionPos);
                        rb.MoveRotation (rb.transform.rotation * Quaternion.AngleAxis(orbitSpeed, transform.forward));
                    }
                }
            } 
                
            timePassed+= Time.deltaTime;
            //Debug.Log("Is imploding " + timePassed);
            yield return null;
        }
        PoolManager.instance.RecycleItem(this.gameObject);
        
    }
    
}
