using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPC_Health : MonoBehaviour {
	public float E_Health;
	public Image E_HealthBar;
	float tmpHealth;
	public bool CharcterDead;


	// Use this for initialization
	void Start () {
		CharcterDead = false;
	}
	
	// Update is called once per frame
	void Update () {
		tmpHealth = E_Health / 100;

		E_HealthBar.fillAmount = tmpHealth;

		if (!CharcterDead) {
			if (E_Health <= 0) {
				StartCoroutine ("Death",false);
		
			}
		}
	
	}

	public void E_Damage(float damage)
	{
		E_Health = E_Health - damage;
	
	}


	public IEnumerator Death(bool customDeath)
	{
		CharcterDead = true;
		if (!customDeath) {
			gameObject.GetComponent<Animator> ().SetTrigger ("Death");
		
		}

			
		

		yield return new WaitForSeconds (3.9f);
		Destroy (gameObject);

	}
}
