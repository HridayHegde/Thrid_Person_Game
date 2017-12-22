using UnityEngine;
using System.Collections;

public class React_System : MonoBehaviour {

	public Animator E_anim;
	public GameManager GameManRef;

	// Use this for initialization
	void Start () {
		GameManRef = GameObject.Find ("GameManager").GetComponent<GameManager>();
		E_anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void HitReact(string AttackName)
	{	
		if (AttackName == "Attack1") {
			StartCoroutine (SyncWait(AttackName, 0.33f));
		
		}

		if (AttackName == "Attack2") {
			StartCoroutine (SyncWait(AttackName, 0.36f));

		}

		if (AttackName == "Kick1") {
			StartCoroutine (SyncWait (AttackName, 0.36f));
		
		
		}


	}

	IEnumerator SyncWait(string AttackName, float waittime)
	{
		if (AttackName == "Attack1") {
			yield return new WaitForSeconds (waittime);
			E_anim.SetTrigger ("React_1");
		}
		if (AttackName == "Attack2") {
			yield return new WaitForSeconds (waittime);
			E_anim.SetTrigger ("React_2");
		}
		if (AttackName == "Kick1") {
			yield return new WaitForSeconds (waittime);
			E_anim.SetTrigger("KickDie");
			GetComponent<NPC_Health>().StartCoroutine("Death",true);
		
		}

	}
}
