using UnityEngine;
using System.Collections;

public class FriendlyProjectiles : MonoBehaviour {

	public float speed;
	public float damage;
	
	void OnTriggerEnter2D (Collider2D col) {
		Attacker attacker = col.gameObject.GetComponent<Attacker>();
		Health health = col.gameObject.GetComponent<Health>();
		if (attacker && health) {
			health.DealDamage(damage);
			Destroy (gameObject);
		}
	}
	 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * speed * Time.deltaTime);
	}
}
