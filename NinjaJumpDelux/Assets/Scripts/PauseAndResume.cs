using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseAndResume : MonoBehaviour {

	public static bool pause;
	public GameObject paneel;
	//public GameObject FailPanel;
	public  Text countText;
	public GameObject soundplay;
	public GameObject soundmute;

	// Use this for initialization
	void Start () {
		pause = false;	
	}
	
	// Update is called once per frame
	void Update () {
		}

	 public void onPause(){
		if(MyConstant.gamePlay==true){
		pause = !pause;
		if (pause) {
			if (PlayerPrefs.GetInt ("sound") == 1) {
				soundmute.SetActive (false);
				soundplay.SetActive (true);
			} else if (PlayerPrefs.GetInt ("sound") == 2) {
				soundplay.SetActive (false);
				soundmute.SetActive (true);
			}
			Time.timeScale = 0;
			paneel.gameObject.SetActive (true);
			countText.text = Bg_ScrollingController.count.ToString ();
			//Debug.Log ("print value.." + Bg_ScrollingController.count + "  " );
		}
	  }
	}

	public void onResume(){
		pause = false;
		//Debug.Log ("onresume.." + pause + "  " );
		if (!pause) {
			Time.timeScale = 1;
			paneel.gameObject.SetActive(false);
		} 
	}
	public void onExit(){
		//pause = true;
		if (PlayerPrefs.GetInt ("sound") == 1) {
			PlayerPrefs.SetInt ("sound", 2);
			soundmute.SetActive(true);
			soundplay.SetActive(false);
			AudioListener.volume =0;
		}
		else if (PlayerPrefs.GetInt ("sound") == 2) {
			PlayerPrefs.SetInt ("sound", 1);
			soundplay.SetActive(true);
			soundmute.SetActive(false);
			AudioListener.volume =1;
		}
	//	Debug.Log ("onexit.." + pause + "  "+PlayerPrefs.GetInt("sound") );
		Application.Quit(); 

	}
	public void onMainPage(){
		pause = false;
	//	Debug.Log ("onrestart.." + pause + "  " );
		Time.timeScale = 1;
		paneel.gameObject.SetActive(false);
		SceneManager.LoadScene (0); 
	}

	public  void onreplay(){
		//FailPanel.gameObject.SetActive(false);
		//MyConstant.gamePlay = true;
		//SceneManager.LoadScene (1); 
		SceneManager.LoadSceneAsync(1);
		Time.timeScale = 1;
		SceneManager.LoadScene(1);
		//SceneManager.LoadScene (SceneManager.GetActiveScene ()."GamePlay");
	}
}
