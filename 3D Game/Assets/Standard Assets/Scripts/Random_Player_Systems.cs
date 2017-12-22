using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Random_Player_Systems : MonoBehaviour {

	public bool lockTar;
	public GameObject NearestEnemy;
	public GameObject Player;
	public string NameOfNearestObject;
	public GameObject[] Targets;

	public Testing TrailScript;
	public int TargetInd = 0;
	public Text SpeedShow;
	public Transform tar;

	public float SpeedForSpeedMove;
	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player");
		Targets = GameObject.FindGameObjectsWithTag ("Target");
		TrailScript = GetComponent<Testing> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.V)) {
			NearestEnemy = Player.GetComponent<Nearest_GameObject> ().FindNearest ("Enemy", Player);
			lockTar = !lockTar;
		}
		if (lockTar) {
			if (NearestEnemy != null) {
				NameOfNearestObject = NearestEnemy.name.ToString ();
				//Player.transform.LookAt (new Vector3 (NearestEnemy.transform.position.x, Player.transform.position.y, NearestEnemy.transform.position.z));

				
			}
			if (!NearestEnemy) {

				lockTar = false;
				NearestEnemy = null;

			}
		}
		if (Input.GetKeyDown (KeyCode.O)) {
			if (TargetInd < Targets.Length - 1) {

				TargetInd = TargetInd + 1;
			} else {
				TargetInd = 0;

			}
		}
		if (Input.GetKeyDown (KeyCode.M)) {
			SpeedForSpeedMove++;

		}
		if (Input.GetKeyDown (KeyCode.N)) {
			SpeedForSpeedMove--;

		}






		SpeedShow.text = "SpeedOfTP : " + SpeedForSpeedMove.ToString (); 


		if (Input.GetKeyDown (KeyCode.U)) {
			StartCoroutine( SpeedMove (SpeedForSpeedMove));

		}
			
	}


	IEnumerator SpeedMove(float speed)
	{
		Player.GetComponent<Animator> ().SetTrigger ("Teleport");
		yield return new WaitForSeconds (1.46666f);
		transform.position = Vector3.MoveTowards (transform.position, Targets[TargetInd].transform.position, speed);

	}

}
