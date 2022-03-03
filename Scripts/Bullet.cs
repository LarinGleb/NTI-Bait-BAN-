using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	private float _Damage = 1f;

    public float Damage {
        get {return _Damage;}
        set {_Damage = value;}
    }


	private string[] _KillTags = {"Player", "Enemy"};
  
    public string[] KillTags {
        get {return _KillTags;}
        set {_KillTags = value;}
    }
	public GameObject Who;
	
	public InspectorShooting Ins;

	void OnTriggerEnter2D(Collider2D coll)
	{
		foreach(string currentTag in _KillTags)
		{
			if(currentTag == coll.transform.tag)
			{
				coll.transform.GetComponent<Health>().AddDamage(_Damage);
				InspectorShooting.Inspector.Add(new Shoot(Who, coll.gameObject));
			}
		}
		Destroy(gameObject);
	}

}