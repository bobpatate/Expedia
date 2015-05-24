using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PopUp_Script : MonoBehaviour {

    private Text name;
    private Text xpGained;
    public Canvas This;
    
	void OnStart()
    {
        GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -137);
        name = transform.FindChild("Name").GetComponent<Text>();
        xpGained = transform.FindChild("XpGained").GetComponent<Text>();
    }

    public void StartUp(string _name, int _xpGained)
    {
        This.enabled = true;
        This.GetComponent<AudioSource>().Play();
        name.text = _name;
        xpGained.text = _xpGained.ToString() + " XP Gained!";
    }

    public void Deactivate()
    {
        This.enabled = false;
    }
}
