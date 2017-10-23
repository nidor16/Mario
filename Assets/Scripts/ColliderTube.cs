using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTube : MonoBehaviour {

	void Update()
	{
		if(Controller.instance.points >= 6300)
			{
				this.gameObject.SetActive (false);
			}
	}
}
