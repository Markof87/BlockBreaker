﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance = null;

	// Use this for initialization
	void Awake () {

		//Singleton pattern
		if (instance != null) {

			Destroy (gameObject);
			print ("Duplicate music player self-destructing");

		} else {

			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);

		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
