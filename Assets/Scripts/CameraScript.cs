using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	private Vector3 camPos;

	void Update () {
		CamMove ();
	}

	private void CamMove()
	{
		float yPos = transform.position.y;
		float zPos = transform.position.z;
		float xPos = Mario.instance.transform.position.x;

		camPos = new Vector3 (Mathf.Clamp(xPos, 0,130), yPos, zPos);
		transform.position = camPos;
	}
}
