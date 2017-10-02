using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour {

	public float minionSpeed;

	private Rigidbody rb;
	private Vector3 minionPos;
	private int direction = 1;

	void Awake () 
	{
		rb = GetComponent<Rigidbody> ();
	}
		
	void Start ()
	{
		direction *= -1;
	//	Quaternion minionRot;
	//	minionRot = new Quaternion (0, 180, 0,0);
	//	transform.rotation = minionRot;
	}

	void Update () {
		Move ();
	}

	private void OnCollisionEnter (Collision other)
	{
		if(other.gameObject.CompareTag("Block"))
		{
			direction *= -1;

			//Quaternion minionRot;
			//minionRot = new Quaternion (0, 180, 0,0);
			//transform.rotation = minionRot;
		}
	}

	private void Move()
	{
		float xPos = transform.position.x + Time.deltaTime * minionSpeed * direction;
		minionPos = new Vector3 (xPos, -3f, 0f);
		transform.position = minionPos;
	}


}
