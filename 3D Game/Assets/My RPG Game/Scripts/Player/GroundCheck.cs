using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {
	public bool Grounded;
	GameObject Player;
	GameObject ground;
	public LayerMask lm;
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Grounded = Physics.Raycast (new Vector3 (transform.position.x, transform.position.y, transform.position.z), Vector3.down, 0.3f, lm);
		
		
	}

	//void OnTriggerEnter( Collider col)
	//{
		//if (col.gameObject.CompareTag ("Ground")) {
			//ground = col.gameObject;
			//Grounded = true;

		//}


	//}

//	void OnTriggerExit(Collider col)
//	{
//		if(col.gameObject.CompareTag("Ground") && col.gameObject == ground)
//		{
//			Grounded = false;
//
//		}
//	
//	}
}
