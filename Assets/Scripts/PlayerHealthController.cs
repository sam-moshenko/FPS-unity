using UnityEngine;
using System.Collections;

public class PlayerHealthController : HealthController {
	Vector3 hit = Vector3.zero;
	Vector3 hitDisipation = Vector3.zero;
	// Use this for initialization
	override protected void Start () {
		base.Start ();
	}

	override public void receiveDamage(int damage, Vector3 direction) {
		base.receiveDamage (damage, Vector3.zero);
		//player does not have a proper rigidbody so we do the hit movement manually
		hit = getHitVector (direction);
		hitDisipation = hit;
	}
	
	// Update is called once per frame
	override protected void Update () {
		base.Update ();
		if (hit.normalized == hitDisipation.normalized) {
			transform.position += hit;
			hit -= hitDisipation * Time.deltaTime * 4f;
		}
	}
}
