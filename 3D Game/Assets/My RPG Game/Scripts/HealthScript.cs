using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class HealthScript : MonoBehaviour {

	public float Health;
	public Image healthIMG;
	public float TotalHealth;
	public enum Charactertype{ Player, Enemy};
	public GameObject[] ragdollComponents;
	public Animator anim;

	public Charactertype cType;


	public bool Dead = false;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
		healthIMG.fillAmount = Health / TotalHealth;

		if (!Dead) {
			if (Health <= 0f) {
				Dead = true;
				anim.SetBool ("Dead", true);
				if (gameObject.tag == "Enemy") {
					ragdollComponents	= gameObject.GetComponent<Enemy_AI> ().RagdollParts;
					gameObject.GetComponent<NavMeshAgent> ().enabled = false;
					gameObject.GetComponent<Enemy_AI> ().enabled = false;
					gameObject.GetComponent<Collider> ().enabled = false;
			
				}
		
			}
		}
	}

	public void Applydamage(float dmg){

		Health = Health - dmg;
		//if (cType == Charactertype.Player) {
		
		
		//} else if (cType == Charactertype.Enemy) {
			
		
		//} else {
		//	Debug.Log ("Please Set Character Type");
		//}
	}

	public void SetRagdoll(){

		gameObject.GetComponent<Animator> ().enabled = false;
		gameObject.GetComponent<CapsuleCollider> ().enabled = false;
		if (gameObject.tag == "Enemy") {
			foreach (GameObject ragpart in ragdollComponents) {
				ragpart.GetComponent<Collider> ().enabled = true;
				ragpart.GetComponent<Rigidbody> ().isKinematic = false;
			
			}
		} else {
			Debug.Log ("You Managed to kill a Player in a SinglePlayer Game GGWP");
		
		}


		StartCoroutine ("EraseObject");
	
	}

	IEnumerator EraseObject(){
		yield return new WaitForSeconds (3f);
		Destroy (gameObject);
	}
}
