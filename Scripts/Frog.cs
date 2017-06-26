using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class Frog : MonoBehaviour {

	public GameObject gather;
	public GameObject release;
	
	private GameObject[] objectArray;
	private Animator anim;
	private Attacker attacker;
	private Vector3 padding = new Vector3(0f,0.1f,0f);
	
	void ShouldWeShootProjectile () {
		objectArray = GameObject.FindGameObjectsWithTag ("Defender");
		foreach (GameObject defender in objectArray) {
			if (defender.gameObject.transform.position.y  == gameObject.transform.position.y) {
				if (gameObject.transform.position.x - defender.gameObject.transform.position.x <= 6f) {
					anim.SetBool("isAttacking", true);
					attacker.Attack (defender);
					return;
				}
			}
			attacker.Attack (null);
		}
	}
	
	public void ParticlesExplode () {
		GameObject releaseClone = Instantiate (release, transform.FindChild ("Body").position + padding, Quaternion.identity) as GameObject;
		Destroy (releaseClone, release.particleSystem.duration + 2f);
	}
	
	
	public void StartParticleSystem () {
		GameObject gatherClone = Instantiate (gather, transform.FindChild ("Body").position + padding, Quaternion.identity) as GameObject;
		Destroy (gatherClone, gather.particleSystem.duration + 2f);
	}
	
	void Start () {
		anim = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
		ShouldWeShootProjectile();
	}
}

