using UnityEngine;
using System.Collections;

public class MovementRPG : MonoBehaviour {
	public float hori,verti;
	Animator anim;
	GameObject Player;
	GameObject MCamera; 
	public float RotateSpeed = 20f;
	Vector3 directionPos = Vector3.zero;
	public bool Jog = false; 
	public bool Sprint = false;
	public KeyCode Jog_Toggle = KeyCode.J;
	public KeyCode Sprint_Button = KeyCode.LeftShift;
	public KeyCode Jump_Button;
	public bool Sprint_is_Toggle = false;
	public float jumpforce;
	public GameObject GroundCheckCollider;
	public bool Grounded;

	//InAirControls
	public float InAirMoveSpeed;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		Player = GameObject.FindGameObjectWithTag ("Player");
		MCamera = GameObject.FindGameObjectWithTag ("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		Player.GetComponent<Rigidbody> ().AddTorque (-Player.GetComponent<Rigidbody> ().angularVelocity);
		Grounded = GroundCheckCollider.GetComponent<GroundCheck> ().Grounded;
		hori = Input.GetAxis ("Horizontal");
		verti = Input.GetAxis ("Vertical");

		anim.SetFloat ("Horizontal", hori);
		anim.SetFloat ("Vertical", verti);

		if ((Player.transform.forward != MCamera.transform.forward && Input.GetAxis ("Vertical") != 0f) || (Player.transform.forward != MCamera.transform.forward && Input.GetAxis ("Horizontal") != 0f)) {

			directionPos = transform.position + MCamera.transform.forward * 100;

			Vector3 dir = directionPos - transform.position;
			dir.y = 0;
			Player.transform.rotation = Quaternion.Slerp (Player.transform.rotation, Quaternion.LookRotation (dir), RotateSpeed * Time.deltaTime);

		}
		//Jog
		if (Input.GetKeyDown (Jog_Toggle)) {
			Jog = !Jog;
		
		}
		anim.SetBool ("Jog", Jog);

		//Sprint
		if (Sprint_is_Toggle) {
			if (Input.GetKey (Sprint_Button)) {
				Sprint = !Sprint;

			}
		} else {

			if (Input.GetKeyDown (Sprint_Button)) {
				Sprint = true;
		
			}
			if (Input.GetKeyUp (Sprint_Button)) {
				Sprint = false;
		
			}
		}

		anim.SetBool ("Sprint", Sprint);

		//Jumping
		if (Input.GetKeyDown (Jump_Button)) {
			if (Grounded) {
				Player.GetComponent<Rigidbody> ().AddForce (new Vector3 (0, jumpforce, 0), ForceMode.Impulse);
				Debug.Log ("Jump");
			} 

		
		}

		if (!Grounded) {
			anim.applyRootMotion = false;
			anim.SetBool ("Grounded", false);
		}
		if (Grounded) {
			anim.applyRootMotion = true;
			anim.SetBool ("Grounded", true);
		}
		//in Air Controls
		if (!Grounded) {
			
			Player.GetComponent<Rigidbody> ().AddRelativeForce (new Vector3 (hori, 0f, verti) * InAirMoveSpeed, ForceMode.Force);
			

		}

	}

}
