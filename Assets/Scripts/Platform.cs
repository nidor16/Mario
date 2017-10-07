using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	public AudioSource bump;

	void Awake()
	{
		bump = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter(Collider other)
	{
		Mario.instance.movement.y = Mario.instance.movement.y * -0.5f;
		bump.Play ();
	}
}
