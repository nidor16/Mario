using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionCollision : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (!Mario.instance.isDead && other.gameObject.CompareTag ("Player")) 
		{
			Mario.instance.Death ();
		}
	}
}
