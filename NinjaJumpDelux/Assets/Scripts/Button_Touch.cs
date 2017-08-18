using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Touch : MonoBehaviour {

	public void onClick(){
		// Save game data

		// Close game
		////Debug.Log ("Application Closing");
	//	Application.Quit ();
		SceneManager.LoadScene (1);
	}

	public void onClick1(){
		// Save game data

		// Close game
		////Debug.Log ("Application Closing");
		//	Application.Quit ();
		SceneManager.LoadScene (2);
	}
}
