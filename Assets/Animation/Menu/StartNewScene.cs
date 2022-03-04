using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartNewScene : MonoBehaviour
{
    public bool newScene = false;

    public void Update() {
        if (newScene) SceneManager.LoadScene("Title");    
    }
}
