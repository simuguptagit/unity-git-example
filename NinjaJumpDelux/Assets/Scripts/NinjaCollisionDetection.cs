using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NinjaCollisionDetection : MonoBehaviour {
	private float speed;
	private float powspeed;
	public static Animator anim;
	private Vector3 position;
	private bool change;
	private static bool TouchDown;
	public GameObject colisiongameObject;
	public GameObject animpower;
	public static bool PowerMode;


	//public Transform particle ; 
	//public Transform starpowerparticle ; 
	//public Transform hutdestroyparticle ; 
	//public Transform streetlightdestroyparticle ;

	//public GameObject FailPanel;
	//public  Text height;
	//public  Text BestHeight;
	// Use this for initialization
	void Start () {
	 
		MyConstant.getlevel1 (MyConstant.Level1);
		speed = MyConstant.modelmovingspeed;
		powspeed = speed - 2;
		change = false;
		TouchDown = false;
		PowerMode = false;
		anim = GetComponent<Animator>();
		position = transform.position;
		anim.speed = .8f;
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("trigger11111.."+TouchDown+"  "+MyConstant.bird_point+"  "+other.gameObject.name+"  "+anim.GetBool("isJump")+"  "+MyConstant.gamePlay+"  "+PowerMode);

		if (anim.GetBool ("isJump") == true && other.gameObject.name.Equals ("Bird_Sprite_02_0") == true) {
			MyConstant.powerMode2 = 2;

			other.GetComponent<Animator> ().SetBool ("flyDestroy", true);
			other.GetComponent<Animator> ().transform.localScale = new Vector3 (2f, 2f, 1f);
			other.GetComponent<Collider2D> ().enabled = false;
		} 
		else if (anim.GetBool ("isJump") == true && other.gameObject.name.Equals ("Stone") == true) {
		//	particle.GetComponent<ParticleSystem> ().gameObject.transform.position = other.gameObject.transform.position;
		//	particle.GetComponent<ParticleSystem> ().gameObject.SetActive(true);	
		//	particle.GetComponent<ParticleSystem> ().Play();
			MyConstant.powerMode2 = 2;
			Destroy (other.gameObject);
		}
		else if (MyConstant.gamePlay) {
			if (other.gameObject.name.Equals ("Sprite_03_0") == false && PowerMode == false) {Debug.Log("collision111");
				

				MyConstant.gamePlay = false;
				MyConstant.falling = false;
				MyConstant.fall = 0;

				SoundManagerScript.jump.Stop ();
				SoundManagerScript.jump.clip = SoundManagerScript.sound [0];
				SoundManagerScript.jump.Play ();

				StartCoroutine (Falling_Failed ());

			} else if (PowerMode == true ) {Debug.Log("collision2222");
				
				if (PowerMode == true && other.gameObject.name.Equals ("Sprite_03_0") == true) starpower (other.gameObject);
				else if ( MyConstant.gamePlay == true && PowerMode == true) {
					starpower (other.gameObject);
					PowerMode = false;
					//other.GetComponent<Collider2D> ().enabled  = false;
				}
			}
			else {//Debug.Log("collision33333");
				Destroy (other.gameObject);
				starpower (other.gameObject);
				PowerMode = true;
			}
		}
	}
	public void starpower( GameObject other){
		if (other.gameObject.name.Equals ("Hut-Sprite_02_0") == true) {
			//hutdestroyparticle.GetComponent<ParticleSystem> ().gameObject.transform.position = other.gameObject.transform.position;
			//hutdestroyparticle.GetComponent<ParticleSystem> ().gameObject.SetActive (true);	
			//hutdestroyparticle.GetComponent<ParticleSystem> ().Play ();
		} else if (other.gameObject.name.Equals ("Sprite_03_0") == true) {
			//starpowerparticle.GetComponent<ParticleSystem> ().gameObject.transform.position = other.gameObject.transform.position;
		//	starpowerparticle.GetComponent<ParticleSystem> ().gameObject.SetActive (true);	
			//starpowerparticle.GetComponent<ParticleSystem> ().Play ();
		} else if (other.gameObject.name.Equals ("Street-Lyt-sprite-sheet_0") == true) {
			//streetlightdestroyparticle.GetComponent<ParticleSystem> ().gameObject.transform.position = other.gameObject.transform.position;
			//streetlightdestroyparticle.GetComponent<ParticleSystem> ().gameObject.SetActive (true);	
			//streetlightdestroyparticle.GetComponent<ParticleSystem> ().Play ();
		}
		else {other.GetComponent<Collider2D> ().enabled  = false;
		}
		Destroy (other.gameObject);
	}

	void OnTriggerExit2D(Collider2D other){
	}

	IEnumerator Falling_Failed(){
		yield return new WaitForSeconds(1.5f);
		MyConstant.falling = true;
		yield return new WaitForSeconds(.01f);
		Time.timeScale = 0;
		//height.text = Bg_ScrollingController.count.ToString();
		//if( PlayerPrefs.GetInt ("bestHeight")< Bg_ScrollingController.count)  PlayerPrefs.SetInt ("bestHeight", Bg_ScrollingController.count);
		//BestHeight.text = PlayerPrefs.GetInt ("bestHeight").ToString ();
	//	FailPanel.gameObject.SetActive(true);
	}

	// Update is called once per frame
	void Update () {
		//Debug.Log("printt.."+PowerMode+"  "+ animpower.transform.position+"  "+anim.transform.position+"  "+change );
		if (PowerMode == false && animpower.activeSelf == true) {//Debug.Log("....."+PowerMode+"  "+ animpower.activeSelf );
			animpower.SetActive (false);
		}else if(PowerMode == true && animpower.activeSelf == false){
			animpower.SetActive (true);
		}
			
		
		if (MyConstant.gamePlay == false) {
			Falling_Position ();
			}

		if (TouchDown && MyConstant.gamePlay) {
			NinjaTouchAnimation ();
		}
		if ( TouchDown==false && Input.GetMouseButtonDown (0) && MyConstant.gamePlay) {
			NinjaTouchDown ();
		}
		if (Input.GetKeyDown(KeyCode.Escape)) 
			Application.Quit(); 
	}

	void NinjaTouchDown(){
		TouchDown= true;
		//	Debug.Log ("yahnnnnmmm..." + change);
		if(Generate.Stage == 2){ speed +=.5f;
			powspeed = speed;}
		if (Generate.Stage == 3) {
			speed += 1;powspeed = speed;
		}

		if (change == false) {
			transform.position = new Vector3 (-2.4f, -2.76f, 52.4f);
		} else if (change == true) {
			transform.position = new Vector3 (2.3f, -2.76f, 52.4f);
		}
		transform.rotation = Quaternion.Euler (new Vector3 (0, 180, 0));

		anim.SetBool ("isJump" ,true);

		SoundManagerScript.jump.Play ();
	}

	void NinjaTouchAnimation(){
		
		Vector3 movement = new Vector3 (1, 0, 0);
		Vector3 movement1 = new Vector3 (0, 1, 0);
		//Debug.Log ("pri44nti.."+TouchDown+"  "+Vector3.Distance (transform.position, position)+"  "+change+"  "+transform.position);
		if (change==false && Vector3.Distance (transform.position, position) <= 4.5f) {
			transform.Translate (movement * -speed * Time.deltaTime);
			animpower.transform.Translate (movement * powspeed * Time.deltaTime);
			colisiongameObject.transform.Translate (movement * (powspeed-.5f)* Time.deltaTime);
		} else if (change==true && /*Vector3.Distance (transform.position, position) >= .78*/ transform.position.x>=-1.9) {
			transform.Translate (movement * speed * Time.deltaTime); 
			animpower.transform.Translate (movement * -powspeed * Time.deltaTime);
			colisiongameObject.transform.Translate (movement * -(powspeed-.5f) * Time.deltaTime);
		}
		else {//Debug.Log("cccccccc........");
			TouchDown = false;

			//SoundManagerScript.jump.Stop ();

			if(change==false){
				change = true;
				anim.transform.position = new Vector3 (2.3f, -2.75f, 52.4f);
				animpower.transform.position = new Vector3 (1.7f,-2.2f,52f);
				colisiongameObject.transform.position = new Vector3 (1.8f,-2.3f,52.4f);
				transform.rotation = Quaternion.Euler (new Vector3 (-88.8620f, -1.277f, 91.2780f));
			}
			else if(change==true){
				change = false;
				anim.transform.position = new Vector3 (-2.4f, -2.75f, 52.4f);
				animpower.transform.position = new Vector3 (-1.8f,-2.2f,52f);
				colisiongameObject.transform.position = new Vector3 (-1.85f,-2.3f,52.4f);
				transform.rotation = Quaternion.Euler (new Vector3 (-87.291f, -74.215f, -15.768f));
			}
			anim.SetBool ("isJump" ,false);
		}
	}

	void Falling_Position(){

		if (change == false) {
			transform.rotation = Quaternion.Euler (new Vector3 (0, -74.215f, -15.768f));
			anim.SetBool ("isFalling", true);
			Vector3 v = anim.transform.position;

			if (MyConstant.falling == true) {//Debug.Log("......111111");
				v.y -= .08f;
			}
			else if (v.x <= -.4f) {//Debug.Log(".....222222");
				v.x += .06f;
				v.y -= .08f;
				MyConstant.fall++;
			} /*else if (v.x >= .45f) {Debug.Log(".....333333");
				v.x -= .06f;
				v.y -= .08f;
				MyConstant.fall++;
			} */else if(MyConstant.fall >= -2 &&MyConstant.fall <= 0 ){//Debug.Log(".......4444");
				v.y -=.8f;
				MyConstant.fall -= 1;
 			}

			transform.position = v;
		} else if (change == true) {
			transform.rotation = Quaternion.Euler (new Vector3 (0, 85.90701f, 0));
			anim.SetBool ("isFalling", true);
			Vector3 v = anim.transform.position;

			if (MyConstant.falling == true) v.y -= .08f;
			else if (v.x >= .45f) {
				v.x -= .08f;
				v.y -= .08f;
				MyConstant.fall++;
			} /*else if (v.x <= -.4f) {
				v.x += .06f;
				v.y -= .08f;
				MyConstant.fall++;
			}*/
			else if(MyConstant.fall >= -2 &&MyConstant.fall <= 0){
				v.y -=.8f;
				MyConstant.fall -= 1;
			}
			transform.position = v;
		}
	}
}
