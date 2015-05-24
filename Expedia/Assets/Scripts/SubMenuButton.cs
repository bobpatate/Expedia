using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SubMenuButton : MonoBehaviour {

	public uint expPoints = 5;
	public string name;
	public double dist;

	public bool canTake = false;
	public float canTakeDist = 0.200f;

	public ExplorationPoint point;

	private GameMaster gameMaster;
	private StatsInterface stats;

	// Use this for initialization
	void Start () {
		GetComponent<Button>().interactable = false;

		gameMaster = GameMaster.instance;
		stats = GameObject.Find("Stats").GetComponent<StatsInterface>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!canTake && dist < canTakeDist){ //Can take
			canTake = true;
			GetComponent<Button>().interactable = true;
		}
		else if(canTake && dist > canTakeDist){ //Can't take
			canTake = false;
			GetComponent<Button>().interactable = false;
		}
	}

	public void setText(string newText, double newText1, bool showDist){
		name = newText;
		transform.FindChild("Text").GetComponent<Text>().text = name;
		if(showDist){
			dist = newText1;
			transform.FindChild("Text1").GetComponent<Text>().text = dist.ToString() + " km";
		}
	}

	public void obtainExp(){
		
	}

	public void click(){
		if(canTake){
			//Add to ignore list
			gameMaster.pointsToIgnore.Add(point);

			//Pop-up and quit interface
			gameMaster.GetComponent<InterfaceLoading>().Button_LoadMenu();

			//Add xp/trophy
			gameMaster.GetComponent<CharacterStats>().AddXp(10);
            GameObject.Find("Popup").GetComponent<PopUp_Script>().StartUp(name, 10);
			stats.addSmallTrophy();
			stats.OnLoad();
		}
	}
}
