using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour
{
	
	private Animator animator;
	private CharacterController2D _controller;
	public bool IsFacingRight { get; private set; }
	public bool IsMoving { get; private set; }

	public bool IsDead { get; private set; }
	
	// Use this for initialization
	void Start()
	{
		animator = this.GetComponent<Animator>();
		_controller = this.GetComponent<CharacterController2D> ();
		IsFacingRight = transform.localScale.x > 0;
	}
	
	// Update is called once per frame
	void Update()
	{
		if(!IsDead)
			AnimHandleInput ();

		var vertical = Input.GetAxis("Vertical");
		var horizontal = Input.GetAxis("Horizontal");
		

	}

	private void AnimHandleInput()
	{
		if (Input.GetKey (KeyCode.D)) 
		{
			_controller.dead = false;
			IsMoving = true;
			IsFacingRight = true;

		}
		else if(Input.GetKey(KeyCode.A))
		{
			_controller.dead = false;
			IsMoving = true;
			IsFacingRight = false;

		}
		else
		{
			IsMoving = false;
		}
		
		if(_controller.CanJump && Input.GetKeyDown(KeyCode.Space))
		{
			//_controller.Jump();
			//_controller.dead = false;
		}

		if (IsFacingRight == true && IsMoving == false)
		{
			animator.SetInteger("Direction", 0);
			animator.SetBool("IsMoving", false);
		}
		else if (IsFacingRight == false && IsMoving == false)
		{
			animator.SetInteger("Direction", 1);
			animator.SetBool("IsMoving", false);
		}
		else if (IsFacingRight == true && IsMoving == true)
		{
			animator.SetInteger("Direction", 0);
			animator.SetBool("IsMoving", true);
		}
		else if (IsFacingRight == false && IsMoving == true)
		{
			animator.SetInteger("Direction", 1);
			animator.SetBool("IsMoving", true);
		}

	}
}
