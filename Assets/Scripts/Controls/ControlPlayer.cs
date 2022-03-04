using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Control))]
public class ControlPlayer : MonoBehaviour
{

	public bool OnShip;

	public Joystick Joy;

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

		
		bool onJoyStick = Joy.OnJoystick;
		Animator.SetBool("OnJoystick", onJoyStick);

		if (_Control.Horizontal < 0f && !facingRight) 
        {	
            Flip ();
            facingRight = true;
        } 
		else if (_Control.Horizontal > 0f && facingRight) 
        {
            Flip ();
            facingRight = false;
        }
		else {
			_Control.Horizontal = 0;
		}

		_Control.Horizontal = Joy.Horizontal;
		
		_Control.Direction = new Vector2(_Control.Horizontal, _Control.Vertical);
	}

    void OnBase () 
	{
		bool onJoyStick = Joy.OnJoystick;
		Animator.SetBool("OnJoystick", onJoyStick);

		if (_Control.Horizontal < 0f && !facingRight) 
        {	
            Flip ();
            facingRight = true;
        } 
		else if (_Control.Horizontal > 0f && facingRight) 
        {
            Flip ();
            facingRight = false;
        }
		else {
			_Control.Horizontal = 0;
		}

		_Control.Horizontal = Joy.Horizontal;
		_Control.Vertical = Joy.Vertical;
		_Control.Direction = new Vector2(_Control.Horizontal, _Control.Vertical);
		
	}
	
	void Flip()
	{
		facingRight = !facingRight;
    	Vector3 theScale = transform.localScale;
    	theScale.x *= -1;
    	transform.localScale = theScale;
	}
}
