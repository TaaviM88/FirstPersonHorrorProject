using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAreTrigger : MonoBehaviour {
	//public GameObject child;
	private Transform playerTransform;
	MoveToNavMesh _navmeshScript;
	public bool patrolTriggerAreIsTrue = true;
	// Use this for initialization
	void Start ()
	 {
		//_navmeshScript = FindObjectOfType<MoveToNavMesh>();
		if(patrolTriggerAreIsTrue == true)
		{
			_navmeshScript = GetComponent<MoveToNavMesh>();
		}

		if(_navmeshScript == null )
		{
			_navmeshScript = GetComponentInChildren<MoveToNavMesh>();
			if(_navmeshScript == null)
			{
				Debug.Log("FUCK YOU!");
			}
		}
		
	}

	void OnTriggerStay(Collider other) 
	{
        if(other.gameObject.tag == "Player")
		{
			_navmeshScript.PlayerIsOnArea(other.transform);
		}
    }

	void OnTriggerExit(Collider other) 
	{
        if(other.gameObject.tag == "Player")
		{
			_navmeshScript.PlayerIsNotOnAre();
		}  
    }
}
