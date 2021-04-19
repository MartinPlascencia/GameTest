using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    List <CubeBehaviour> cubeList = new List<CubeBehaviour>();
    void Start(){
        foreach (Transform child in transform)
{           cubeList.Add(child.GetComponent<CubeBehaviour>());
        }
    }

    public void RestartPositions(){
        GameMenuManager.instance.SetFade();
        foreach(CubeBehaviour cube in cubeList){
            cube.RestartPosition();
        }
    }
}
