using UnityEngine;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameMaster : MonoBehaviour {
	#if UNITY_EDITOR
	//A utiliser si le build est stuck dans une résolutiuon
	[MenuItem("Edit/Reset Playerprefs")] public static void DeletePlayerPrefs() { PlayerPrefs.DeleteAll(); }
	#endif
	
	//Singleton
	private static GameMaster _instance;
	public static GameMaster instance{
		get{
			if(_instance == null)
				_instance = GameObject.FindObjectOfType<GameMaster>();
			return _instance;
		}
	}


	internal Position playerLocation;

	public List<ExplorationPoint> points = new List<ExplorationPoint>(); //List of nearby points
	public List<ExplorationPoint> pointsToIgnore = new List<ExplorationPoint>(); //List of nearby points

	// Use this for initialization
	void Start () {
		if (Application.isEditor)
		{
			playerLocation = new Position("point", 45.511877, -73.570050);
		}

		GetComponent<CharacterStats>().OnStartup();
		GetComponent<InterfaceLoading>().SetCanvaArray();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
