using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

	public int points;
	public int coins;
	public float timeleft;
	public AudioSource music;
	public AudioClip backgroudMusic;
	public Text pointsText;
	public Text coinsText;
	public Text timeText;
	public static Controller instance = null;

	void Awake()
	{
		music = GetComponent<AudioSource> ();
	}

	void Start()
	{
		if (instance == null)
			instance = this;
		else if (instance != null)
			Destroy (gameObject);
		
		music.clip = backgroudMusic;
		music.Play ();
		points = 0;
		coins = 0;
		timeleft = 180;
		pointsText.text = "" + points;
		coinsText.text = "" + coins;
		timeText.text = "" +  timeleft;
	}

	void Update () 
	{
		timeleft -= Time.deltaTime;
		if (timeleft < 0) {
			timeleft = 0;
		}
		UpdateTime ();
		UpdateCoins ();
		UpdatePoints ();
	}

	void UpdatePoints()
	{
		pointsText.text = "" + points;
	}

	void UpdateCoins()
	{
		coinsText.text = "x " + coins;
	}

	void UpdateTime()
	{
		timeText.text = "" + Mathf.RoundToInt (timeleft);
	}
}
