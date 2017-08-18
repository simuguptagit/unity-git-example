using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bg_ScrollingController : MonoBehaviour {

	private bool scrollndfall;
	private Vector3 startPosition;
	private float currentPosition=0;
	private float startHeightcalculation;
	public  Text countText;
	public static int count;
	private float StartTimeOnLoad=0;
	private static float scoreweight;
	//public GameObject bestScore;
	public static bool bestscoreanim;
	void Start ()
	{
	//	Debug.Log ("how many times..");
		MyConstant.Ladders_Velocity_inStart = true;
		Generate.count = 0;
		bestscoreanim = false;
		startPosition = transform.position;
		scrollndfall = true;
		MyConstant.getlevel1 (MyConstant.Level1);
		count = MyConstant.score;
		SetScore (count);
		StartTimeOnLoad = Time.time;
		Generate.TempList.Clear ();
		Generate.count = 0;
		scoreweight = .5f;
		StartCoroutine (checkHeight ());
		StartCoroutine (startHeight ());
	//	Debug.Log ("Qkyaa..."+MyConstant.RepeatWallTime+"  "+MyConstant.score);
			}

	IEnumerator checkHeight(){
		yield return new WaitForSeconds(10f);
		scoreweight -= .05f;
		StartCoroutine (checkHeight ());
	}
	IEnumerator countHeight(float x){
		yield return new WaitForSeconds (x);
		count++;
		SetScore (count);
		startHeightcalculation += x;
		if(startHeightcalculation<scoreweight) StartCoroutine (countHeight (scoreweight/3));
	}
	IEnumerator startHeight(){
		if (PauseAndResume.pause == false && MyConstant.gamePlay == true) {
			startHeightcalculation = 0;
			StartCoroutine (countHeight (scoreweight/3));
			yield return new WaitForSeconds (scoreweight);
			count++;
			SetScore (count);
			StartCoroutine (startHeight ());
		}
	}

	public void SetScore(int count){
		countText.text = count.ToString();
		//Debug.Log ("testing..." + count + "  " + PlayerPrefs.GetInt ("bestHeight")+"  "+bestscoreanim);
		//if (bestscoreanim == false && PlayerPrefs.GetInt ("bestHeight")!= 0 && PlayerPrefs.GetInt ("bestHeight") < count) {
			//PlayerPrefs.SetInt ("bestHeight", count);
			//StartCoroutine (showBestBlinkHeight ());
			//bestscoreanim = true;
		//}
	}

	IEnumerator showBestBlinkHeight(){
		//bestScore.SetActive (true);
		yield return new WaitForSeconds (2f);
		//bestScore.SetActive (false);
	}

	void Update ()
	{   
			
		float newPosition = Mathf.Repeat((Time.time-StartTimeOnLoad )* (MyConstant.scrollSpeed), MyConstant.tileSizeZ);
		//Debug.Log ("heyyy..."+newPosition+"  "+currentPosition+"  "+Time.time);
		if (newPosition>=currentPosition && scrollndfall == true ) {//Debug.Log ("print time.." + StartTimeOnLoad+"  "+Time.time+"  "+currentPosition+"  "+newPosition);
			currentPosition = newPosition;
		transform.position = startPosition + Vector3.down * newPosition;
		}
		else if (scrollndfall == false ) {// Debug.Log("kuch ti..." + StartTimeOnLoad+"  "+Time.time+"  "+currentPosition+"  "+newPosition);
			transform.position = startPosition + Vector3.down * newPosition;
		}
	}

}
