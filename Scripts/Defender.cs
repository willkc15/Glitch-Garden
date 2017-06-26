using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {

	public int starCost;

	private StarDisplay starDisplay;
	
	void OnMouseDown() {
		if (DeleteButton.isInDeleteMode == false) {
			return;
		}
		else {
			Destroy (gameObject);
		}
	}

	public void AddStars (int amount) {
		starDisplay.AddStars(amount);
	}
	
	void Start () {
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
	}
}
