using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	public AudioSource coin;

	void Awake()
	{
		coin = GetComponent<AudioSource> ();
	}

	IEnumerator OnTriggerEnter(Collider other)
	{
		coin.Play ();
		this.gameObject.GetComponent<BoxCollider>().enabled = false;
		this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
		yield return new WaitForSeconds (2f);
		Destroy (gameObject);
	}
}
