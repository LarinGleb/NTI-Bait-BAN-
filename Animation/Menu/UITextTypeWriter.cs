using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UITextTypeWriter : MonoBehaviour 
{

	Text txt;
	public string story;
	public float speed = 0.200f;
	public bool IsDestroy = true;
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
			yield return new WaitForSeconds (speed);
		}
		yield return new WaitForSeconds (0.500f);
		if (IsDestroy) {
			txt.text = "";
			Destroy(this);
		}
		
	}

}