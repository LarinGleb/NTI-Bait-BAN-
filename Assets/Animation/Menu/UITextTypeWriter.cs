using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UITextTypeWriter : MonoBehaviour 
{

	Text txt;
	public string story;
	public float wait = 0.2f;
	public bool IsDestroy = true;
	public bool needToDestroyText = false;
	
	public float WaitAfterDestroy = 0.5f;

	void Start () 
	{
		txt = GetComponent<Text> ();
		txt.text = "";
		StartCoroutine (PlayText(story));
		
	}

	IEnumerator PlayText(string Story)
	{
		foreach (char c in Story) 
		{
			txt.text += c;
			yield return new WaitForSeconds (wait);
		}
		yield return new WaitForSeconds (WaitAfterDestroy);
		if (IsDestroy) {
			txt.text = "";
			if (!needToDestroyText) {Destroy(this);}
			else {this.gameObject.SetActive(false);}
		}
		
	}

}