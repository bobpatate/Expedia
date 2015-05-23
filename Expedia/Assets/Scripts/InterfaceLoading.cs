using UnityEngine;
using System.Collections;

public class InterfaceLoading : MonoBehaviour {

    //Index of every canvas
    int OBJECTIVE = 2;
    int QUEST = 3;
    int EXPLORATION = 1;
    int MENU = 0;

    //Array of canvas
    Canvas[] canvaArray;

    void Start()
    {
        SetCanvaArray();
        
    }

    //Set Canva
    void SetCanvaArray()
    {
        //Look for every canvas and add it to the array
        canvaArray = GameObject.FindObjectsOfType<Canvas>();

        for(int i=0; i < canvaArray.Length; i++)
        {
            if (canvaArray[i].name == "Menu") MENU = i;
            else if (canvaArray[i].name == "Quest") QUEST = i;
            else if (canvaArray[i].name == "Objective") OBJECTIVE = i;
            else if (canvaArray[i].name == "Exploration") EXPLORATION = i;
        }
    }

    //Canvas Loading/Unloading
    void Load(int index)
    {
        for (int i = 0; i < canvaArray.Length; i++)
        {
            if (i != index)
            {
                canvaArray[i].enabled = false;
            }
        }
        
        canvaArray[index].enabled = true;
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
}
