using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatsInterface : MonoBehaviour {

    public Text xpText;
    public Text titleText;
    public Text numberBigTrophy;
    public Text numberSmallTrophy;
    public Text level;
    public GameObject xpBar;
    private CharacterStats charStats;
    private int smalltrophy = 0;
    private int largetrophy = 0;

    void Start()
    {
        charStats = GameObject.Find("GameMaster").GetComponent<CharacterStats>();
    }

    public void OnLoad()
    {
        int smalltrophy = PlayerPrefs.GetInt("STrophy");
        int largetrophy = PlayerPrefs.GetInt("LTrophy");
        SetXp();
        SetTrophyNumber();
        SetTitle();
    }

    private void SetXp()
    {
        xpBar.transform.localScale = new Vector3(charStats.PourcentageToNextLevel(), 1, 1);
        xpText.text = charStats.GetCurrentLevelXP().ToString() + "/" + charStats.GetCurrentXpGoal();
        SetLevel();
    }

    private void SetLevel()
    {
        charStats.GetLevel();
    }

    private void SetTitle()
    {
        titleText.text = charStats.GetTitle();
    }

    private void SetTrophyNumber()
    {
        numberBigTrophy.text = largetrophy.ToString();
        numberSmallTrophy.text = smalltrophy.ToString();
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
