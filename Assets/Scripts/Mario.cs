using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour {

	public float moveSpeed;
	public float jumpSpeed;
	public Vector3 movement;
	public AudioSource aSource;
	public AudioClip marioJump;
	public static Mario instance = null;

	public bool isDead = false;

	private CharacterController controller;
	private Animator anim;

	void Awake()
	{
		controller = GetComponent<CharacterController> ();
		anim = GetComponent<Animator> ();
	}

	void Start()
	{
		if (instance == null)
			instance = this;
		else if (instance != null)
			Destroy (gameObject);
	}

	void FixedUpdate()
	{
		
		Movement ();
		Animations ();
	}

	void Movement()
	{
		movement.x = Input.GetAxis ("Horizontal") * moveSpeed;

			if (controller.isGrounded == false) {
				movement.x = Input.GetAxis ("Horizontal") * 0.8f * moveSpeed;
				movement.y += Physics.gravity.y * Time.deltaTime;
			}

			if (Input.GetButton ("Jump") && controller.isGrounded == true) 
			{
				aSource.clip = marioJump;
				aSource.Play ();
				movement.y = jumpSpeed;
			}

			controller.Move (movement * Time.deltaTime);
		}

	private void OnCollisionEnter (Collision other)
	{
		if(other.gameObject.CompareTag("Minion"))
		{
			isDead = true;
			anim.SetBool ("death", true);
			this.gameObject.GetComponent<CharacterController>().enabled = false;
			movement.y = jumpSpeed;
		}
	}

	void Animations()
	{
		if (controller.isGrounded) 
		{
			anim.SetBool ("jumpleft", false);
			anim.SetBool ("jumpright", false);

			if (Input.GetKey (KeyCode.A)) {
				anim.SetBool ("runleft", true);
			} else 
			{
				anim.SetBool ("runleft", false);
			}

			if (Input.GetKey (KeyCode.D)) {
				anim.SetBool ("runright", true);
			} else 
			{
				anim.SetBool ("runright", false);
			}
		}

		if (!controller.isGrounded) 
		{
			anim.SetBool ("runleft", false);
			anim.SetBool ("runright", false);

			if(Input.GetKey (KeyCode.D))
			{
				anim.SetBool ("jumpright", true);
			} else 
			{
				anim.SetBool ("jumpright", false);
			}

			if (Input.GetKey (KeyCode.A)) 
			{
				anim.SetBool ("jumpleft", true);
			} else 
			{
				anim.SetBool ("jumpleft", false);
			}
		}
	}
}