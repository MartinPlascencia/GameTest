using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Game Stats")]
    public string danceName;
    public static GameManager instance;

    void Awake(){
        if(instance == null){
            instance = this;
        }else if(instance != this){
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
