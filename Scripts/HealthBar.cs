using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	public float enemiesToLose;

	private Image image;
	
	void UpdateHealth () {
		float enemyCount = LoseCollider.enemyCount;
		image.fillAmount = 1f - (enemyCount / enemiesToLose);
	}

	// Use this for initialization
	void Start () {
		image =GetComponent<Image>();
		image.fillAmount = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		UpdateHealth();
	}
}
