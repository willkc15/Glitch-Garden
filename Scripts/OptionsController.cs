using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider;
	public Slider difficultySlider;
	public LevelManager levelManager;
	
	private MusicManager musicManager;
	
	public void SetDefault () {
		volumeSlider.value = 0.025f;
		difficultySlider.value = 1f;
	}
	
	public void SaveAndExit () {
		PlayerPrefManager.SetMasterVolume (volumeSlider.value);
		PlayerPrefManager.SetDifficulty ( difficultySlider.value);
		levelManager.loadLevel ("1a Start");
	}

	// Use this for initialization
	void Start () {
		musicManager = FindObjectOfType<MusicManager>();
		volumeSlider.value = PlayerPrefManager.GetMasterVolume();
		difficultySlider.value = PlayerPrefManager.GetDifficulty();
	}
	
	// Update is called once per frame
	void Update () {
		musicManager.ChangeVolume (volumeSlider.value);
	}
}
