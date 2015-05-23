using UnityEngine;
using System.Collections;

public class InterfaceLoading : MonoBehaviour {

    //Index of every canvas
    const int OBJECTIVE = 0;
    const int QUEST = 1;
    const int EXPLORATION = 2;
    const int MENU = 3;

    //Array of canvas
    Canvas[] canvaArray;

    void Start()
    {
        //Look for every canvas and addd it to the array
        canvaArray = GameObject.FindObjectsOfType<Canvas>();
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
