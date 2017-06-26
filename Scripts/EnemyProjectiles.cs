using UnityEngine;
using System.Collections;

public class EnemyProjectiles : MonoBehaviour {

	public float speed;
	public float damage;

	void OnTriggerEnter2D (Collider2D col) {
		Defender defender = col.gameObject.GetComponent<Defender>();
		Health health = col.gameObject.GetComponent<Health>();
		if (defender && health) {
			health.DealDamage(damage);
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * (-speed) * Time.deltaTime);
	}
}
