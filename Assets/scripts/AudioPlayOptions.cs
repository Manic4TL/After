using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]


public class AudioPlayOptions : MonoBehaviour {

	public void PlayAudio() {
		AudioSource audio = GetComponent<AudioSource>();
		audio.Play();
	}

}
