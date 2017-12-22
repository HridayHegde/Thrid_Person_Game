using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_AI : MonoBehaviour {
	public NavMeshAgent navA;
	public Animator anim;
	public Transform Player;
	public bool isDetected = false;
	public Transform[] targets; 
	public bool Patroling = true;
	public int CurrentTarget= 0;

	public bool RandomtargetSystem;

	public bool attacking;

	public string typeOfAI = "Brute";

	public AttackSystem ats;

	//HealthSystem
	public float Health;

	//Attack System
	public float Attackdamage;
	public float NextAttackWaitTime_inSeconds;

	// Ragdoll
	public GameObject[] RagdollParts;


	// Use this for initialization
	void Start () {
		
		if (typeOfAI == "") {
			Debug.Log ("AI Type Not Set Reverting To Default Type : Brute");
			typeOfAI = "Brute";
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (typeOfAI == "Brute") {
			AI_Brute ();
		}
	}

	public void Detected()
	{
		isDetected = true;
	}

	public void Lost()
	{
		isDetected = false;
	
	}


	public void AttackFinished()
	{
		StartCoroutine ("NextAttackWait", NextAttackWaitTime_inSeconds);
	
	}

	void AI_Brute()
	{
		if (Vector3.Distance (transform.position, Player.position) > 2 && Vector3.Distance (transform.position, Player.position) < 10 && isDetected) {
			anim.SetBool ("isPursuing", true);

		} else if (Vector3.Distance (transform.position, Player.position) > 10 && !isDetected) {
			anim.SetBool ("isPursuing", false);

		} else if (Vector3.Distance (transform.position, Player.position) < 2 && isDetected) {
			anim.SetBool ("isPursuing", false);
			if (!attacking) {
				Attack ();
			}
		}

		#region Patrol
		if (!RandomtargetSystem) {
			if (CurrentTarget > targets.Length - 1) {
				CurrentTarget = 0;
				Debug.Log ("Target Number Reset");

			}

			if (isDetected == true) {
				navA.stoppingDistance = 2f;
				navA.SetDestination (Player.position);

			} else {
				navA.stoppingDistance = 0f;
				if (Vector3.Distance (transform.position, targets [CurrentTarget].position) < 1f) {
					CurrentTarget = CurrentTarget + 1;
					Debug.Log ("Target Incremented To : " + CurrentTarget.ToString ());
					if (CurrentTarget <= targets.Length - 1) {
						navA.SetDestination (targets [CurrentTarget].position);
					}
				} else {
					navA.SetDestination (targets [CurrentTarget].position);
				}
				anim.SetBool ("isPursuing", true);
			}

		} else {
			if (isDetected == true) {
				navA.stoppingDistance = 2f;
				navA.SetDestination (Player.position);

			} else {
				navA.stoppingDistance = 0f;
				if (Vector3.Distance (transform.position, targets [CurrentTarget].position) < 1f) {
					CurrentTarget = Random.Range (0, targets.Length); 
					Debug.Log ("Random Target Set To : " + CurrentTarget.ToString ());
					//if (CurrentTarget <= targets.Length - 1) {
					navA.SetDestination (targets [CurrentTarget].position);
					//}
				} else {
					navA.SetDestination (targets [CurrentTarget].position);
				}
				anim.SetBool ("isPursuing", true);
			}

		}

		#endregion

		//navA.velocity = anim.deltaPosition / Time.deltaTime;


	
	}

	void SetInitialRef()
	{
		Player = GameObject.FindGameObjectWithTag ("Player").transform;

	}

	void Attack(){
		
		attacking = true;
		LookAtPlayer ();
		anim.SetTrigger ("Attack");
		ats.AttackDamageSystem (Attackdamage);

	}
	void LookAtPlayer(){
		transform.LookAt (new Vector3 (Player.position.x, transform.position.y, Player.position.z));
	
	}





	//Enumerators
	IEnumerator NextAttackWait(float NextAttackWaitTime){
		yield return new WaitForSeconds (NextAttackWaitTime);
		attacking = false;
	}

}
