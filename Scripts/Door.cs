using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator Anim;

    void Start() {
        Anim = GetComponent<Animator>();

    }

    private void OnTriggerEnter2D(Collider2D other) {
        Anim.SetBool("CanClose", false);   
        Anim.SetBool("CanOpen", true)  ;
         
    }
    private void OnTriggerExit2D(Collider2D other) {
        Anim.SetBool("CanClose", true);
        Anim.SetBool("CanOpen", false);
           
    }
}
