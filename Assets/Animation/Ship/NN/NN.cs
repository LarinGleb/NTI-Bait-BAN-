using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NN : MonoBehaviour
{
    private Animator Anim;
    private bool StartedAnimation = false;

    void Start() {
        Anim = GetComponent<Animator>();

    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        Anim.SetBool("Create", true); 
        Anim.SetBool("Destroy", false); 
        
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        Anim.SetBool("Destroy", true);
        Anim.SetBool("Create", false); 
        
    }

    public void DestroySelf() {
        return;
    }
    
}
