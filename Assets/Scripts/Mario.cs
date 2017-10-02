using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour {

	public float moveSpeed = 10f;
	public float jumpSpeed = 10f;


	private CharacterController controller;
	private Vector3 movement = Vector3.zero;
	private Animator anim;

	void Awake()
	{
		controller = GetComponent<CharacterController> ();
		anim = GetComponent<Animator> ();
	}

	void Update()
	{
		Movement ();

		if (Input.GetKey (KeyCode.A) && controller.isGrounded) {
			anim.SetBool ("runleft", true);
		} else 
		{
			anim.SetBool ("runleft", false);
		}

		if (Input.GetKey (KeyCode.D) && controller.isGrounded) {
			anim.SetBool ("runright", true);
		} else 
		{
			anim.SetBool ("runright", false);
		}

		if (!controller.isGrounded && Input.GetKey (KeyCode.D)) {
			anim.SetBool ("jumpright", true);
			anim.SetBool ("runright", false);
		} else 
		{
			anim.SetBool ("jumpright", false);
		}
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
}