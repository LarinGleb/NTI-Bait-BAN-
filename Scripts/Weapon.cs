using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _Bullet;
	
	public GameObject Bullet {
		get {return _Bullet;}
		set {_Bullet = value;}
	}

	[SerializeField] private float _BulletSpeed;

	public float BulletSpeed {
		get {return _BulletSpeed;}
		set {_BulletSpeed = value;}
	}

    [SerializeField] private float _Timeout;

	public float Timeout {
		get {return _Timeout;}
		set {_Timeout = value;}
	}

	[SerializeField] private Transform _GunPoint;

	public Transform GunPoint {
		get {return _GunPoint;}
		set {_GunPoint = value;}
	}

	private float _curTimeout; 

	public InspectorShooting Ins;

    void Update() 
    {
    	if(Input.GetMouseButton(0))
    	{
    		_curTimeout += Time.deltaTime;
    		if(_curTimeout > _Timeout)
    		{
    			_curTimeout = 0;
    			GameObject bulletInstance = Instantiate(_Bullet, _GunPoint.position, Quaternion.identity);
                bulletInstance.GetComponent<Rigidbody2D>().velocity = _GunPoint.right * _BulletSpeed;
				bulletInstance.GetComponent<Bullet>().Who = gameObject;
				bulletInstance.GetComponent<Bullet>().Ins = Ins;
    		}
    	}
    	else
    	{
    		_curTimeout = _Timeout + 1;
    	}
    }

}
