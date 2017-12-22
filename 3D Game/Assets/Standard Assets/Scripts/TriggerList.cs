using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TriggerList : MonoBehaviour {

	public List<Collider> ColliderList;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		

	
	}

	void LateUpdate()
	{
		for (int i = 0; i < ColliderList.Count; i++) {
			
			if (ColliderList[i].gameObject.GetComponent<NPC_Health> ().CharcterDead) {
				ColliderList.Remove (ColliderList[i]);

			}
		
		}


	}


	void OnTriggerEnter(Collider col)
	{	
		if (!ColliderList.Contains (col) && col.tag == "Enemy" && !col.isTrigger) {
			ColliderList.Add (col);
		}
			

	}

	void OnTriggerExit(Collider col)
	{
		if (ColliderList.Contains (col) && col.tag == "Enemy" && !col.isTrigger) {
			ColliderList.Remove (col);
		}

	}
}
