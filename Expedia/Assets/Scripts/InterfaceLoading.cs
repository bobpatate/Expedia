using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InterfaceLoading : MonoBehaviour {

    //Index of every canvas
    int OBJECTIVE;
    int QUEST;
    int EXPLORATION;
    int MENU;
    int STATS;

    //Index of the menu panel
    int menuPanel;

    //Array of canvas
    Canvas[] canvaArray;

    //Set Canvas
    public void SetCanvaArray()
    {
        //Look for every canvas and add it to the array
        canvaArray = GameObject.FindObjectsOfType<Canvas>();

        for(int i=0; i < canvaArray.Length; i++)
        {
            if (canvaArray[i].name == "Menu") MENU = i;
            else if (canvaArray[i].name == "Quest") QUEST = i;
            else if (canvaArray[i].name == "Objective") OBJECTIVE = i;
            else if (canvaArray[i].name == "Exploration") EXPLORATION = i;
            else if (canvaArray[i].name == "Stats") STATS = i;
        }
    }

    //Canvas Loading/Unloading
    void Load(int index)
    {
        for (int i = 0; i < canvaArray.Length; i++)
        {
            if (i != index)
            {
                if (canvaArray[i].name == "Menu") canvaArray[i].transform.FindChild("Panel").GetComponent<Animation>().Play(); //The anim for the Menu is reversed
                else canvaArray[i].enabled = false;
            }
        }

        if (canvaArray[index].name == "Menu") canvaArray[index].transform.FindChild("Panel").GetComponent<Animation>().Play("MenuInterfaceOtherSide");
        canvaArray[index].enabled = true;

		//Start exploration actualization
		if(index == EXPLORATION){
			InvokeRepeating("refreshExploration", 0, 15f);
		}
		else
			CancelInvoke();
    }

    //------------------------------------------------------------------------------------------
    //                                      BUTTONS
    //------------------------------------------------------------------------------------------

    //Load Exploration
    public void Button_LoadExploration()
    {
        Load(EXPLORATION);
        canvaArray[EXPLORATION].GetComponent<ScrollBarInterface>().Restart();
		
    }

    //Load Menu
    public void Button_LoadMenu()
    {
        Load(MENU);
		GameObject[] buttonsToRemove = GameObject.FindGameObjectsWithTag("subMenuButton");
		foreach(GameObject GO in buttonsToRemove){
			Destroy(GO);
		}
    }

    //Load Objective
    public void Button_LoadObjective()
    {
        Load(OBJECTIVE);
    }

    //Load Quest
    public void Button_LoadQuest()
    {
        Load(QUEST);
    }

    public void Button_LoadCollection()
    {
        Load(STATS);
    }


	void refreshExploration(){
		GetComponent<Exploration>().Actualize();
	}
}
