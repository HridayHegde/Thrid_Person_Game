using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour {

	public bool Fly;
	public KeyCode FlyKey;
	Animator anim;
	Rigidbody rigidB;
	float hori,verti;
	public float flightSpeed;
	// Use this for initialization
	void Start () {
		//anim = GetComponent<Animator> ();
		//rigidB = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		//if (Input.GetKeyDown (FlyKey)) {
		//	Fly = !Fly;

		//}

		//if (Fly) {
		//	rigidB.useGravity = !Fly;
		//	rigidB.AddRelativeForce(new Vector3(hori,0f,verti) * flightSpeed,ForceMode.Force);
		//}
		//anim.SetBool ("Fly", Fly);
	}
}
