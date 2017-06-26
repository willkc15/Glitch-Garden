using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;
	
	private AudioSource audioSource;
	
	void OnLevelWasLoaded (int level) {
		AudioClip thisLevelMusic = levelMusicChangeArray[level];
		if (thisLevelMusic) {
			audioSource.volume = PlayerPrefManager.GetMasterVolume();
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			if (audioSource.isPlaying) {
				return;
			}
			audioSource.Play ();
		}
	}
	
	public void ChangeVolume (float volume) {
		audioSource.volume = volume;
	}
	
	void Awake () {
		DontDestroyOnLoad (gameObject);
	}

	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
}
