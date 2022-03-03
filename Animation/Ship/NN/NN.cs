using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NN : MonoBehaviour
{
    private Animator Anim;
    public Text text;
    public string story = "Я твой ИИ. У тебя 1 новое задание: высадиться на станцию и захватить её. Посадочный модуль находится на этом этаже. Удачи.";
    private bool StartedAnimation = false;

    void Start() {
        Anim = GetComponent<Animator>();

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (!StartedAnimation) {
            Anim.SetBool("Create", true); 
            UITextTypeWriter writer = text.gameObject.AddComponent<UITextTypeWriter>();
            writer.story = story;
            StartedAnimation = true;
        }
        
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        Anim.SetBool("Destroy", true);
        Anim.SetBool("Create", false); 
        
    }
    public void DestroySelf() {
        Destroy(gameObject.GetComponent<Animator>());
        Destroy(gameObject.GetComponent<Collider2D>());
        Destroy(this);
    }
    
}
