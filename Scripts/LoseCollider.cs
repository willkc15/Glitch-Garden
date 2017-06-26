using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	public static float enemyCount;
	
	private LevelManager levelManager;
	private HealthBar healthBar;

	void OnTriggerEnter2D (Collider2D col) {
		enemyCount++;
		if (enemyCount >= healthBar.enemiesToLose) {
			levelManager.loadLevel ("3a Lose");
		}
	}
	
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		healthBar = GameObject.FindObjectOfType<HealthBar>();
		enemyCount = 0;
	}
}
