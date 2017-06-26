using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent (typeof (Text))]
public class StarDisplay : MonoBehaviour {

	public enum Status {SUCCESS, FAILURE};

	private Text starText;
	private int totalStars = 0;
	
	void StarsPerSecond () {
		totalStars += 5;
		UpdateDisplay();
	}
	
	void UpdateDisplay () {
		starText.text = totalStars.ToString();
	}
	
	public Status UseStars (int amount) {
		if (totalStars >= amount) {
			totalStars = totalStars - amount;
			UpdateDisplay();
			return Status.SUCCESS;
		}
		return Status.FAILURE;
	}

	public void AddStars (int amount) {
		totalStars = totalStars + amount;
		UpdateDisplay();
	}
	
	void Start () {
		starText = GetComponent<Text>();
		InvokeRepeating ("StarsPerSecond", 2f, 2f);
	}
}
