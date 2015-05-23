using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameMaster : MonoBehaviour {

	//Singleton
	private static GameMaster _instance;
	public static GameMaster instance{
		get{
			if(_instance == null)
				_instance = GameObject.FindObjectOfType<GameMaster>();
			return _instance;
		}
	}


	internal Position playerLocation = new Position("point", 45.511877, -73.570050);

	public List<ExplorationPoint> points = new List<ExplorationPoint>(); //List of nearby points

	// Use this for initialization
	void Start () {
		GetComponent<CharacterStats>().OnStartup();
		GetComponent<InterfaceLoading>().SetCanvaArray();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
