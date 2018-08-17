using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MoveToNavMesh : MonoBehaviour {

public Transform goal;
NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		 agent = GetComponent<NavMeshAgent>();
		 FindTarget();
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(transform.position.x == goal.position.x && transform.position.y == goal.position.y);
			{
				FindTarget();
			}

		/*if(Input.GetButtonDown("Submit"))
		{		
			salli tämä jos haluat itse kontrolloida milloin kohde päättää
			päivittää kohteensa sijainnin.
		}*/

			
	}

	void FindTarget()
	{
		Debug.Log("Päivitetään kohteen sijainti");
		agent.destination = goal.position;
	}
}
