using UnityEngine;
using System.Collections;

public class RPGCamera : MonoBehaviour {
	public GameObject Player;
	public Transform Player_cam, center_point, player_camcenter_pos;
	public float distance, max_height, min_height, orbiting_speed, vertical_speed;
	float height;
	Vector3 dest;
	RaycastHit hit;

	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player");

	}

	// Update is called once per frame
	void Update () {
		center_point.transform.position = new Vector3(player_camcenter_pos.transform.position.x, player_camcenter_pos.transform.position.y + 2f, player_camcenter_pos.transform.position.z);
		center_point.eulerAngles += new Vector3 (0, Input.GetAxis ("Mouse X") *orbiting_speed *Time.deltaTime, 0);
		height += Input.GetAxis ("Mouse Y") * Time.deltaTime * vertical_speed;
		height = Mathf.Clamp (height, min_height, max_height);
	}

	void FixedUpdate()
	{
		dest = center_point.position + center_point.forward * -1 * distance + Vector3.up * height; 
		if (Physics.Linecast (center_point.position, dest, out hit)) {
			if (hit.collider.CompareTag ( "Environment") ) {
				Player_cam.position = hit.point + hit.normal * 0.14f; 

			}
		}
		Player_cam.position = Vector3.Lerp (Player_cam.position, dest, Time.deltaTime * 10);
		//Player_cam.position = dest;
		//if (!Player.GetComponent<Random_Player_Systems> ().lockTar) {
		Player_cam.LookAt (center_point);
		//} else {
			//Player_cam.LookAt (Player.GetComponent<Random_Player_Systems> ().NearestEnemy.transform.position);//look at enemy when tarlock

		//}
	}
}
