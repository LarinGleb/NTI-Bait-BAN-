using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogStart : MonoBehaviour
{
    [SerializeField] Dialog dialogManager;

    int dialog = 0;
    public bool CanGoPlanet = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Craft" && dialog == 0) {
            dialogManager.StartDialog();
            dialog += 1;
            Destroy(other.gameObject.GetComponents<Collider2D>()[0]);
        }
        else if(other.gameObject.name == "Modul" && dialog == 1) {
            Destroy(other.gameObject.GetComponents<Collider2D>()[0]);
            dialogManager.StartDialog();
            dialog += 1;
        }
        else if(other.gameObject.name == "NN" && dialog == 2) {
            dialog += 1;
            CanGoPlanet = true;
           
        }
    }
}
