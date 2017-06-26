using UnityEngine;
using System.Collections;

public class AttackerSpawner : MonoBehaviour {

	public GameObject[] attackerArray;
	
	bool IsTimeToSpawn (GameObject attacker) {
		Attacker shweemer = attacker.GetComponent<Attacker>();
		float spawnDelay = shweemer.seenEverySeconds;
		float spawnsPerSecond = 1/ spawnDelay;
		float threshold = spawnsPerSecond * Time.deltaTime / 5;
		if (Random.value < threshold) {
			return true;
		}
		return false;
	}
	
	void Spawn (GameObject attacker) {
		GameObject thisAttacker = Instantiate (attacker) as GameObject;
		thisAttacker.transform.parent = transform;
		thisAttacker.transform.position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject attacker in attackerArray) {
			if (IsTimeToSpawn (attacker)) {
				Spawn (attacker);
			}
		}
	}
}
