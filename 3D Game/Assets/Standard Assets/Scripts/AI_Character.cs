using UnityEngine;
using System.Collections;


namespace UnityStandardAssets.Characters.ThirdPerson
{
	
	public class AI_Character : MonoBehaviour {

		public UnityEngine.AI.NavMeshAgent agent;
		public ThirdPersonCharacter character;




		public enum State{

			PATROL,

			CHASE
		}


		// Use this for initialization

		public State state;
		private bool alive  = true;

		//Variables For Patroling
		public GameObject[] waypoints;
		private int waypointInd = 0;
		public float patrolSpeed = 0.5f;

		//Variables For Chasing
		public float chaseSpeed = 1f;
		public GameObject Target;

		void Awake () {
			agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
			character = GetComponent<ThirdPersonCharacter> ();

			agent.updatePosition = true;
			agent.updateRotation = false;

			state = AI_Character.State.PATROL;

			alive = true;

			StartCoroutine ("FSM");
		
		}

		IEnumerator FSM()
		{
			while (alive) {
				switch (state) {
				case State.PATROL:
					Patrol ();
					break;
				case State.CHASE:
					Chase ();
					break;
				}
				yield return null;
			
			}

		}
		
		void Patrol()
		{
			agent.speed = patrolSpeed;
			if (Vector3.Distance (this.transform.position, waypoints [waypointInd].transform.position) >= 2) {
				if (agent.enabled) {
					agent.SetDestination (waypoints [waypointInd].transform.position);
				}
				
			character.Move (agent.desiredVelocity, false, false);
			
			} else if (Vector3.Distance (this.transform.position, waypoints [waypointInd].transform.position) <= 2) {
				waypointInd += 1;
				if (waypointInd >= waypoints.Length) {
					waypointInd = 0;
				}
			} else {
				character.Move (Vector3.zero, false, false);
			
			}
				

		}

		void Chase(){
			agent.speed = chaseSpeed;
			if (agent.enabled) {
				agent.SetDestination (Target.transform.position);
				character.Move (agent.desiredVelocity, false, false);
			}
		}	
		
		void OnTriggerEnter(Collider coll)
		{
			if (coll.tag == "Player") {
				//state = AI_Character.State.CHASE;
				Debug.Log("PlayerDetected");
				//Target = coll.gameObject;
			}
		
		}



	}
}
