using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHandling : MonoBehaviour {
	GameObject Player;
	Animator anim;
	public P_AttackSystem pAttackSys;
	//Attack System
	public bool Combo;

	//Sword System
	public	GameObject Sword;
	public Transform Sword_Holder_Back;
	public Transform Sword_Holder_Hand;
	public bool SwordEquipped;
	public KeyCode Equip_Button;
	public float Damage;


	public GameObject[] enemyobjects;
	public 	 GameObject nearestEnemy;
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		anim = GetComponent<Animator> ();
		//pAttackSys = GetComponent<P_AttackSystem> ();
		SwordUnEquip ();
	}
	
	// Update is called once per frame
	void Update () {

		//Attacks
		if (Input.GetMouseButtonDown (0)) {
			Combo = true;
			anim.SetBool ("Combo", Combo);
			LookAtNearestTarget ();
			anim.SetTrigger ("Attack1");

		}	

		if (Input.GetKeyDown (Equip_Button)) {
			if (SwordEquipped) {
				SwordEquipped = false;
				anim.SetBool ("SwordIsInHand", false);

			}else {
				SwordEquipped = true;
			
				anim.SetBool ("SwordIsInHand", true);
			}


		}
	}

	public void ComboTimeEnd()
	{
		Combo = false;
		anim.SetBool ("Combo", Combo);

	}

	void SwordEquip()
	{
		SwordEquipped = true;
		anim.SetTrigger ("Equip_Sword");
		anim.SetBool ("SwordIsInHand", true);

	}

	void SwordUnEquip()
	{
		SwordEquipped = false;
		anim.SetBool ("SwordIsInHand", false);
			

	}

	public void SwordToHand()
	{
		Sword.transform.parent = Sword_Holder_Hand;
		Sword.transform.position = Sword_Holder_Hand.position;
		Sword.transform.rotation = Sword_Holder_Hand.rotation;

	}

	public void SwordToBack()
	{	
		Sword.transform.parent = Sword_Holder_Back;
		Sword.transform.position = Sword_Holder_Back.position;
		Sword.transform.rotation = Sword_Holder_Back.rotation;

	}

	void LookAtNearestTarget(){
		enemyobjects = null;
		if (GameObject.FindGameObjectsWithTag ("Enemy") != null) {
			enemyobjects = GameObject.FindGameObjectsWithTag ("Enemy");
		}
		if (enemyobjects [0] != null) {
			nearestEnemy = enemyobjects [0];
		}

		if (enemyobjects != null) {
			foreach (GameObject eob in enemyobjects) {
				if (Vector3.Distance (Player.transform.position, eob.transform.position) < Vector3.Distance (Player.transform.position, nearestEnemy.transform.position)) {
					if (eob.GetComponent<HealthScript> ().Dead == false) {
						nearestEnemy = eob;
					}
				} else {
					nearestEnemy = nearestEnemy;
			
				}
			
			
			}
		}

		if (nearestEnemy != null) {	
			Player.transform.LookAt (new Vector3 (nearestEnemy.transform.position.x, 0f, nearestEnemy.transform.position.z));
		}
	
	}

}
