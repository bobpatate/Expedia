using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Geolocalisation {
	static internal bool isRunning = true;
	
	static public IEnumerator Start()
	{
		// First, check if user has location service enabled
		if (!Input.location.isEnabledByUser){
			yield break;
		}
		
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
			Debug.Log("Timed out");
			yield break;
		}
		
		// Connection has failed
		if (Input.location.status == LocationServiceStatus.Failed)
		{
			Debug.Log("Unable to determine device location");
			yield break;
		}
		else
		{ 
			// Access granted and location value could be retrieved
			GameMaster.instance.playerLocation = new Position("point", Input.location.lastData.latitude, Input.location.lastData.longitude);
		}
		
		// Stop service if there is no need to query location updates continuously
		isRunning = false;
		Input.location.Stop();
	}
}