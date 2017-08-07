using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnterSE : MonoBehaviour {

	// Use this for initialization
	
	// Update is called once per frame
	void Start () {
	}

	void Play() {
		AudioSource audio = GetComponent<AudioSource> ();
		if (Input.GetKey (KeyCode.Return)) {
			audio.Play ();
		}
	}

}
