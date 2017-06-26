using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

	[Tooltip ("How often an enemy is spawned")]
	public float seenEverySeconds;
	private float currentSpeed;
	private GameObject currentTarget;
	private Animator anim;
	
	//We set the speed in the animator
	public void SetSpeed (float speed) {
		currentSpeed = speed;
	}
	
	public void Attack (GameObject collidedDefender) {
		currentTarget = collidedDefender;
	}
	
	public void StrikeCurrentTarget (float damage) {
		if (currentTarget) {
			Health health = currentTarget.GetComponent<Health>();
			if (health) {
				health.DealDamage (damage);
			}
		}
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);
		if (!currentTarget) {
				anim.SetBool("isAttacking", false);
		}
	}
}
