using UnityEngine;
using System.Collections;

public class ShotPrintController : MonoBehaviour {
	ParticleSystem particleSystem;
	// Use this for initialization
	void Start () {
		particleSystem = GetComponent<ParticleSystem> ();
		particleSystem.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!particleSystem.IsAlive ()) {
			Destroy (gameObject);
		}
	}
}
