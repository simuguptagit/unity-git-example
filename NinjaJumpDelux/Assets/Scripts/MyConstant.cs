using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyConstant{

	public static string Level1="L1";
	public static bool powerinstantiate;
	public static bool gamePlay;
	public static float scrollSpeed;
	public static float tileSizeZ;
	public static bool Ladders_Velocity_inStart;

	public static float RepeatWallTime;
	public static bool falling;
	public static int fall;
	public static float NomalWallSpeed;
	public static Vector2 velocity;

	public static bool instanciateBird;
	public static bool power;
	public static int powerMode2;
	public static bool bird_point;

	public static int  score;
	public static float modelmovingspeed;


	public static List<GameObject> List1 = new List<GameObject>();
	public static List<GameObject> List2 = new List<GameObject>();
	public static List<GameObject> List3 = new List<GameObject>();
	public static GameObject  testrocks;
	public static GameObject  rocks;
	public static GameObject  bird_obstacle1;
	public static GameObject  bird_obstacle2;



	public static void getlevel1(string Level){
		if (Level.Equals (Level1)) {


			if (PlayerPrefs.GetInt ("sound") == 1) {
				AudioListener.volume = 1;
			} else if (PlayerPrefs.GetInt ("sound") == 2) {
				AudioListener.volume = 0;
			}
			/*...........Game Preferences...........*/
			if(PlayerPrefs.GetInt("bestHeight")==0)  PlayerPrefs.SetInt ("bestHeight", 0);
			if(PlayerPrefs.GetInt("sound")==0)  PlayerPrefs.SetInt ("sound", 1);

			/*.........4r bg.........*/
			gamePlay = true;
			scrollSpeed = .22f;
			tileSizeZ = 39;
			powerinstantiate = false;

			/*.....4r walls and ladders......*/
			RepeatWallTime = 3f;
			score = 0;
			NomalWallSpeed = 1.2f;
			velocity = new Vector2 (0, -1);
			modelmovingspeed = 10f;
			instanciateBird = false;

			/*.............4r obstacle draw interval for hardnes.....*/
		    GameObject[] mygameObjects = Resources.LoadAll<GameObject>("Prefabs");
			rocks = mygameObjects [0];testrocks = mygameObjects [mygameObjects.Length-1];
			List1.Clear();
			List2.Clear();
			List3.Clear();

			for (int i = 1; i < mygameObjects.Length-1; i++) {
			//	Debug.Log ("kkkkk.." + mygameObjects[i]);
				if (i <= 6) {
					List1.Add (mygameObjects [i]);
				}
			    if (i<=10) {
					List2.Add (mygameObjects [i]);
				}
                   List3.Add (mygameObjects [i]);
			}
			//Debug.Log ("kkkkk.." + mygameObjects+"  "+mygameObjects+"  "+MyConstant.List2.Count+"   "+MyConstant.List1.Count+"   "+MyConstant.List3.Count);
			}
	}
}
