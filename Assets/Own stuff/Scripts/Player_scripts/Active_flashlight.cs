using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active_flashlight : MonoBehaviour {
public bool flashlight = true;
public GameObject lightsource;

 private bool m_isAxisInUse = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		/*if( Input.GetAxisRaw("Fire1") != 0)
		{
			 if(m_isAxisInUse == false)
			 {
				if(flashlight == true)
				{
					DisableFlashlight();
				}
				else
				{
					ActiveFlashlight();
				}
			 }
		}
		if( Input.GetAxisRaw("Fire1") == 0)
		{
			m_isAxisInUse = false;
		}*/
		if(Input.GetButtonDown("Fire2"))
		{
			 if(m_isAxisInUse == false)
			 {
				if(flashlight == true)
				{
					DisableFlashlight();
				}
				else
				{
					ActiveFlashlight();
				}
			}
	
		}
		else
		{
			m_isAxisInUse = false;	
		}
	}

	void ActiveFlashlight()
	{
		lightsource.SetActive(true);
		flashlight = true;
	}

	void DisableFlashlight()
	{
		lightsource.SetActive(false);
		flashlight = false;
	}
}
