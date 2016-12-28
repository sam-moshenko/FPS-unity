using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	public float speed = 2.0f;
	public float lifetime = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		lifetime -= Time.deltaTime;
		if (lifetime <= 0)
			Destroy (gameObject);
		transform.position += transform.forward * speed * Time.deltaTime;
	}
}
