using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile;
	public GameObject gun;
	
	private GameObject projectileParent;
	private Animator anim;
	private AttackerSpawner laneSpawner;
	private Vector3 cactusPadding = new Vector3 (0f, 0.1f, 0f);
	
	void SetLaneSpawner () {
		AttackerSpawner[] spawnerArray = GameObject.FindObjectsOfType<AttackerSpawner>();
		foreach (AttackerSpawner spawner in spawnerArray) {
			if (spawner.transform.position.y == transform.position.y) {
				laneSpawner = spawner;
				return;
			}
		}
		Debug.LogError ("Can't find spawner in lane");
	}
	
	bool IsAttackerAheadInLane () {
		if (laneSpawner.transform.childCount <= 0) {
			return false;
		}
		foreach (Transform attacker in laneSpawner.transform) {
			if ((attacker.transform.position.x > transform.position.x) && (attacker.transform.position.x <= 10)) {
				return true;
			}
		}
		return false;
	}

	private void Fire () {
		if (gameObject.GetComponent<Gnome>()) {
			GameObject projectileCopy = Instantiate (projectile) as GameObject;
			projectileCopy.transform.parent = projectileParent.transform;
			projectileCopy.transform.position = gun.transform.position;
		}
		if (gameObject.GetComponent<Cactus>()) {
			GameObject projectileCopy1 = Instantiate (projectile) as GameObject;
			GameObject projectileCopy2 = Instantiate (projectile) as GameObject;
			projectileCopy1.transform.parent = projectileParent.transform;
			projectileCopy2.transform.parent = projectileParent.transform;
			projectileCopy1.transform.position = gun.transform.position + cactusPadding;
			projectileCopy2.transform.position = gun.transform.position - cactusPadding;
			
		}
		if (gameObject.GetComponent<Frog>()) {
			GameObject projectileCopy = Instantiate (projectile) as GameObject;
			projectileCopy.transform.parent = projectileParent.transform;
			projectileCopy.transform.position = gun.transform.position;
		}
	}
	
	void Start () {
		anim = GameObject.FindObjectOfType<Animator>();
		projectileParent = GameObject.Find ("Projectiles");
		if (!projectileParent) {
			projectileParent = new GameObject ("Projectiles");
		}
		if (gameObject.GetComponent<Frog>()) {
		return;
		}
		SetLaneSpawner();
	}
	
	void Update () {
		if (gameObject.GetComponent<Frog>()) {
			return;
		}
		if (IsAttackerAheadInLane()) {
			anim.SetBool("isAttacking", true);
		}
		else {
			anim.SetBool("isAttacking", false);
		}
	}
}
