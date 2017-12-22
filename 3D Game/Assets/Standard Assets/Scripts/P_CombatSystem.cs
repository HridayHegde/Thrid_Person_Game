using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class P_CombatSystem : MonoBehaviour {
	public GameManager GameMan_Ref;
	public Player_Sword P_Sword;
	bool SwordEquipped;

	public TriggerList DamageTriggersScript;

	public BoxCollider DamageCollider;

	public bool Attack1Active,Attack2Active;

	public AudioSource Hand_R, Hand_L, Leg_R;

	public float handDamage;
	public float legDamage;

	#region ComboSystem
	public float Combo_B1_TimeStamp = 0.0f;
	public float Combo_TimeAllowed = 0.5f;

	#endregion


	// Use this for initialization
	void Awake () {
		GameMan_Ref = GameObject.Find ("GameManager").GetComponent<GameManager>();
		//P_Sword = GameMan_Ref.P_Sword;
		DamageTriggersScript = DamageCollider.gameObject.GetComponent<TriggerList>();
		SwordEquipped = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		#region RefUpdates
		#endregion

		if (Input.GetMouseButtonDown (0) && !GameMan_Ref.P_Sword.Sword_is_Equipped && !Attack1Active && !Attack2Active) {
			//Debug.Log ("Attack");

			Combo_B1_TimeStamp = Time.time;
			GameMan_Ref.Player.GetComponent<Animator> ().SetTrigger ("Attack1");
			Attack1Active = true;
			Damage ("Attack1",handDamage);
			StartCoroutine(DisableBool("Attack1",0.8f));

		
		}
		if (Input.GetMouseButtonDown (1) && !GameMan_Ref.P_Sword.Sword_is_Equipped && !Attack2Active && !Attack1Active) {
			GameMan_Ref.Player.GetComponent<Animator> ().SetTrigger ("Attack2");
			Attack2Active = true;
			Damage ("Attack2", handDamage);
			StartCoroutine (DisableBool ("Attack2", 0.8f));
		}

		if (Input.GetKeyDown (KeyCode.K) && !GameMan_Ref.P_Sword.Sword_is_Equipped && !Attack2Active && !Attack1Active) {
			GameMan_Ref.Player.GetComponent<Animator> ().SetTrigger ("Kick1");
			Damage ("Kick1",legDamage);
		}

		#region ComboSystem_Code
		if(Input.GetMouseButtonDown(1) && (Time.time <= Combo_B1_TimeStamp+ Combo_TimeAllowed))
		{
			Debug.Log("ComboSucess");


		}
		#endregion


	}



	IEnumerator DisableBool(string Attackname,float TimeTowait)
	{
		yield return new WaitForSeconds (TimeTowait);
		if (Attackname == "Attack1") {
			Attack1Active = false;

		}
		if (Attackname == "Attack2") {
			Attack2Active = false;
		
		}

	}

	public void Damage(string AttackName, float damage)
	{
		foreach (Collider a in DamageTriggersScript.ColliderList)
		{
			a.gameObject.GetComponent<React_System> ().HitReact (AttackName);
			a.gameObject.GetComponent<NPC_Health> ().E_Damage (damage);
		}

	}

	public void playPunchSound_Right()
	{
		if (DamageTriggersScript.ColliderList.Count != 0) {
			Hand_R.PlayOneShot (Hand_R.clip);
		}
	}

	public void playPunchSound_Left()
	{
		if (DamageTriggersScript.ColliderList.Count != 0) {
			Hand_L.PlayOneShot (Hand_L.clip);
		}
	}

	public void playKickSound_Right()
	{
		Debug.Log ("BBB");
		//if (DamageTriggersScript.ColliderList.Count != 0) {
			Debug.Log ("AAA");
			Leg_R.PlayOneShot (Leg_R.clip);
		
		//}
	
	}





}
