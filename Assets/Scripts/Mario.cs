﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mario : MonoBehaviour {

	public float moveSpeed;
	public float jumpSpeed;
	public Vector3 movement;
	public AudioSource aSource;
	public AudioClip marioJump;
	public AudioClip marioDead;
	public static Mario instance = null;
	public bool isDead = false;

	private CharacterController controller;
	private Animator anim;

	void Awake()
	{
		aSource = GetComponent<AudioSource> ();
		controller = GetComponent<CharacterController> ();
		anim = GetComponent<Animator> ();
	}

	void Start()
	{
		if (instance == null)
			instance = this;
		else if (instance != null)
			Destroy (gameObject);
		
		anim.SetBool ("wright", true);
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

		if (Input.GetButton ("Jump") && controller.isGrounded == true && isDead == false) 
			{
				aSource.clip = marioJump;
				aSource.volume = 0.7f;
				aSource.Play ();
				movement.y = jumpSpeed;
			}
			
		controller.Move (movement * Time.deltaTime);
		}

	public void Death()
	{
		isDead = true;
		moveSpeed = 0f;
		movement.y = jumpSpeed * 0.7f;
		anim.SetBool ("death", true);
		Controller.instance.music.Stop ();
		aSource.clip = marioDead;
		aSource.volume = 1f;
		aSource.Play ();
		StartCoroutine (StartDie ());
	}

	public void DeathA()
	{
		isDead = true;
		moveSpeed = 0f;
		Controller.instance.music.Stop ();
		aSource.clip = marioDead;
		aSource.volume = 1f;
		aSource.Play ();
		StartCoroutine (StartDie ());
	}

	IEnumerator StartDie()
	{
		yield return new WaitForSeconds (0.4f);
		this.gameObject.GetComponent<CharacterController>().enabled = false;
		this.gameObject.GetComponent<Rigidbody> ().useGravity = true;
		yield return new WaitForSeconds (5f);
		SceneManager.LoadScene ("Main");
	}

	void Animations()
	{
		if (Input.GetKey(KeyCode.D) && controller.isGrounded && anim.GetBool ("jumpleft") == false && anim.GetBool ("jumpright") == false)
		{
			anim.SetBool ("wright", true);
			anim.SetBool ("wleft", false);
		}

		if (Input.GetKey (KeyCode.A) && controller.isGrounded && anim.GetBool ("jumpleft") == false && anim.GetBool ("jumpright") == false) 
		{
			anim.SetBool ("wleft", true);
			anim.SetBool ("wright", false);
		}

		if (anim.GetBool ("wright") == true && anim.GetBool ("wleft") == false) 
		{
			if (controller.isGrounded) 
			{
				anim.SetBool ("jumpright", false);

				if (Input.GetKey (KeyCode.D)) 
				{
					anim.SetBool ("runright", true);
					anim.SetBool ("runleft", false);
				} 
				else 
				{
					anim.SetBool ("runright", false);
				}
			} 
			else 
			{
				anim.SetBool ("jumpright", true);
				anim.SetBool ("runright", false);
			}
		} 
		else if (anim.GetBool ("wright") == false && anim.GetBool ("wleft") == true)
		{
			if (controller.isGrounded) 
			{
				anim.SetBool ("jumpleft", false);

				if (Input.GetKey (KeyCode.A)) 
				{
					anim.SetBool ("runleft", true);
					anim.SetBool ("runright", false);
				} 
				else 
				{
					anim.SetBool ("runleft", false);
				}
			} 
			else 
			{
				anim.SetBool ("jumpleft", true);
				anim.SetBool ("runleft", false);
			}
		}
	}

}