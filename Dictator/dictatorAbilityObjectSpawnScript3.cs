﻿using UnityEngine;
using System.Collections;

public class dictatorAbilityObjectSpawnScript3 : MonoBehaviour {
	public GameObject abilityObjectFab;
	bool cdTrigger=false;
	public float delay=0;
	public AudioClip click;
	

	public GUISkin TextUI;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		GameObject cooldownDataObject = GameObject.Find("CooldownDataObject");
		CooldownData cdData=cooldownDataObject.GetComponent<CooldownData>();
		
//		if (Input.GetKeyDown ("[6]") & cdData.abilityObjectCooldown<=0 & delay<=0||(Input.GetAxis("LeftJoystickX4")>0&Input.GetButtonDown("A4")&cdData.abilityObjectCooldown<=0&delay<=0))
		if (Input.GetKeyDown ("[6]") & cdData.abilityObjectCooldown<=0 & delay<=0||(Input.GetAxis("RightJoystickX4")>0.75&&cdData.abilityObjectCooldown<=0&delay<=0))  
		{
			SpawnAbilityObjects();
			audio.PlayOneShot(click);
			
			cdTrigger=true;
			delay=2f;	

	
		}

		if(delay>0)
		{
			delay-=Time.deltaTime;
		}
		
		if (cdTrigger & delay<=0)
		{
			cdData.abilityObjectCooldown=15;
			cdTrigger=false;
		}
	}
	
	public void SpawnAbilityObjects()
	{
		GameObject enemyObject = (GameObject)Instantiate(abilityObjectFab, transform.position, Quaternion.identity);
		enemyObject.name = "Ability Object";
	}

	
}