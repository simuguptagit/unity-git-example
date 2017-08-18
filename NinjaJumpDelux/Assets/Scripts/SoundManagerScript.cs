using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour {

	public static AudioClip[] sound;
	public static AudioSource fail;
	public static AudioSource jump;
	// Use this for initialization
	void Start () {
		/*..........................sound................*/
		sound = Resources.LoadAll<AudioClip>("Music");
		AudioSource newAudio =  gameObject.GetComponent<AudioSource> ();
		fail = AddAudioSource (newAudio,sound[0], true , true, 1f);
		AudioSource newAudio1 =  gameObject.GetComponent<AudioSource> ();
		jump = AddAudioSource (newAudio1,sound[1], false , true, 1f);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static AudioSource AddAudioSource (AudioSource newAudio,AudioClip clip , bool loop, bool awake , float vol){
		newAudio.clip = clip;
		newAudio.loop = loop;
		newAudio.playOnAwake = awake;
		newAudio.volume = vol;
		return newAudio;
	}
}
