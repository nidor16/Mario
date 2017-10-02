using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour {

	public float moveSpeed;
	public float jumpSpeed;
	public Vector3 movement;
	public static Mario instance = null;

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

		if (controller.isGrounded == false) 
		{
			movement.y += Physics.gravity.y * Time.deltaTime;
		}

		if (Input.GetButton ("Jump") && controller.isGrounded == true)
			movement.y = jumpSpeed;

		controller.Move (movement * Time.deltaTime);
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

		if (!(controller.isGrounded)) 
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