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

	public List<ExplorationPoint> points = new List<ExplorationPoint>(); //List of nearby points

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


		if (www.error == null){
			Debug.Log("WWW Ok!: " + www.text);

			//Create and store nearby explorations points
			var data = JSONNode.Parse(www.text);
			for(int i=0; i<data.Count; i++){
				//Debug.Log (data[i]["id"].GetType());
				ExplorationPoint newExpP = new ExplorationPoint((uint)data[i]["id"].AsInt,
				                                                (string)data[i]["type"],
				                                                (string)data[i]["name"],
				                                                (uint)data[i]["source"]["srcId"].AsInt,
				                                                (uint)data[i]["source"]["systemId"].AsInt,
				                                                (string) data[i]["position"]["type"],
				                                                (double)data[i]["position"]["coordinates"][0].AsInt,
				                                                (double)data[i]["position"]["coordinates"][1].AsInt,
				                                                (string)data[i]["status"]);

				points.Add(newExpP);
			}
		}
		else {
			Debug.Log("WWW Error: "+ www.error);
		}    
	}
}
