using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

using SimpleJSON;
using System.Text;

public class Exploration : MonoBehaviour {
	internal float radius = 0.5f;
	internal float playerLat = 45.511463f;
	internal float playerLng = -73.570863f;

	public List<ExplorationPoint> points; //List of nearby points

	private string url;

	void Start() {
		Actualize();
	}

	void Actualize(){
		url = "http://terminal2.expedia.com:80/x/geo/features?within="+ radius +"km&lat="+ playerLat +"&lng="+ playerLng +"&type=point_of_interest&apikey=azCQTn91WiTmxxlaKWG63YZk2z1fpXxA";

		WWW www = new WWW(url);
		StartCoroutine(WaitForRequest(www));
	}
	
	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;

		//Create exploration points via request
		if (www.error == null)
		{
			Debug.Log("WWW Ok!: " + www.text);

			var data = JSONNode.Parse(www.text);
			Debug.Log(data[0]["id"]);
			Debug.Log(data[0]["name"]);
			Debug.Log(data[1]["id"]);
			Debug.Log(data[1]["name"]);
		}
		else {
			Debug.Log("WWW Error: "+ www.error);
		}    
	}

	public class Service
	{
		public int idservice { get; set; }
		
		public string title { get; set; }
		
		public string message { get; set; }
	}
	
	public class UserServices
	{
		public int id_user { get; set; }
		
		public List<Service> services { get; set; }
	}
}
