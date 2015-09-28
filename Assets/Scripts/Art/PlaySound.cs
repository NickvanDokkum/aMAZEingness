using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {

    AudioSource audioSource;
    public AudioClip[] audioFiles;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null) {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }
    public void StartPlaySound(uint number) {
        if (number <= audioFiles.Length + 1) {
            //audioSource.clip = audioFiles[number];
            //audioSource.Play();
            audioSource.PlayOneShot(audioFiles[number]);
        }
        else {
            Debug.Log("Error number " + number + " not found");
        }
    }
    public void Mute(bool mute) {
        audioSource.mute = mute;
    }
}
