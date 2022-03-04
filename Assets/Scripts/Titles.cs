using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Titles : MonoBehaviour
{
    [SerializeField] List<Text> texts;

    private int title = -1;

    private Dialog dialogManager;
    private bool EnableNaager = false;

    public void EnableManager() {
        EnableNaager = true;
    }
    public void StartTitles() {
        if (EnableNaager) {
            dialogManager = GetComponent<Dialog>();
        }
        

        title = 0;
        
    } 
    void Update() {
        if(title == -1) {
            return;
        }
        else if(title == texts.Count && !texts[texts.Count - 1].gameObject.activeSelf) {
            Destroy(this);
        } 
        
        else {
            
            if (title == 0) {
                title += 1;
                texts[0].gameObject.SetActive(true);
            
            }
            else if (!texts[title - 1].gameObject.activeSelf) {
            
                texts[title].gameObject.SetActive(true);
                title += 1;
            }
        }
        
        
    }
    private void OnDestroy() {
        if (EnableNaager) {
            dialogManager.ClearDialog(1f);
        }
    }
}
