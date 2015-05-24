using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PopUp_Script : MonoBehaviour {

    private Text name;
    private Text xpGained;
    public Canvas This;
    
	void Start()
    {
        name = transform.FindChild("Panel").FindChild("Name").GetComponent<Text>();
        xpGained = transform.FindChild("Panel").FindChild("XpGained").GetComponent<Text>();
    }

    public void StartUp(string _name, int _xpGained)
    {
        This.GetComponent<AudioSource>().Play();
        name.text = _name;
        xpGained.text = _xpGained.ToString() + " XP Gained!";
        This.enabled = true;
    }

    public void Deactivate()
    {
        This.enabled = false;
    }
}
