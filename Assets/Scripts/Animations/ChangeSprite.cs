using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    public Sprite Near;
    public Sprite Far;

    SpriteRenderer render;

    void Start() {
        render = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        render.sprite = Near;
    }

    private void OnTriggerExit2D(Collider2D other) {
        render.sprite = Far;    
    }
}
