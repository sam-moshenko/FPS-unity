using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour {
	public int health = 10;
	public float hitMultiplier = 10;
	// Use this for initialization
	virtual protected void Start () {
		
	}

	virtual public void receiveDamage(int damage, Vector3 direction) {
		health -= damage;
		if (health <= 0) {
			Destroy (gameObject);
		}

		Rigidbody rigidBody = GetComponent<Rigidbody> ();
		if (rigidBody) {
			Debug.Log (getHitVector (direction));
			rigidBody.AddForce (getHitVector(direction));
		}
	}

	virtual public Vector3 getHitVector(Vector3 direction) {
		return (new Vector3(direction.x, 0, direction.y)).normalized * hitMultiplier;
	}
	
	// Update is called once per frame
	virtual protected void Update () {
	
	}
}
