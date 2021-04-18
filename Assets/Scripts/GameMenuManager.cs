using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameMenuManager : MonoBehaviour
{
    [Header("Character Assets")]
    public Animator characterAnimator;
    public float rotationSpeed = 0.1f;
    Transform characterTransform;
    [Header("UI Assets")]
    public CanvasGroup whiteFade;
    public Text pickText;
    public GameObject aimImage;

    public static GameMenuManager instance;

    void Awake(){
        HideItemText();
        SetAim(false);
        instance = this;
        characterTransform = characterAnimator.transform;
        characterAnimator.Play("Macarena_Dance");
    }

    public void ChangeCharacterAnimation(string animationName){
        SetFade();
        characterTransform.transform.rotation = Quaternion.Euler(0,180,0);
    }

    public void SetAim(bool active){
        aimImage.SetActive(active);
    }

    void SetFade(){
        whiteFade.alpha = 1;
        whiteFade.DOFade(0f,0.5f);
    }

    void Update(){
        characterTransform.Rotate(0,rotationSpeed,0);
    }

    public void SetItemText(string itemName){
        pickText.text = "Press right click\nto get <color=red>" + itemName + "</color>";
        pickText.gameObject.SetActive(true);
    }

    public void HideItemText(){
        pickText.gameObject.SetActive(false);
    }
}
