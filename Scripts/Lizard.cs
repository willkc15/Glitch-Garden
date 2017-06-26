using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class Lizard : MonoBehaviour {
	
	private Animator anim;
	private Attacker attacker;
	
	void OnTriggerEnter2D (Collider2D collider) {
		GameObject gameObj = collider.gameObject;
		if (!gameObj.GetComponent<Defender>()) {
			return;
		}
		else {
			anim.SetBool ("isAttacking", true);
			attacker.Attack(gameObj);
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

