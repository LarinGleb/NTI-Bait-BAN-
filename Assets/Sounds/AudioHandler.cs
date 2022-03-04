using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioHandler : MonoBehaviour
{
    [SerializeField] List<AudioClip> FirstSounds;
    [SerializeField] List<AudioClip> SecondSounds;
    [SerializeField] Text TextSleep;
    [SerializeField] GameObject WaitText;
    [SerializeField] GameObject sheep;
    [SerializeField] GameObject Phone;

    private Animator Anim;

    private bool Started = false;
    void Start() {
        Anim = Phone.GetComponent<Animator>();
    }

    private void Update() {
        if (!Started && !WaitText.activeSelf) {
            Started = true;
            StartCoroutine(StartSound());
        }
    }

    
    public IEnumerator StartSound()
    {
        for(int i = 0; i < FirstSounds.Count; i++)
        {
            if (i == 1) {
                TextSleep.text = "Проснись!";
            }
            else if(i == 2) {
                TextSleep.text = "Проснись пожалуйста!";
            }
            else {
                TextSleep.text = "";
            }

            AudioSource audio = GetComponent<AudioSource>();
            gameObject.GetComponent<AudioSource>().clip = FirstSounds[i];
            gameObject.GetComponent<AudioSource>().Play();
            
            yield return new WaitForSeconds(audio.clip.length);
        }
        TextSleep.text = "А вы уверены, что сейчас не спите?";
        yield return new WaitForSeconds(0.04f);
        TextSleep.text = "";

        yield return new WaitForSeconds(1f);
        sheep.SetActive(true);
        Anim.SetBool("StartTitle", true);
        GetComponent<Titles>().StartTitles();
        for(int i = 0; i < SecondSounds.Count; i++)
        {


            AudioSource audio = GetComponent<AudioSource>();
            gameObject.GetComponent<AudioSource>().clip = SecondSounds[i];
            gameObject.GetComponent<AudioSource>().Play();
            
            yield return new WaitForSeconds(audio.clip.length - 4f);
        }

        Phone.SetActive(true);
        Anim.SetBool("StartTitle", false);
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Game");
 
    }
}
