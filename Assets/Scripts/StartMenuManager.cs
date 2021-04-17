using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StartMenuManager : MonoBehaviour
{
    [Header("Character Assets")]
    public Animator characterAnimator;
    public float rotationSpeed = 0.1f;
    Transform characterTransform;
    [Header("UI Assets")]
    public CanvasGroup whiteFade;

    void Awake(){
        characterTransform = characterAnimator.transform;
    }
    public void ChangeCharacterAnimation(string animationName){
        characterAnimator.Play(animationName);
        SetFade();
        characterTransform.transform.rotation = Quaternion.Euler(0,180,0);
    }

    public void GoToGame(){
        
    }

    void SetFade(){
        whiteFade.alpha = 1;
        whiteFade.DOFade(0f,0.5f);
    }

    void Update(){
        characterTransform.Rotate(0,rotationSpeed,0);
    }
}
