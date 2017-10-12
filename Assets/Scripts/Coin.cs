using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	public int coinValue;
	public AudioSource coin;
	public static Coin instance = null;

	void Start()
	{
		if (instance == null)
			instance = this;
	}

	void Awake()
	{
		coin = GetComponent<AudioSource> ();
	}


	void OnTriggerEnter(Collider other)
	{
		StartCoroutine(Collect());
	}

	IEnumerator Collect()
	{
		coin.Play ();
		this.gameObject.GetComponent<BoxCollider>().enabled = false;
		this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
		Controller.instance.points += coinValue;
		Controller.instance.coins += 1;
		yield return new WaitForSeconds (2f);
		Destroy (gameObject);
	}
}
