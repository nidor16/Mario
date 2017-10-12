using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionCollision : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) 
		{
			gameObject.transform.parent.GetComponent<Minion> ().minionSpeed = 0f;
			Mario.instance.Death ();
		}
	}
}
