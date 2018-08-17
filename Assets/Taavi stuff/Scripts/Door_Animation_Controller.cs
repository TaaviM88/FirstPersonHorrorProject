using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Animation_Controller : MonoBehaviour {

public bool doorIsOpen = false;
public int _doorIsClosedAngle = 0;
public  int _doorIsOpenAngle = 90;
bool _isPlayerNear = false;

	// Use this for initialization
	void Awake () 
	{
		if(doorIsOpen == false)
		{
			transform.rotation = Quaternion.Euler(transform.rotation.x,_doorIsClosedAngle, transform.rotation.z);
		}
		else if (doorIsOpen == true)
		{
			transform.rotation = Quaternion.Euler(transform.rotation.x,_doorIsOpenAngle, transform.rotation.z);
		}
			
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(_isPlayerNear == true)
		{
			if(doorIsOpen == false)
			{
				if(Input.GetButtonDown("Fire1"))
				{
					OpenDoor();
				}		
			}

			else if (doorIsOpen == true)
			{
				if(Input.GetButtonDown("Fire1"))
				{		
					CloseDoor();
				}
			}
		}
	}

	void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player")
		{
			_isPlayerNear = true;
			Debug.Log("Player is near the door");
		}
		
    }
	void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player")
		{
			_isPlayerNear = false;
			Debug.Log("Player is not near the door");
		}
    }
	public void OpenDoor()
	{
	
		for(int i = _doorIsClosedAngle; i <= _doorIsOpenAngle; i++)
		{		
			transform.rotation = Quaternion.Euler(transform.rotation.x,  i, transform.rotation.z);
			
			if(i <= _doorIsOpenAngle)
			{
				doorIsOpen =true;
			}
		}
	}

	public void CloseDoor()
	{	
		for(int i = _doorIsOpenAngle; i >= _doorIsClosedAngle; i--)
		{
			transform.rotation = Quaternion.Euler(transform.rotation.x, i, transform.rotation.z);
			if(i <= _doorIsClosedAngle)
			{
				doorIsOpen = false;
			}
		}				
	}
}
