using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;
	
	private GameObject[] defenderArray;
	private GameObject parent;
	private StarDisplay starDisplay;
	
	void CreateDefender (GameObject selectedDefender) {
		GameObject createdDefender = Instantiate (selectedDefender, SnapToGrid (CalculateWorldPointOfMouseClick()), Quaternion.identity) as GameObject;
		createdDefender.transform.parent = parent.transform;
	}

	void OnMouseDown () {
		//wrapping if statement make sure we cant place defenders while in delete mode
		if (DeleteButton.isInDeleteMode == false) {
			Vector3 newVector = SnapToGrid (CalculateWorldPointOfMouseClick());
			foreach (GameObject defender in defenderArray) {
				if (defender.transform.position == newVector) {
					return;
				}
			}
			GameObject selectedDefender = Button.selectedDefender;
			int defenderCost = selectedDefender.GetComponent<Defender>().starCost;
			if (starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS) {
				CreateDefender(selectedDefender);
			}
			else {
				Debug.Log ("Insufficient funds to spawn");
			}
		}
	}
	
	Vector3 SnapToGrid (Vector3 rawWorldPosition) {
		int newX = Mathf.RoundToInt(rawWorldPosition.x);
		int newY = Mathf.RoundToInt (rawWorldPosition.y);
		return new Vector3 (newX,newY, 0f);
	}
	
	Vector3 CalculateWorldPointOfMouseClick () {
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f; //this is arbitrary
		Vector3 weirdTriplet = new Vector3 (mouseX, mouseY, distanceFromCamera);
		Vector3 worldPos = myCamera.ScreenToWorldPoint (weirdTriplet);
		return worldPos;
	}
	
	void Start () {
		//Just creates parent for organization of newly added defenders
		parent = GameObject.Find ("Defenders");
		if (!parent) {
			parent = new GameObject ("Defenders");
		}
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
	}
	
	void Update () {
		defenderArray = GameObject.FindGameObjectsWithTag("Defender");
	}
}
