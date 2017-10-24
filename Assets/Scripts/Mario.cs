using System.Collections;
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

			if (!controller.isGrounded) {
				movement.x = Input.GetAxis ("Horizontal") * 0.8f * moveSpeed;
				movement.y += Physics.gravity.y * Time.deltaTime;
			}

		if (Input.GetButton ("Jump") && controller.isGrounded && !isDead) 
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
		if(controller.isGrounded && !anim.GetBool ("jumpleft") && !anim.GetBool ("jumpright"))
		{
			if (Input.GetKey (KeyCode.D) && !Input.GetKey (KeyCode.A)) 
			{
				anim.SetBool ("wleft", false);
				anim.SetBool ("wright", true);
			} 

			if (Input.GetKey (KeyCode.A) && !Input.GetKey (KeyCode.D)) 
			{
				anim.SetBool ("wright", false);
				anim.SetBool ("wleft", true);
			}

		}

		if (anim.GetBool ("wright") && !anim.GetBool ("wleft")) 
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
		else if (!anim.GetBool ("wright") && anim.GetBool ("wleft"))
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