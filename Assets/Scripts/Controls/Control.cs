using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]

public class Control : MonoBehaviour {

	[SerializeField] private float _Speed = 150;

	public float Speed {
		get {return _Speed;}
		set {_Speed = value;}
	}
	[SerializeField] private float _AddForce = 10;

	public float AddForce {
		get {return _AddForce;}
		set {_AddForce = value;}
	}

	private Vector2 _Direction;
	
	[HideInInspector]
	public Vector3 Direction {
		get {return _Direction;}
		set {_Direction = value;}
	}

	 private float _Vertical;

	[HideInInspector]
	public float Vertical {
		get {return _Vertical;}
		set {_Vertical = value;}
	}


	private float _Horizontal;

	[HideInInspector]
	public float Horizontal {
		get {return _Horizontal;}
		set {_Horizontal = value;}
	}


	private Rigidbody2D _RigidBody;

	void Start () 
	{
		_RigidBody = GetComponent<Rigidbody2D>();
		_RigidBody.fixedAngle = true;

	}

	
	void FixedUpdate()
	{
		_RigidBody.AddForce(_Direction * _RigidBody.mass * _Speed);

		if(Mathf.Abs(_RigidBody.velocity.x) > _Speed/100f)
		{
			_RigidBody.velocity = new Vector2(Mathf.Sign(_RigidBody.velocity.x) * _Speed/100f, _RigidBody.velocity.y);
		}

		if(Mathf.Abs(_RigidBody.velocity.y) > _Speed/100f) {
			_RigidBody.velocity = new Vector2(_RigidBody.velocity.x, Mathf.Sign(_RigidBody.velocity.y) * _Speed/100f);
		}

	}
	
}