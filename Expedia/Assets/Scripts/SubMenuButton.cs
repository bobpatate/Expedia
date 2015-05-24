using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SubMenuButton : MonoBehaviour {

	public uint expPoints = 5;
	public string name;
	public double dist;

	public bool canTake = false;
	public float canTakeDist = 0.195f;

	// Use this for initialization
	void Start () {
		GetComponent<Button>().interactable = false;
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

	public void setText(string newText, double newText1){
		name = newText;
		dist = newText1;
		transform.FindChild("Text").GetComponent<Text>().text = name;
		transform.FindChild("Text1").GetComponent<Text>().text = dist.ToString() + " km";

	}

	public void obtainExp(){
		
	}

	public void click(){
		Debug.Log("sss");
		if(canTake){
			//TODO take, add to a taken list, compare when creating list, reset list to delete item, add exp, add trophy, pop-up
		}
	}
}
