using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_AttackSystem : MonoBehaviour {
	public MeshCollider SwordCollider;


	void Start(){
		SwordCollider.enabled = false;
	
	}
	public void EnableCollider(){

		SwordCollider.enabled = true;

	}


	public void DisableCollider(){
		
		SwordCollider.enabled = false;
	
	}



	
	

}
