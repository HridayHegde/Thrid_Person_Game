using UnityEngine;
using System.Collections;

public class Nearest_GameObject : MonoBehaviour {

	public GameObject FindNearest(string tag, GameObject SearchOrigin)
	{
		
		 GameObject[] objectLocations;
		float minDist = Mathf.Infinity;
		GameObject closestObject = null;
		objectLocations = GameObject.FindGameObjectsWithTag (tag);

		foreach (GameObject obs in objectLocations) {
			float dist = Vector3.Distance (obs.transform.position, SearchOrigin.transform.position);
			if (dist < minDist) {
				closestObject = obs;
				minDist = dist;
			
			}
		}
		return closestObject;

	}
}
