using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perfect : MonoBehaviour {

	public Animator anim;

	void Awake()
	{
		anim = GetComponent<Animator> ();
	}

	void Update()
	{
		if (TubeEnd.instance.winGame && Controller.instance.points >= 7000) 
		{
			StartCoroutine (wait ());
		}
	}

	IEnumerator wait()
	{
		yield return new WaitForSeconds (0.003f);
		anim.SetBool ("perfect", true);
	}
}
