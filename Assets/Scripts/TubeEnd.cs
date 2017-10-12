using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeEnd : MonoBehaviour 
{
	public AudioSource winSound;
	public bool winGame = false;
	public static TubeEnd instance = null;


	void Awake()
	{
		winSound = GetComponent<AudioSource> ();
	}

	void Start()
	{
		if (instance == null)
			instance = this;
		else if (instance != null)
			Destroy (gameObject);
	}

	void OnTriggerEnter(Collider other)
	{
		winGame = true;
		Controller.instance.music.Stop ();
		winSound.Play ();
	}
}
