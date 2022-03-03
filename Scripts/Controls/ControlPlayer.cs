using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Control))]
public class ControlPlayer : MonoBehaviour
{

	public bool OnShip;

    [SerializeField] private KeyCode _LeftButton = KeyCode.A;

	public KeyCode LeftButton {
		get {return _LeftButton;}
		set {_LeftButton = value;}
	}

	[SerializeField] private KeyCode _RightButton = KeyCode.D;

	public KeyCode RightButton {
		get {return _RightButton;}
		set {_RightButton = value;}
	}


	[SerializeField] private KeyCode _UpButton = KeyCode.W;

	public KeyCode UpButton {
		get {return _UpButton;}
		set {_UpButton = value;}
	}

	[SerializeField] private KeyCode _DownButton = KeyCode.S;

	public KeyCode DownButton {
		get {return _DownButton;}
		set {_DownButton = value;}
	}

    private Control _Control;

	enum Anim {STAY = 0, RUN = 2}
	private Animator Animator;
	bool facingRight;

	public int JumpForce;

    void Start() {
		Animator = gameObject.GetComponent<Animator>();
        _Control = gameObject.GetComponent<Control>();
    }
	private void Update() {
		if (!OnShip) {
			OnBase();
		}
		else {
			Ship();
		}
	}
	private void Ship() {

		if (Input.GetKey(_RightButton)) {
			Animator.SetInteger("AnimEnum", (int)Anim.RUN);
			_Control.Horizontal = 1; 
		}
		else if (Input.GetKey(_LeftButton)) {
			Animator.SetInteger("AnimEnum", (int)Anim.RUN);
			_Control.Horizontal = -1; 
		}
		else if(Input.GetKey(KeyCode.Space)) {
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpForce));	
		}
		else {
			Animator.SetInteger("AnimEnum", 0);
			_Control.Horizontal = 0;
		}
		if (Input.GetAxisRaw("Horizontal") < 0f && !facingRight) 
        {	
            Flip ();
            facingRight = true;
        } 
		else if (Input.GetAxisRaw("Horizontal") > 0f && facingRight) 
        {
			
            Flip ();
            facingRight = false;
        }
		
		_Control.Direction = new Vector2(_Control.Horizontal, _Control.Vertical);
	}
    void OnBase () 
	{
		if(Input.GetKey(_UpButton)) {
			Animator.SetInteger("AnimEnum", (int)Anim.RUN);
			_Control.Vertical = 0.1f;
		}
		else if(Input.GetKey(_DownButton)) {
			Animator.SetInteger("AnimEnum", (int)Anim.RUN);
			_Control.Vertical = -0.1f;
		} 
		else {
			_Control.Vertical = 0;
		}
		
		if (Input.GetKey(_RightButton)) {
			Animator.SetInteger("AnimEnum", (int)Anim.RUN);
			_Control.Horizontal = 0.1f; 
		}
		else if (Input.GetKey(_LeftButton)) {
			Animator.SetInteger("AnimEnum", (int)Anim.RUN);
			_Control.Horizontal = -0.1f; 
		}
		else {
			Animator.SetInteger("AnimEnum", 0);
			_Control.Horizontal = 0;
			
		}

		_Control.Direction = new Vector2(_Control.Horizontal, _Control.Vertical);
		if (Input.GetAxisRaw("Horizontal") < 0f && !facingRight) 
        {	
            Flip ();
            facingRight = true;
        } 
		else if (Input.GetAxisRaw("Horizontal") > 0f && facingRight) 
        {
			
            Flip ();
            facingRight = false;
        }
		
	}
	
	void Flip()
	{
		facingRight = !facingRight;
    	Vector3 theScale = transform.localScale;
    	theScale.x *= -1;
    	transform.localScale = theScale;
	}
}
