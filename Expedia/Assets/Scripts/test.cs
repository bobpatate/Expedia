using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {
    public string url = "http://images.earthcam.com/ec_metros/ourcams/fridays.jpg";
    IEnumerator Start() {
        WWW www = new WWW(url);
        yield return www;
        GetComponent<Renderer>().material.mainTexture = www.texture;
    }
}
