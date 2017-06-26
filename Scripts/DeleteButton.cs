using UnityEngine;
using System.Collections;

public class DeleteButton : MonoBehaviour {

	public static bool isInDeleteMode;
	private SpriteRenderer spriteRenderer;

	void OnMouseDown () {
		//For toggling delete on and off
		if (!isInDeleteMode) {
			spriteRenderer.color = Color.gray;
			isInDeleteMode = true;
		}
		else {
			spriteRenderer.color = Color.white;
			isInDeleteMode = false;
		}
		
	}

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		isInDeleteMode = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
