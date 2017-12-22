using UnityEngine;
using System.Collections;

public class Testing : MonoBehaviour {
	//Mesh m_trail;
	public bool trail;
	public bool gng, Imgng;
	public bool Imtrail;


	public GameObject abc,abc1,abc2;
	public GameObject ForTrail;
	public SkinnedMeshRenderer SMR;
	// Use this for initialization
	void Awake () {
		abc = GameObject.Find ("For_Trail");
		abc1 = GameObject.Find ("For_TRAIL1");
		abc2 = GameObject.Find ("For_TRAIL2");
		ForTrail = GameObject.Find ("Alpha_Surface");
		SMR = ForTrail.GetComponent<SkinnedMeshRenderer> ();

		abc.SetActive (false);
		abc1.SetActive (false);
		abc2.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (trail && !gng) {
			StartCoroutine ("a");

			//abc.GetComponent<MeshFilter> ().mesh = m_trail;
			//Instantiate (m_trail, this.transform.position, this.transform.rotation);
		
		}

		if (Input.GetKeyDown (KeyCode.I)) {
			trail = !trail;
		
		}


	}

	public IEnumerator a()
	{
		gng = true;
		yield return new WaitForSeconds (1f);
		abc.SetActive (true);
		SMR.BakeMesh (abc.GetComponent<MeshFilter> ().mesh);
		yield return new WaitForSeconds (0.5f);
		abc1.SetActive (true);
		SMR.BakeMesh (abc1.GetComponent<MeshFilter> ().mesh);
		yield return new WaitForSeconds (0.5f);
		abc2.SetActive (true);
		SMR.BakeMesh (abc2.GetComponent<MeshFilter> ().mesh);

		yield return new WaitForSeconds (0.5f);
		abc2.SetActive (false);
		yield return new WaitForSeconds (0.5f);
		abc1.SetActive (false);
		yield return new WaitForSeconds (0.01f);
		abc.SetActive (false);
		gng = false;
	}


}
