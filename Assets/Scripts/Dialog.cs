using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialog : MonoBehaviour
{
    [SerializeField] GameObject DialogWindow;
    [SerializeField] GameObject Hero;
    [SerializeField] AudioClip music;

    private int dialogState = -1;
    public void Start() {
        DialogWindow.SetActive(true);
        GetComponents<Titles>()[0].EnableManager();
        GetComponents<Titles>()[0].StartTitles();
        
    }

    public void ClearDialog(float WaitAfter = 0f) {
        StartCoroutine(ClearWindow(WaitAfter));
        
    }

    public IEnumerator ClearWindow(float WaitAfter) {
        DialogWindow.SetActive(false);
        dialogState += 1;
        yield return new WaitForSeconds(WaitAfter);
    }

    public IEnumerator Station() {
        StartDialog();
        GetComponent<AudioSource>().clip = music;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(5f);
        for (int i = 5; i < GetComponent<AudioSource>().clip.length; i++) {
            if (Random.Range(0, 50) == 5) {
                SceneManager.LoadScene("Final");
                yield break;
            }
            yield return new WaitForSeconds(1f);
            
        }
        SceneManager.LoadScene("Final");
    }
    public void StartDialog() {
        DialogWindow.SetActive(true);
        GetComponents<Titles>()[0].EnableManager();
        GetComponents<Titles>()[0].StartTitles();
        StartCoroutine(WaitAfter());
    }

    public IEnumerator WaitAfter() {
        
        yield return new WaitForSeconds(1f);
        dialogState += 1;
    }
    public void Update() {
        if (dialogState == 0) {
            Hero.transform.Rotate(0, 0, -90);
            dialogState += 1;
            StartCoroutine(WaitAfter());
            StartDialog();
        }


    }
}
