using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class StartMenuManager : MonoBehaviour
{
    [Header("Character Assets")]
    public Animator characterAnimator;
    public float rotationSpeed = 0.1f;
    Transform characterTransform;
    [Header("UI Assets")]
    public CanvasGroup whiteFade;
    public GameObject startGameButton;

    void Awake(){
        startGameButton.SetActive(false);
        characterTransform = characterAnimator.transform;
    }

    void Start(){
        SetFade();
    }

    public void ChangeCharacterAnimation(string animationName){
        GameManager.instance.danceName = animationName;
        characterAnimator.Play(animationName);
        SetFade();
        characterTransform.transform.rotation = Quaternion.Euler(0,180,0);
        if(!startGameButton.activeSelf)
            startGameButton.SetActive(true);
    }

    public void GoToGame(){
        whiteFade.DOFade(1f,1f).OnComplete(()=>{
            SceneManager.LoadScene("GameScene");
        });
    }

    void SetFade(){
        whiteFade.alpha = 1;
        whiteFade.DOFade(0f,0.5f);
    }

    void Update(){
        characterTransform.Rotate(0,rotationSpeed,0);
    }
}
