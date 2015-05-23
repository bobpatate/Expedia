﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Geolocalisation : MonoBehaviour
{	
	IEnumerator Start()
	{
		// First, check if user has location service enabled
		if (!Input.location.isEnabledByUser)
			yield break;
		
		// Start service before querying location
		Input.location.Start();
		
		// Wait until service initializes
		int maxWait = 20;
		while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
		{
			yield return new WaitForSeconds(1);
			maxWait--;
		}
		
		// Service didn't initialize in 20 seconds
		if (maxWait < 1)
		{
			print("Timed out");
			yield break;
		}
		
		// Connection has failed
		if (Input.location.status == LocationServiceStatus.Failed)
		{
			print("Unable to determine device location");
			yield break;
		}
		else
		{ 
			Text text = GameObject.Find("Canvas").transform.FindChild("Infos").GetComponent<Text>();
			text.text = "Location: " + Input.location.lastData.latitude + "  " + Input.location.lastData.longitude;
			// Access granted and location value could be retrieved
		}
		
		// Stop service if there is no need to query location updates continuously
		Input.location.Stop();
	}
}