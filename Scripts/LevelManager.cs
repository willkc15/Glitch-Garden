using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	public float nextSceneDelay;
	
	void Start () {
		if (Application.loadedLevelName == "0 Splash") {
			Invoke ( "LoadNextLevel", nextSceneDelay);
		}	
	}
	
	public void loadLevel (string name) {
		Application.LoadLevel(name);
	}
	
	public void quitRequest () {
		Debug.Log ("Quit requested");
		Application.Quit();
	}
	public void LoadNextLevel () {
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	
}
