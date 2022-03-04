using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainMenuButton : MonoBehaviour
{
    [SerializeField] Animator anim;
    public void Start() {
        anim.gameObject.SetActive(false);
    }
    public void AnimationStart() {
        anim.gameObject.SetActive(true);
        anim.SetBool("StartGame", true);
        
    }

}
