using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomInOut : MonoBehaviour {
	int min = 15;
	int max = 90;
	float smooth  = .2f;
	Vector3 pos;

	// Use this for initialization
	void Start () {
		//pos = Camera.main.ScreenToViewportPoint;
	}
	
	// Update is called once per frame
	void Update () {
		float fov = Camera.main.fieldOfView;
		if (fov >= 10) {Debug.Log("kyaaaa..."+Camera.main.transform.position);
			fov -= smooth;
			//fov = Mathf.Clamp (fov, min, max);
			Camera.main.fieldOfView = fov;
			Vector3 v = new Vector3 (0, 1, 0);
			Camera.main.transform.Translate (v *-5f * Time.deltaTime);
		}
	}
}
