using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SubMenuButton : MonoBehaviour {

	public uint expPoints = 5;
	public string name;
	public double dist;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setText(string newText, double newText1){
		name = newText;
		dist = newText1;
		transform.FindChild("Text").GetComponent<Text>().text = name;
		transform.FindChild("Text1").GetComponent<Text>().text = dist.ToString() + " km";

	}

	public void obtainExp(){
		
	}
}
