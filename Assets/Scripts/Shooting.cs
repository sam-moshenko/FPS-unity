using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
	public GameObject particlesObject;
	ParticleSystem particleSystem;
	GunController gunController;
	public GameObject shotLightObject;
	Light shotLight;
	public GameObject shotPrintParticlePrefab;
	public int gunDamage = 5;

	public float shotLightIntensity = 8;
	public float shotLightDuration = 0.1f;
	// Use this for initialization
	void Start () {
		particleSystem = particlesObject.GetComponent<ParticleSystem> ();
		particleSystem.playOnAwake = false;
		gunController = GetComponent<GunController> ();
		shotLight = shotLightObject.GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			shotLight.intensity = shotLightIntensity;
			particleSystem.Play ();
			gunController.Shot ();
			//StartCoroutine(
			RaycastHit hit;
			if (Physics.Raycast (Camera.main.transform.position + Camera.main.transform.forward, Camera.main.transform.forward, out hit)) {
				Instantiate (shotPrintParticlePrefab, hit.point, Quaternion.identity);
				HealthController healthController = hit.collider.gameObject.GetComponent<HealthController> ();
				if (healthController != null) {
					healthController.receiveDamage (gunDamage, hit.collider.gameObject.transform.position - transform.position);
				}
			}
		}
		if (shotLight.intensity > 0) {
			shotLight.intensity -= shotLightIntensity * Time.deltaTime / shotLightDuration;
		}
	}
}
