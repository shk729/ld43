using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayAudioManager : MonoBehaviour {
    public AudioSource bgMusicSource;

    public AudioSource swordSound;
    public AudioSource gunSound;
    public AudioSource laserSound;


    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void StartBGMusic()
    {
        bgMusicSource.volume = 0.5f;
        bgMusicSource.Play();
    }

    public void PlaySwordSound()
    {
        swordSound.Play();
    }

    public void PlayGunSound()
    {
        gunSound.PlayOneShot(gunSound.clip);
    }

    public void PlayLaserSound()
    {
        if (!laserSound.isPlaying)
        {
            laserSound.Play();
        }
    }

    public void StopLaserSound()
    {
        laserSound.Stop();
    }
}
