using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Titles : MonoBehaviour
{
    [SerializeField] List<Text> texts;

    private int title = -1;
    private bool startedAnim = false;

    private Dialog dialogManager;

    public void StartTitles() {
        dialogManager = GetComponent<Dialog>();

        title = 0;
    } 
    void Update() {
        if(title == texts.Count && !texts[texts.Count - 1].gameObject.activeSelf) {
            Destroy(this);
        } 
        else {
            if (title > 0 && !texts[title - 1].gameObject.activeSelf) {
            
                texts[title].gameObject.SetActive(true);
                title += 1;
            }
            else if (title == 0 && !startedAnim) {
                startedAnim = true;
                title += 1;
                texts[0].gameObject.SetActive(true);
            
            }
        }
        
        
    }
    private void OnDestroy() {
        if (dialogManager != null) {
            dialogManager.ClearDialog();
        }
    }
}
