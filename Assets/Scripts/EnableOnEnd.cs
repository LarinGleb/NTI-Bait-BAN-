using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnEnd : MonoBehaviour
{
    public bool end = false;

    private void Update() {
        if (end) {
            gameObject.SetActive(false);
            end = false;
        }
    }
}
