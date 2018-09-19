using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MoveToNavMesh : MonoBehaviour {

//public Transform goal;
public  Transform[] points;
private int destPoint = 0;
public float minGoBackTimer = 1f;
public float maxGoBackTimer = 5f;
public float distanceLineOfSight = 10f;
float _randomTime = 0;
private Transform _ChaseTarget;
bool _chasingTarget = false;
NavMeshAgent _agent;
RaycastHit hit;
public int minRotateAngle = -45;
public int maxRotateAngle = 45;
Ray lineofSight;

int rotateCounter = 0;
	// Use this for initialization
	void Start () 
	{
		 _agent = GetComponent<NavMeshAgent>();
		lineofSight =  new Ray(transform.position, Vector3.forward);
		 //Hae kaikki child componentit missä on Transform
		 _agent.autoBraking = false;
		 GoPatrol();
	}
	
	void GotNextPoint()
	{
		if(points.Length == 0)
		{
			return;		
		}
		_agent.destination = points[destPoint].position;
		destPoint = (destPoint +1) % points.Length;
	}

	// Update is called once per frame
	void Update () 
	{
		//Jos pelaaja ei ole alueella niin mennään kiertään ympyrää
		if(_chasingTarget == false)
		GoPatrol();	
		else
		//Pelaaja onkin alueella niin lähetään sen perään. 
		FindTarget();
	}

	public void FindTarget()
	{
		if(_ChaseTarget != null)
		{
			_agent.destination = _ChaseTarget.position;
			_chasingTarget = true;
		}
		else
		Debug.Log("_ChaseTarget on NULL");	
	}

	void GoPatrol()
	{
		if(!_agent.pathPending && _agent.remainingDistance < 0.5f)
		GotNextPoint();
	}

	public Transform PlayerIsOnArea(Transform trans)
	{
		_ChaseTarget = trans;
		_ChaseTarget.position = trans.position;
		RaycastPlayer();
		//FindTarget();
		return null;
	}

	public void PlayerIsNotOnAre()
	{
		StartCoroutine(GoBackPatrolTimer());
	}

	IEnumerator GoBackPatrolTimer()
	{
		_randomTime = Random.Range(minGoBackTimer, maxGoBackTimer);
		print("Lähden takaisin"+ _randomTime + "sekunnin päästä");
		yield return new WaitForSeconds(_randomTime);
		_chasingTarget = false;
		print("Lähdin takaisin");
	}

	void RaycastPlayer()
	{
		//Ray lineofSight =  new Ray(transform.position, Vector3.forward);
		lineofSight.direction = Quaternion.Euler(0,rotateCounter,0)*lineofSight.direction;
		if(Physics.Raycast(lineofSight,out hit, Mathf.Infinity))
		{			
			Debug.DrawRay(transform.position, transform.TransformDirection(lineofSight.direction)*hit.distance,Color.yellow);
			if(hit.transform.gameObject.tag == "Player")
			{
				FindTarget();
				StopCoroutine(GoBackPatrolTimer());
				Debug.Log("Pelaaja nähty");
			}
		}
		/*else 
		{
			for (int i= minRotateAngle; i < maxRotateAngle; i++)
			{
				rotateCounter += i; 
			}
		for (int j= maxRotateAngle; j > minRotateAngle; j--)
			{
				rotateCounter -= j; 
			}
		}*/
	}

	void DrawRayCastDebug()
	{

	}
}
