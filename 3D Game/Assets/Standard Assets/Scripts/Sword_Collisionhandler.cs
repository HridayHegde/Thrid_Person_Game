using UnityEngine;
using System.Collections;

public class Sword_Collisionhandler : MonoBehaviour {
	public float damage = 10f;
	public Player_Sword pS_script;
	// Use this for initialization
	void Start () {
		pS_script = GameObject.Find ("Player").GetComponent<Player_Sword> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Enemy") {
			Debug.Log ("Dammage");
			col.gameObject.GetComponent<NPC_Health> ().E_Damage (damage);
		
		}
	}
}
