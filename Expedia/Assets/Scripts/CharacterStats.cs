using UnityEngine;
using System.Collections;

public class CharacterStats : MonoBehaviour {
    
    //stats variables
    private int experience = 0; //Decides how many level the character has
    private int currentLevelXP;
    public int[] xpTier; //The milestone of xp needed to level up (Xp milestone for each level, not cumulative
    private int level; 
    private string title; //Purely cosmetic
    public string[] titleList; //Reward per level
    private float viewRange; //The range at which you can see the exploration node
    public float[] viewRangeTier; //The view range for each level

    //Accessor
    public int GetExperience() { return experience; }
    public int GetCurrentXpGoal() { return xpTier[level]; }
    public int GetCurrentLevelXP() { return currentLevelXP; }
    public int GetLevel() { return level; }
    public string GetTitle() { return title; }
    public float GetViewRange() { return viewRange; }

    public void SetExperience(int var) { experience = var; }
    public void SetCurrentLevelXP(int var) { currentLevelXP = var; }

    //Usefull function

    //Function to be used when the character levels up (Should only be used from AddXp)
    void LevelUp() 
    {
        level++;
        viewRange = viewRangeTier[level-1];
        title = titleList[level - 1];
    }

    public void OnStartup() //Only use on startup
    {
        int tempLevel = 1;

		// Load from PlayerPref
		int xpTotal = PlayerPrefs.GetInt("XP");
		experience = xpTotal;
        
		//Find what level the player is
        while (xpTotal > xpTier[tempLevel-1])
        {
            xpTotal -= xpTier[tempLevel - 1];
            tempLevel++;
        }

        level = tempLevel; //Set the level to the level found before
        SetCurrentLevelXP(xpTotal); //The remaining xp goes to the current xp to next level
        viewRange = viewRangeTier[level - 1]; //Set view range from level
        title = titleList[level - 1]; //Set title from level
    }

    //The character gains xp
    public void AddXp(int amountXP)
    {
        experience += amountXP; //Add xp to the total
        currentLevelXP += amountXP; //Add xp to current level
		PlayerPrefs.SetInt("XP", experience);

        if (currentLevelXP > xpTier[level-1]) //If the xp is higher than the current milestone -> Level Up
        {
            currentLevelXP = currentLevelXP - xpTier[level - 1]; //Calculate the current xp - current xp tier to see how much to the next tier you are
            LevelUp();
        }
    }

    //Pourcentage to show on the XP bar
    public float PourcentageToNextLevel()
    {
        return (float)currentLevelXP / (float)xpTier[level - 1]; //Returns the % of xp until next level
    }
}
