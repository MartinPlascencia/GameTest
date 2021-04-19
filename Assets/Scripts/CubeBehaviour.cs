using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    Vector3 initialPosition;
    Quaternion initialRotation;
    void Awake(){
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    public void RestartPosition(){
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        
        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }
}
