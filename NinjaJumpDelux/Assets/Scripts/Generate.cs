using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour {

	private static float obstcleGenerateTime;
	private static float tempobstcleGenerateTime;
	private static float speed;
	private static float StageInterval;
	public static int  Stage;
	public static int  count;
	public static bool  Obs;
	public static bool AfterBirdGenerate;
	public static bool  powermodetime;
	public static bool  StagChangeWithObsGenerate;
	public static List<GameObject> TempList = new List<GameObject>();

// Use this for initialization
	void Start () {
		MyConstant.getlevel1 (MyConstant.Level1);
		StageInterval = 60f;
		tempobstcleGenerateTime = 4.6f;
		Stage = 1;
		Obs = true;
		powermodetime = false;
		StagChangeWithObsGenerate = false;
		StartCoroutine (WaitForEvery10Seconds ());
		StartCoroutine (GenerateObstacle (MyConstant.List1));
		//Debug.Log ("Hellooo..."+MyConstant.RepeatWallTime);
	}

	IEnumerator WaitForEvery10Seconds(){
		if (MyConstant.velocity.y == -1f) {
			yield return new WaitForSeconds (MyConstant.RepeatWallTime);
			StartCoroutine (StageIntervalTime());
		}
		else if(MyConstant.velocity.y<=-1f) yield return new WaitForSeconds (10f);

		if (Stage == 1 && MyConstant.velocity.y >= -6f) {
			MyConstant.velocity = MyConstant.velocity + new Vector2 (0, -1f);
			tempobstcleGenerateTime = obstcleGenerateTime - .6f;
			//speed = NinjaCollisionDetection.anim.speed+.1f;
			//NinjaCollisionDetection.anim.speed = speed;
		}
		else if (Stage == 2 && MyConstant.velocity.y >= -8f) {
			MyConstant.velocity = MyConstant.velocity + new Vector2 (0, -.5f);
			tempobstcleGenerateTime = obstcleGenerateTime - .2f;
		}
		else if (Stage == 3 && MyConstant.velocity.y >= -10f) {
			MyConstant.velocity = MyConstant.velocity + new Vector2 (0, -.5f);
			tempobstcleGenerateTime = obstcleGenerateTime - .1f;
		}
		StartCoroutine (WaitForEvery10Seconds ());
	}

	IEnumerator StageIntervalTime(){	
		yield return new WaitForSeconds(StageInterval);
		//Debug.Log ("print stage..."+Stage+"  "+MyConstant.RepeatWallTime+"   "+StageInterval+"  "+obstcleGenerateTime);
		StagChangeWithObsGenerate = true;
	}


	IEnumerator GenerateObstacle(List<GameObject> l1){
		//Debug.Log ("not here..");
		obstcleGenerateTime = tempobstcleGenerateTime;
		yield return new WaitForSeconds(obstcleGenerateTime);
	
		if (Stage == 1)  count++;
		int r1 = Draw (count , l1.Count);

		if(MyConstant.gamePlay == true) Instantiate(l1[r1]);

		//Debug.Log ("generate obstacle.." +Obs+"  "+obstcleGenerateTime+"  "+Stage+"    "+r1+"  "+l1[r1]);
		if (StagChangeWithObsGenerate == true) StageChange ();

		if (Obs == true) {
			if (Stage == 1) StartCoroutine (GenerateObstacle (MyConstant.List1));
			if (Stage == 2) StartCoroutine (GenerateObstacle (TempList));	
			if (Stage == 3) StartCoroutine (GenerateObstacle (MyConstant.List3));
		}
	}
	void StageChange(){

		if (Stage == 1) {

			StageInterval =100;
			obstcleGenerateTime = 2f;
			for (int i = 0; i < 20; i++) {
				if (i < 10) {
					int r = Random.Range (0, (MyConstant.List2.Count / 2)-1);
					TempList.Add (MyConstant.List2 [r]);
				}else if( i>=10 && i<14){
					int r = Random.Range (6, 8);
					TempList.Add (MyConstant.List2 [r]);
				}else if( i>=14 && i<18){
					int r = Random.Range (8, 10);
					TempList.Add (MyConstant.List2 [r]);
				}else{
					int r = Random.Range (4, 6);
					TempList.Add (MyConstant.List2 [r]);
				}
			}
			Stage = 2;
			StagChangeWithObsGenerate = false;
			StartCoroutine (StageIntervalTime());
		} else if (Stage == 2) {//Debug.Log ("stage change here...");
			Stage = 3;
			obstcleGenerateTime = 1.6f;
			StagChangeWithObsGenerate = false;
		}
	}
	int  Draw(int c , int count){
		int r1 = 0;
		//Debug.Log ("powerrr..."+Stage +"  "+NinjaCollisionDetection.PowerMode + "  " + r1+"  "+c+"  "+count);
		if (Stage == 1) {
			if (c == 19) r1 = Random.Range (count - 2, count);
			else r1 = Random.Range (0, count - 2);
		}
		else if(Stage == 2) {
			r1 = Random.Range (0, count);

			while ((MyConstant.powerinstantiate == true) && r1 >=10 && r1 <14) {
				r1 = Random.Range (0, count);//Debug.Log ("in while loop2222.." +r1);
			}
			while (MyConstant.instanciateBird == true && r1 >= 14 && r1 < 18){
				r1 = Random.Range (0, count);
			}
			if (r1 >= 14 && r1 < 18) Obs = false;

			if (MyConstant.powerinstantiate == false && r1 >= 10 && r1 < 14) {
				MyConstant.powerinstantiate = true;
				StartCoroutine (powermodeintanciateime());
			}
		}
		else if(Stage == 3) {
			r1 = Random.Range (0, count);
			
			while ((MyConstant.powerinstantiate == true) && r1 >=6 && r1 < 8) {
				r1 = Random.Range (0, count);//Debug.Log ("in while loop2222.." +r1);
			}
			while (MyConstant.instanciateBird == true && r1 >= 8 && r1 < 10){
				r1 = Random.Range (0, count);
			}
			if (r1 >= 8 && r1 < 10) Obs = false;
			if (MyConstant.powerinstantiate == false && r1 >= 6 && r1 < 8) {
				MyConstant.powerinstantiate = true;
				StartCoroutine (powermodeintanciateime());
			}
		}
		return r1;
		}
	IEnumerator powermodeintanciateime(){
		yield return new WaitForSeconds (20f);
		MyConstant.powerinstantiate = false;
	}
		// Update is called once per frame
	void Update () {
	
		if (Obs == false && AfterBirdGenerate == true) {
			AfterBirdGenerate = false;
			Obs = true;
			if (Stage == 2) StartCoroutine (GenerateObstacle (TempList));	
			if (Stage == 3) StartCoroutine (GenerateObstacle (MyConstant.List3));	
		}
	}
}
