using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {
	public GameObject gun;
	Animator gunShotAnimator;
	// Use this for initialization
	void Start () {
		//gunShotAnimator = gun.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		gun.transform.localEulerAngles = Camera.main.transform.localEulerAngles;
	}

	public void Shot () {
		
	}
}
