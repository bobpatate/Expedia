﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

using SimpleJSON;
using System.Text;

public class Exploration : MonoBehaviour {
	internal float radius = 0.5f;
	private List<ExplorationPoint> points = new List<ExplorationPoint>(); //List of nearby points

	private string url;

	public void Actualize(){
		radius = GameObject.Find("GameMaster").GetComponent<CharacterStats>().GetViewRange() * 0.001f;
		
		StartCoroutine(Geolocalisation.Start());
		if(!Geolocalisation.isRunning){
			url = "http://terminal2.expedia.com:80/x/geo/features?within="+ radius +"km&lat="+ GameMaster.instance.playerLocation.coordinates[0] +"&lng="+ GameMaster.instance.playerLocation.coordinates[1] +"&type=point_of_interest&apikey=azCQTn91WiTmxxlaKWG63YZk2z1fpXxA";

			WWW www = new WWW(url);
			StartCoroutine(WaitForRequest(www));
		}
	}
	
	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;


		if (www.error == null){
			//Debug.Log("WWW Ok!: " + www.text);

			//Empty list

			points.RemoveAll(isExplorationPoint);

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
				                                                data[i]["position"]["coordinates"][1].AsDouble,
				                                                data[i]["position"]["coordinates"][0].AsDouble,
				                                                (string)data[i]["status"]);
				points.Add(newExpP);
			}

			//Sort points by distance
			points.Sort(CompareListBy);

			//Record in GameMaster
			GameMaster.instance.points = points;

			//Generate UI
			GameObject.Find("Exploration").GetComponent<ScrollBarInterface>().GenerateButtons();
		}
		else {
			Debug.Log("WWW Error: "+ www.error);
		}    
	}

	private static int CompareListBy(ExplorationPoint expP1, ExplorationPoint expP2)
	{
		return expP1.distance.CompareTo(expP2.distance); 
	}

	private static bool isExplorationPoint(ExplorationPoint exp)
	{
		return true;
	}

}
