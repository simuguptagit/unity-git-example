using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birds : MonoBehaviour {
	Animator anim;
	Vector3 PointA;
	Vector3 PointB;
	Vector3 PointC;
	private static bool onPosA;
	private static float cureenttime;
	private static float total;
	public int ran;
	private static bool posDown;
	private static bool birdWait;
	private static float walking;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		//bird_animation ();
		PointB = new Vector3 (2.4f, -3f, 52.4f);
		PointC = new Vector3 (-2.3f, -3f, 52.4f);
		posDown = false;
		birdWait = true;
		MyConstant.bird_point = false;
		walking = .1f;
		//Debug.Log ("birdddff///.." + birdWait+"  "+birdWait+"   "+anim.transform.position+"  "+MyConstant.instanciateBird);
		MyConstant.instanciateBird = true;

	}

	IEnumerator Birds(){
		
		yield return new WaitForSeconds (.5f);
		PointA = anim.transform.position;
		if (ran == 1) {
			transform.rotation = Quaternion.Euler (new Vector3 (-3.849f, -178.392f, 24.54f));
		}
		else if (ran == 2) {
			transform.rotation = Quaternion.Euler (new Vector3 (0, 0,22.083f));
		}
		anim.SetBool("fly" , true);
		cureenttime = 0;
		total = 1f;
		onPosA = true;
		MyConstant.bird_point = true;
		Generate.AfterBirdGenerate = true;
			}

	// Update is called once per frame
	void Update () {

		if (anim.GetBool ("flyDestroy") == true) birdWait = false;
			
		//Debug.Log ("w888jjjjjjjj." + birdWait+"  "+anim.transform.position+"  "+anim.GetBool ("flyDestroy"));
		if (birdWait) {//Debug.Log ("here.." + birdWait+"  "+posDown+"  "+anim.transform.position);
			Vector3 v = anim.transform.position;
			v.y -= walking;
		    transform.position = v;
			if (posDown == false && v.y <= 3) {
				birdWait = false;
				StartCoroutine (Birds ());
			} 
		}

		if (onPosA == true)
		{
			cureenttime += Time.deltaTime;
			float per = cureenttime / total;
			if (ran == 1) {
				anim.transform.position = Vector3.Lerp (PointA, PointB, per);
			}else if(ran ==2){
				anim.transform.position = Vector3.Lerp (PointA, PointC, per);
			}
			if(cureenttime>=total)
			{
				onPosA = false;
				MyConstant.bird_point = false;
				if (ran == 1) {
					transform.rotation = Quaternion.Euler (new Vector3 (-2.687f, -176.809f, -2.705f));
				}
				else if (ran == 2) {
					transform.rotation = Quaternion.Euler (new Vector3 (0, 0, 0));
				}
				anim.SetBool("fly" ,false);
				walking = .05f;
				birdWait = true;
				posDown = true;
				}
		}
		AnimatorStateInfo animState = anim.GetCurrentAnimatorStateInfo (0);
		/*if (collisionMidOfFly == true) {
			anim.SetBool("flyDestroy" ,true);
			onPosA = false; 
			if (animState.normalizedTime >= 0.99f) {
				//Debug.Log ("????.." + animState);
				collisionMidOfFly = false;
			//	MyConstant.bird_point = false;
				birdWait = false;
			}

		} */
	}
}
