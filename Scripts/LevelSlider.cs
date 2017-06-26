using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSlider : MonoBehaviour {

	[Tooltip ("If increasing make sure max slider value is also changed")]
	public int timeUntilWin;

	private Slider slider;
	private LevelManager levelManager;
	private AudioSource audioSource;
	private bool levelDone = false;

	void LoadNextLevel () {
		levelManager.LoadNextLevel();
	}
	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider>();
		audioSource = GetComponent<AudioSource>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		slider.maxValue = timeUntilWin;
		
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = Time.timeSinceLevelLoad;
		if (slider.value == timeUntilWin && !levelDone) {
			levelDone = true;
			audioSource.Play();
			Invoke ("LoadNextLevel", audio.clip.length);
		}
	}
}
