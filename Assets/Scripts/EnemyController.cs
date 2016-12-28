using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	NavMeshAgent agent;
	public int damage = 2;
	public float rangeToFindPlayer = 10;
	public float walkRadius = 50;
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		if (player != null) { 
			float sqrMagnitudeToPlayer = (player.transform.position - transform.position).sqrMagnitude;
			if (sqrMagnitudeToPlayer < rangeToFindPlayer * rangeToFindPlayer) {
				agent.destination = player.transform.position;
			} else if (!agent.hasPath) {
				Vector3 randomDirection = Random.insideUnitSphere * walkRadius;
				randomDirection += transform.position;
				NavMeshHit hit;
				NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 1);
				agent.destination = hit.position;
			}
		}
	}

	public void OnCollisionEnter(Collision collision) {
		if (collision.collider.CompareTag ("Player")) {
			GameObject player = collision.collider.gameObject;
			HealthController playerHealth = player.GetComponent<HealthController> ();
			HealthController enemyHealth = GetComponent<HealthController> ();
			playerHealth.receiveDamage (damage, player.transform.position - transform.position);
			enemyHealth.receiveDamage (0, transform.position - player.transform.position);
		}
	}
}
