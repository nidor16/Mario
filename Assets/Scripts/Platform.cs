using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	public AudioSource bump;
	public Animator animPlat;

	void Awake()
	{
		bump = GetComponent<AudioSource> ();
		animPlat = GetComponent<Animator> ();
	}

	void OnTriggerStay(Collider other)
	{
		StartCoroutine (wait ());
	}

	IEnumerator wait()
	{
		this.animPlat.SetBool("touch", true);
		Mario.instance.movement.y = Mario.instance.movement.y * -0.5f;
		bump.Play ();
		yield return new WaitForSeconds (0.1f);
		this.animPlat.SetBool("touch", false);
	}
}
