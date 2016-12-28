using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {
	public GameObject enemyPrefab;
	public int maxEnemyCount = 4;
	public float generationFrequency = 2;
	float lastTimeGenerated = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject[] enemies = GameObject.FindGameObjectsWithTag (enemyPrefab.tag);
		if (enemies.Length < maxEnemyCount && lastTimeGenerated < Time.time - generationFrequency) {
			Instantiate (enemyPrefab, transform.position, enemyPrefab.transform.rotation);
			lastTimeGenerated = Time.time;
		}
	}
}
