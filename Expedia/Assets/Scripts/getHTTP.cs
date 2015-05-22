using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class getHTTP : MonoBehaviour {
	public string url = "http://terminal2.expedia.com/x/geo/features?bbox=-122.453269,37.777363,-122.395935,37.810462&apikey=azCQTn91WiTmxxlaKWG63YZk2z1fpXxA";
	void Start () {
		WWW www = new WWW(url);
		StartCoroutine(WaitForRequest(www));
	}
	
	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		
		// check for errors
		if (www.error == null)
		{
			Debug.Log("WWW Ok!: " + www.text);
			Text text = GameObject.Find("Canvas").transform.FindChild("Infos").GetComponent<Text>();
			text.text = www.text;
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}    
	}
}
