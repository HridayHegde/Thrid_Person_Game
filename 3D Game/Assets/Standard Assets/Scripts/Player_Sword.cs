using UnityEngine;
using System.Collections;

public class Player_Sword : MonoBehaviour {
	public Transform sword, sword_unequiped, sword_equiped;
	public bool Sword_is_Equipped;
	public Animator anim;

	public GameObject EnemyDetector;

	public LayerMask EnemyLayerMask;

	public string aa;

	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			anim.SetTrigger ("Sword_Eq_Uq");
		
		}

		if (Sword_is_Equipped) {
			sword.position = sword_equiped.position;
			sword.rotation = sword_equiped.rotation;
		} else {
			sword.position = sword_unequiped.position;
			sword.rotation = sword_unequiped.rotation;
		
		}

		anim.SetBool ("SwordEquipped", Sword_is_Equipped);

		if (Input.GetMouseButtonDown(0) && Sword_is_Equipped) {
			anim.SetTrigger ("Attack1");

		
		}
		if (Input.GetMouseButtonDown (1) && Sword_is_Equipped) {

			anim.SetTrigger ("Attack2");
		
		}
	}

	public void Sword_Equip()
	{
		Sword_is_Equipped = true;
		
	}

	public void Sword_Unequip()
	{
		Sword_is_Equipped = false;

	}

	public void DisableSwordCollider()
	{
		sword.gameObject.GetComponent<BoxCollider> ().isTrigger = false;
	
	}

	public void EnableSwordCollider()
	{
		sword.gameObject.GetComponent<BoxCollider> ().isTrigger = true;

	}

}
