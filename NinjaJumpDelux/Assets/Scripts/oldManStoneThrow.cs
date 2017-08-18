using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oldManStoneThrow : MonoBehaviour {
	public GameObject Stone;
	private bool stonethrow;
	private Animator anim;

	// Use this for initialization
	void Start () {
		stonethrow = false;
		anim = GetComponent<Animator> ();
		ran = true;

	}

	private bool ran;
	private float random;
	// Update is called once per frame
	void Update () {
		Vector3 v = transform.position;
		if (ran == true) {
			random = Random.Range (2.8f,3.1f);
			ran = false;
		}
	//	Debug.Log ("stone..." +v.y);
		if (v.y <= 2.8 && stonethrow == false) {
			anim.SetBool ("isThrow", true);
			Stone.SetActive (true);
			stonethrow = true;
			anim.SetBool ("isThrow", false);
		}


	}
}
