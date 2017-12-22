using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class P_Health_Mana_System : MonoBehaviour {
	public float Health;
	public float Mana;
	float tmphealth, tmpMana;

	public Image HealthBar;
	public Image ManaBar;

	// Use this for initialization
	void Start () {
		HealthBar = GameObject.Find ("HealthBar").GetComponent<Image>();
		ManaBar = GameObject.Find ("ManaBar").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		tmphealth = Health / 100;
		tmpMana = Mana / 100;


		HealthBar.fillAmount = tmphealth;
		ManaBar.fillAmount = tmpMana;
	}

	public void Damage(float damage)
	{
		Health = Health - damage;
	
	}

	public void ReduceMana(float amount)
	{
		Mana = Mana - amount;

	}
}
