using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public Player_Movement P_Movement;
	public Player_Sword P_Sword;
	public Camera_Movement Cam_Move;
	public Random_Player_Systems R_P_Systems;
	public P_CombatSystem P_C_System;
	public Testing P_TestSystems;
	public P_Health_Mana_System P_Status;

	public GameObject Player;


	// Use this for initialization
	void Awake () {
		SetReferences ();	
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Quit()
	{
		Application.Quit ();

	}

	void SetReferences()
	{
		Player = GameObject.FindWithTag ("Player");
		P_Movement = Player.GetComponent<Player_Movement> ();
		P_Sword = Player.GetComponent<Player_Sword> ();
		Cam_Move = Player.GetComponent<Camera_Movement> ();
		R_P_Systems = Player.GetComponent<Random_Player_Systems> ();
		P_TestSystems = Player.GetComponent<Testing> ();
		P_Status = Player.GetComponent<P_Health_Mana_System> ();
	}

}
