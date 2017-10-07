using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour {

	public float minionSpeed;
	public AudioSource deathSound;

	private Rigidbody rb;
	private Vector3 minionPos;
	private int direction = 1;
	private Animator animMin;

	void Awake () 
	{
		rb = GetComponent<Rigidbody> ();
		animMin = GetComponent<Animator> ();
		deathSound = GetComponent<AudioSource> ();
	}
		
	void Start ()
	{
		direction = -1;
	}

	void Update () 
	{
		Move ();
	}

	private void Move()
	{
		float xPos = transform.position.x + Time.deltaTime * minionSpeed * direction;
		minionPos = new Vector3 (xPos, -3f, 0f);
		transform.position = minionPos;
	}

	private void OnCollisionEnter (Collision other)
	{
		if(other.gameObject.CompareTag("Block") || other.gameObject.CompareTag("Minion") || other.gameObject.CompareTag("Tube"))
		{
			direction *= -1;
		}
	}

	private IEnumerator OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag("Player")) 
		{
			this.gameObject.GetComponent<BoxCollider>().enabled = false;
			deathSound.Play ();
			Mario.instance.movement.y = Mario.instance.jumpSpeed * 0.2f;
			animMin.SetBool ("dead", true);
			minionSpeed = 0f;
			yield return new WaitForSecondsRealtime (0.2f);
			Destroy (gameObject);
		}
	}
}
