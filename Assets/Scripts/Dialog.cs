using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    [SerializeField] GameObject DialogWindow;

    public void Start() {
        DialogWindow.SetActive(true);
        GetComponents<Titles>()[0].StartTitles();
        
    }

    public void ClearDialog() {
        DialogWindow.SetActive(false);
    }
}
