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

	void Awake()
	{
		music = GetComponent<AudioSource> ();
	}

	void Start()
	{
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
	}

	void UpdatePoints()
	{
		
	}

	void UpdateCoins()
	{
		
	}

	void UpdateTime()
	{
		timeText.text = "" + Mathf.RoundToInt (timeleft);
	}
}
