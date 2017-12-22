using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player_Movement : MonoBehaviour {
	#region SpecialByME
	public bool bigturnonextendedangle;//Recommended off
	public bool ToggleSlowWalk = true;


	#endregion

	public Transform center_point;
	public Random_Player_Systems rps;

	public bool TarLockRight,TarLockLeft, TarLockFwd, TarLockBck;
	public bool TarLockLoocal;


	public GameObject[] Targets;


	public float rotationSpeed;

	bool forward, back, left, right, Sprint;
	bool slow_walk;
	int AngleToRotate;

	Animator anim;

	public Testing TrailScript;

	public float SpeedForSpeedMove = 5f;
	// Use this for initialization
	void Awake () {
		SetReferences ();


	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown (KeyCode.Space)) {
			anim.SetTrigger ("Jump");
		
		}
		TarLockLoocal = rps.lockTar;


		forward = Input.GetKey (KeyCode.W);
		back = Input.GetKey (KeyCode.S);
		left = Input.GetKey (KeyCode.A);
		right = Input.GetKey (KeyCode.D);

//		if (rps.lockTar) {
//			anim.SetFloat ("Movement", 0f);
//			anim.SetBool ("Sprint", false);
//			if (right) {
//				TarLockRight = true;
//			
//			} else {
//				TarLockRight = false;
//			}
//
//			if (left) {
//				TarLockLeft = true;
//			} else {
//				TarLockLeft = false;
//			
//			}
//			if (forward) {
//				TarLockFwd = true;
//			
//			} else {
//				TarLockFwd = false;
//			}
//			if (back) {
//				TarLockBck = true;
//			} else {
//				TarLockBck = false;
//			
//			}
//		
//
//			anim.SetBool ("TarLock_Right", TarLockRight);
//			anim.SetBool ("TarLock_Left", TarLockLeft);
//			anim.SetBool ("TarLock_Front", TarLockFwd);
//			anim.SetBool ("TarLock_Back", TarLockBck);
		//}
		//anim.SetBool ("TarLock", rps.lockTar);

		if (rps.lockTar) {
			//Region
			anim.SetBool ("TarLock_Right", false);
			anim.SetBool ("TarLock_Left", false);
			anim.SetBool ("TarLock_Front", false);
			anim.SetBool ("TarLock_Back", false);
			//Region end

			if (ToggleSlowWalk) {
				if (Input.GetKeyDown (KeyCode.LeftControl)) {
					slow_walk = !slow_walk;

				}
			}
		#region ByME
		else if (!ToggleSlowWalk) {
				if (Input.GetKey (KeyCode.LeftControl)) {
					slow_walk = true;
				
				} else {
					slow_walk = false;
			
				}

		
			}
			#endregion

			if (Input.GetKey (KeyCode.LeftShift)) {
				Sprint = true;
		
			} else {
				Sprint = false;
			}

			CalculateAngle ();

			anim.SetBool ("Slow_Walk", slow_walk);
			anim.SetBool ("Sprint", Sprint);
			anim.SetFloat ("Movement", Mathf.Max (Mathf.Abs (Input.GetAxis ("Horizontal")), Mathf.Abs (Input.GetAxis ("Vertical"))));

			if (bigturnonextendedangle) {
				anim.SetFloat ("Angle", Mathf.DeltaAngle (transform.eulerAngles.y, center_point.eulerAngles.y + AngleToRotate));
			}
			if (anim.GetCurrentAnimatorStateInfo (0).IsTag ("Turnable")) {
				transform.eulerAngles += new Vector3 (0, Mathf.DeltaAngle (transform.eulerAngles.y, center_point.eulerAngles.y + AngleToRotate) * Time.deltaTime * rotationSpeed, 0);
			}
	
		}
	}

	void CalculateAngle() {
		if (forward && !back) {
			if (left && !right) {
				AngleToRotate = -45;

			} else if (!left && right) {

				AngleToRotate = 45;
			} else {
				AngleToRotate = 0;
			}

		} else if (!forward && back) {
			if (left && !right) {
				AngleToRotate = -135;

			} else if (!left && right) {

				AngleToRotate = 135;
			} else {
				AngleToRotate = 180;
			}

		} else {
			if (left && !right) {
				AngleToRotate = -90;

			} else if (right && !left) {
				AngleToRotate = 90;
			} else
				AngleToRotate = 0;
		}
	
	
	}

	void SetReferences (){
		anim = GetComponent<Animator> ();
		Targets = GameObject.FindGameObjectsWithTag ("Target");
		TrailScript = GetComponent<Testing> ();
		rps = GetComponent<Random_Player_Systems> ();
		slow_walk = true;

	}


}
