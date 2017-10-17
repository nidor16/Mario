using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {

	public int points;
	public int coins;
	public float timeleft;
	public AudioSource music;
	public AudioClip backgroudMusic;
	public Text pointsText;
	public Text coinsText;
	public Text timeText;
	public Text uscorre;
	public GameObject congra;
	public GameObject uscore;
	public GameObject rest;
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
		pointsText.text = "" + points;
		coinsText.text = "" + coins;
		timeText.text = "" +  timeleft;
	}

	void Update () 
	{
		if (!TubeEnd.instance.winGame) 
		{
			timeleft -= Time.deltaTime * 2;

			if (timeleft < 40) 
			{
				music.pitch = 1.4f;
			}

			if (timeleft < 0) 
			{
				timeleft = 0;
			}
		} 
		else 
		{
			StartCoroutine (StartWin ());
		}	

		if (!Mario.instance.isDead && timeleft == 0) 
		{
			Mario.instance.Death ();
		}
			
		UpdateTime ();
		UpdateCoins ();
		UpdatePoints ();
	}

	IEnumerator StartWin()
	{
		Time.timeScale = 0.001f;
		uscorre.text = "Your score: " + points;
		yield return new WaitForSeconds (0.001f);
		congra.SetActive (true);
		yield return new WaitForSeconds (0.002f);
		uscore.SetActive (true);
		yield return new WaitForSeconds (0.002f);
		rest.SetActive (true);
		yield return new WaitForSeconds (0.001f);
		RestartGame ();
	}

	void RestartGame()
	{
		if (Input.GetKey (KeyCode.R)) 
		{
			Time.timeScale = 1f;
			SceneManager.LoadScene ("Main");
		}
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
