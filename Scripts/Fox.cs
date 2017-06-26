using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class Fox : MonoBehaviour {

	private Animator anim;
	private Attacker attacker;
	private int jumpCounter;

	void OnTriggerEnter2D (Collider2D col) {
		GameObject collidedDefender = col.gameObject;
		if (!collidedDefender.GetComponent<Defender>()) {
			return;
		}
		if (collidedDefender.GetComponent<GraveStone>() && jumpCounter == 0) {
			anim.SetTrigger ("jumpTrigger");
			jumpCounter++;
		}
		else {
			anim.SetBool ("isAttacking", true);
			attacker.Attack(collidedDefender);
		}
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
