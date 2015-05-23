using UnityEngine;
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
	 /*
	public void distance()//float lat1, float lon1, float lat2, float lon2)
	{
		Debug.Log ("Dick");
		float lat1 = 45.511969f;
		float lon1 = -73.569880f;
		
		float lat2 = 45.5579957f;   //stade
		float lon2 = -73.5518816f;  //stade

		float R = 1.609344f;
		float dlon = lon2 - lon1;
		float dlat = lat2 - lat1; 
		float a = Mathf.Pow(Mathf.Sin(dlat / 2), 2)+ Mathf.Cos(lat1) * Mathf.Cos(lat2) * Mathf.Pow(Mathf.Sin(dlon / 2),2);
		float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1-a) );
		float d = R * c;
		Debug.Log(d);
	} */
}