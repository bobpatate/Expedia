using UnityEngine;
using System.Collections;

public class distance : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		float lat1 = 45.511969f;
		float lon1 = -73.569880f;
		
		float lat2 = 45.5579957f;   //stade
		float lon2 = -73.5518816f;  //stade
		
		float R = 1.609344f;
		float dlon = lon2 - lon1;
		float dlat = lat2 - lat1; 
		float a = Mathf.Pow(Mathf.Sin(dlat / 2), 2) + Mathf.Cos(lat1) * Mathf.Cos(lat2) * Mathf.Pow(Mathf.Sin(dlon / 2),2);
		float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1-a) );
		float d = R * c;
		Debug.Log(d);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
