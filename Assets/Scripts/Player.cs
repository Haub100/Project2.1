using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	private Animator animator;
	private bool _isFacingRight;
	private CharacterController2D _controller;
	private float _normalizedHorizontalSpeed;
	public GameObject jumpAudio;

	public float MaxSpeed = 8;
	public float SpeedAccelerationOnGround = 10f;
	public float SpeedAccelerationInAir = 5f;

	public bool IsDead { get; private set; }
	//private Vector2 NoVelo = new Vector2 (0f, 0f);

	public void Awake()
	{
	}

	public void Start()
	{
		animator = this.GetComponent<Animator> ();
		_controller = GetComponent<CharacterController2D> ();
		_isFacingRight = transform.localScale.x > 0;
	}

	public void Update()
	{
		if(!IsDead)
			HandleInput ();

		var movementFactor = _controller.State.IsGrounded ? SpeedAccelerationOnGround : SpeedAccelerationInAir;

		if (IsDead)
			_controller.SetHorizontalForce (0);
		else
			_controller.SetHorizontalForce(Mathf.Lerp (_controller.Velocity.x, _normalizedHorizontalSpeed * MaxSpeed, Time.deltaTime * movementFactor));
		//Debug.Log (_controller.Velocity);
	}

	public void Kill()
	{
		GetComponent<Collider2D>().enabled = false;
		//transform.rotation = Quaternion.Euler (0f, 0f, 90f);
		IsDead = true;
		_controller.dead = true;
	}

	public void RespawnAt(Transform spawnPoint)
	{
		if (!_isFacingRight)
			Flip ();

		//transform.rotation = Quaternion.Euler (0f, 0f, 0f);

		GetComponent<Collider2D> ().enabled = true;


		transform.position = spawnPoint.position;
		animator.SetTrigger ("Spawn");
		//Debug.Log (_controller.Velocity);
		//_controller.SetForce(NoVelo);
		//Debug.Log (_controller.Velocity);
		IsDead = false;

		//animator.ResetTrigger ("Spawn");

	}

	void OnTriggerEnter2D (Collider2D trigger)
	{
		if (trigger.gameObject.tag.Equals ("Slow")) 
		{
			//Debug.Log ("Entered Log Trigger! " + trigger.gameObject.name);
			MaxSpeed = 2;

		}
		if (trigger.gameObject.tag.Equals ("Sketchbook")) 
		{
			Application.LoadLevel(2);
		}
		/*if (trigger.gameObject.name.Equals ("Death")) 
		{
			Debug.Log ("Entered Log Trigger! " + trigger.gameObject.name);
			transform.position = StartingPosition;
		}
		if (trigger.gameObject.name.Equals ("Death2")) 
		{
			Debug.Log ("Entered Log Trigger! " + trigger.gameObject.name);
			transform.position = Checkpoint;
		}
		if (trigger.gameObject.name.Equals ("Death3")) 
		{
			Debug.Log ("Entered Log Trigger! " + trigger.gameObject.name);
			transform.position = WinPoint;
		}*/
	}

	void OnTriggerExit2D (Collider2D trigger)
	{
		if (trigger.gameObject.tag.Equals ("Slow")) 
		{
			//Debug.Log ("Entered Log Trigger! " + trigger.gameObject.name);
			MaxSpeed = 15;
		}
	}

	private void HandleInput()
	{
		if (Input.GetKey (KeyCode.D)) 
		{
			_controller.dead = false;
			_normalizedHorizontalSpeed = 1;
			if(!_isFacingRight)
				Flip();
		}
		else if(Input.GetKey(KeyCode.A))
		{
			_controller.dead = false;
			_normalizedHorizontalSpeed = -1;
			if(_isFacingRight)
				Flip();
		}
		else
		{
			_normalizedHorizontalSpeed = 0;
		}

		if(_controller.CanJump && Input.GetKeyDown(KeyCode.Space))
		{
			_controller.Jump();
			_controller.dead = false;
			jumpAudio.GetComponent<AudioSource>().Play ();
		}
	}

	private void Flip()
	{
		//transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		_isFacingRight = transform.localScale.x > 0;
	}
}


















