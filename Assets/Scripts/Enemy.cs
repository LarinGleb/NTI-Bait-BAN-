using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float maxDistance = 5f;
    public GameObject Hero;

    public float DamageByClick = 4f;

    public void OnMouseDown() {

        if (Vector3.Distance(Hero.transform.position, gameObject.transform.position) <= maxDistance) {
            GetComponent<Health>().AddDamage(DamageByClick);
        }
    }
}
