using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneRotating : MonoBehaviour {
	public int stoneSide;
	// Update is called once per frame
	void Update () {
		Vector3 v = transform.position;
		if(stoneSide == 1) v.x+=.04f;
		else if(stoneSide == 2) v.x-=.04f;
		transform.position = v;
		transform.Rotate (new Vector3(8,8,0)*8f*Time.deltaTime);
	}
}
