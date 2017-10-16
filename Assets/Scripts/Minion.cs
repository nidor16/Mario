﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour {

	public float minionSpeed;
	public AudioSource deathSound;
	public int minionValue;
	public static Minion instance = null;

	private Vector3 minionPos;
	private int direction = 1;
	private Animator animMin;

	void Awake () 
	{
		animMin = GetComponent<Animator> ();
		deathSound = GetComponent<AudioSource> ();
	}
		
	void Start ()
	{
		if (instance == null)
			instance = this;
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
		else if(other.gameObject.CompareTag("Player"))
			{
				//minionSpeed = 0f;
			}
	}

	void OnTriggerEnter (Collider other)
	{
		if (!Mario.instance.isDead && other.gameObject.CompareTag("Player")) 
		{
			StartCoroutine (bump ());
		}
	}

	IEnumerator bump()
	{
		Mario.instance.movement.y = Mario.instance.jumpSpeed * 0.25f;
		minionSpeed = 0f;
		deathSound.Play ();
		animMin.SetBool ("dead", true);
		this.gameObject.GetComponent<BoxCollider>().enabled = false;
		Controller.instance.points += minionValue;
		yield return new WaitForSeconds (0.2f);
		Destroy (gameObject);
	}
}
