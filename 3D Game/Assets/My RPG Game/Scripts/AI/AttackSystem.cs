using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackSystem : MonoBehaviour {
	public	List<GameObject> ObjectsIndamageRadius = new List<GameObject>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter( Collider col){
		if (!ObjectsIndamageRadius.Contains (col.gameObject)) {
			ObjectsIndamageRadius.Add (col.gameObject);
		}
	}

	void OnTriggerExit(Collider col){
		if (ObjectsIndamageRadius.Contains (col.gameObject)) {
			ObjectsIndamageRadius.Remove (col.gameObject);
		}
	}


	public void AttackDamageSystem(float dmg){
		foreach (GameObject go in ObjectsIndamageRadius) {
			if (go.GetComponent<HealthScript> () != null) {
				if (go.tag == "Player") {
					go.GetComponent<HealthScript> ().Applydamage (dmg);
				}
				if (go.tag == "Enemy") {
					go.GetComponent<HealthScript> ().Applydamage (dmg/2f);
				}
			}
		
		}
	
	}
}
