using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayAudio : MonoBehaviour {
    public AudioClip gameplayMusic;
    public AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource.clip = gameplayMusic;
        audioSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
