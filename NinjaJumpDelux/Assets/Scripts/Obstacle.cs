using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	private Vector2 velocity = new Vector2(0, -5);
	public Rigidbody2D rbobs;
	//public float range;

	void Start (){
		StartCoroutine (destroyWalls());
		if (MyConstant.Ladders_Velocity_inStart == true) {
			StartCoroutine (WallSpeed ());
		}
	}

	IEnumerator WallSpeed(){
		yield return new WaitForSeconds(3f);
		MyConstant.velocity = MyConstant.velocity + new Vector2 (0, -.1f);
		MyConstant.Ladders_Velocity_inStart = false;
	}

	// Use this for initialization
	void Update()
	{   
		/*if (MyConstant.Ladders_Velocity_inStart == true) {
			Vector2 velocity1 = new Vector2(0, -1);
			rbobs.velocity = velocity1;
		}
		else*/ if (MyConstant.gamePlay == false) {
			Vector2 velocity1 = new Vector2 (0, 7);
			rbobs.velocity = velocity1;
		}
		/*else if (Generate.Stage == 2) {
			Vector2 velocity1 = new Vector2(0, -7);
			rbobs.velocity = velocity1;
		}
		else if (Generate.Stage == 3) {
			Vector2 velocity1 = new Vector2(0, -9);
			rbobs.velocity = velocity1;
		}*/
		else {
			rbobs.velocity = MyConstant.velocity;
			//rbobs.velocity = velocity;
		}
			transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		 
	}

	IEnumerator destroyWalls(){
	//	Debug.Log("wall stopingg...");
		yield return new WaitForSeconds(7f);
		//if (MyConstant.powerinstantiate == true)	MyConstant.powerinstantiate = false;
		Destroy(this.gameObject);
	}
}
