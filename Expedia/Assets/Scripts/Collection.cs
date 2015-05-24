using UnityEngine;
using System.Collections;

public class Collection : MonoBehaviour {
	private int smalltrophy = 0;
	private int largetrophy = 0;


	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		int smalltrophy = PlayerPrefs.GetInt("STrophy");
		int largetrophy = PlayerPrefs.GetInt("LTrophy");
		//TODO faire afficher les données dans textbox
	}

	public void addSmallTrophy()
	{
		smalltrophy++;
		PlayerPrefs.SetInt("STrophy", smalltrophy);
	}

	public void addLargeTrophy()
	{
		largetrophy++;
		PlayerPrefs.SetInt("LTrophy", largetrophy);
	}


}
