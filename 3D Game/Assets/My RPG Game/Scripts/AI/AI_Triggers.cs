using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Triggers : MonoBehaviour {
	public string Triggername;
	public Enemy_AI enai;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider sc)
	{
		if (sc.gameObject.CompareTag ("Player")) {
			if (Triggername == "Detect") {
				enai.Detected ();
		
			} 
		}

	}
	void OnTriggerExit(Collider sc){
		if (Triggername == "Lost") {
			if (sc.gameObject.CompareTag ("Player")) {
				enai.Lost ();
		
			}
		}
	
	}
}
