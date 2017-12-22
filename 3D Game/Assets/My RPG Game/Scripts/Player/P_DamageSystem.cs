using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_DamageSystem : MonoBehaviour {
	public float Damage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Enemy") {
			col.gameObject.GetComponent<HealthScript> ().Applydamage (Damage);
		}
	}
}
