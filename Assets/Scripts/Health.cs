using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	[SerializeField] private float _HP = 10;

	public float HP {
		get {return _HP;}
		set {_HP = value;}
	}

	public InspectorShooting Ins;
	private bool IsAnim;

	public void AddDamage(float damage)
	{
		_HP -= damage;
		if(_HP <= 0)
		{
			Ins.Deaths.Add(gameObject);
			if (IsAnim) {
				gameObject.GetComponent<Animator>().SetBool("Death", true);
			}
			
		}
	}
	public void DestroySelf() {
		Destroy(gameObject);
	}
}