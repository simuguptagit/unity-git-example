using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsObstacle : MonoBehaviour {

	//private Vector2 velocity = new Vector2(0, -5);
	public Rigidbody2D rbobs;
	private bool genrateWalls;
	public float destroyTime;

	void Start (){
		if (Generate.Stage == 2) destroyTime = 7f;
		else destroyTime = 12f;

		StartCoroutine (destroyWalls());
		genrateWalls = false;
		/*if (MyConstant.Ladders_Velocity_inStart == true) {
			StartCoroutine (WallSpeed ());
		}*/
	}

	IEnumerator WallSpeed(){
		yield return new WaitForSeconds(3f);
		MyConstant.velocity = MyConstant.velocity + new Vector2 (0, -.1f);
		MyConstant.Ladders_Velocity_inStart = false;
	}

	// Use this for initialization
	void Update()
	{   
		if (MyConstant.gamePlay == false) {
			Vector2 velocity1 = new Vector2(0, 7);
			rbobs.velocity = velocity1;
		}else rbobs.velocity = MyConstant.velocity;
		//rbobs.velocity = new Vector2(0,-6);
	   //Debug.Log ("walssssssss..." + rbobs.velocity + "  " + rbobs.position+"  "+genrateWalls);
		if (genrateWalls == false && rbobs.position.y< -6f) {genrateWalls = true;
				Instantiate (MyConstant.rocks);
		}
		transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);


	}

	IEnumerator destroyWalls(){
		
		yield return new WaitForSeconds(destroyTime);
		Destroy(this.gameObject);
	}
}
