﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ScrollBarInterface : MonoBehaviour {

    //ScrollBar Information
    public Image scrollBar;
    public Button buttonModel;
    private Vector3 scrollBarPos;

    //Button Variables
    public float offsetBetweenButton;

	public bool isExploration;

	void Start()
    {
        //Get the scroll bar Position
        scrollBarPos = scrollBar.transform.position;

        //Set offset with the height of the button + 10
        offsetBetweenButton = -(buttonModel.GetComponent<RectTransform>().rect.height - 3);
    }

    //Reset the exploration interface
    public void Restart()
    {
        ResetScrollBarPos();
		buttonModel.GetComponent<Image>().enabled = true;
    }

    //Reset the scroll bar to the top of the window
    void ResetScrollBarPos()
    {
        scrollBar.transform.position = scrollBarPos;
    }

	public void GenerateButtons()
    {
        float currentPos = buttonModel.GetComponent<RectTransform>().localPosition.y;
		
        //Change the size in Y of the scrolling bar to accomodate more button
		float scrollBarSize = buttonModel.GetComponent<RectTransform>().rect.height * GameMaster.instance.points.Count; //The +2 is to accomodate the elastic effect when the scrolling arrives at the end
        scrollBar.GetComponent<RectTransform>().sizeDelta = new Vector2(475, scrollBarSize);
        
		//Create buttons
		bool first = true;

		List<ExplorationPoint> pointsToCompare;
		if(isExploration){
			pointsToCompare = GameMaster.instance.points;
		}
		else{
			pointsToCompare = GameMaster.instance.pointsObjetives;
		}

		foreach(ExplorationPoint point in pointsToCompare){
			bool skip = false;
			foreach(ExplorationPoint pointMaybeIgnore in GameMaster.instance.pointsToIgnore){
				if(point.name == pointMaybeIgnore.name){
					skip = true;
					break;
				}
			}

			if(!skip){
				if(!first)
					currentPos = currentPos + offsetBetweenButton;

				first = false;

	            Button tempButton = Instantiate(buttonModel) as Button;
	            tempButton.transform.SetParent(scrollBar.transform);
	            tempButton.GetComponent<RectTransform>().localPosition = new Vector3(0, currentPos, 0);
	            tempButton.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

				tempButton.tag = "subMenuButton";
				tempButton.gameObject.AddComponent<SubMenuButton>();
	            tempButton.GetComponent<Button>().onClick.AddListener(() => tempButton.GetComponent<SubMenuButton>().click());
				if(isExploration){
					tempButton.GetComponent<SubMenuButton>().setText(RemoveLastPartOfPOI(point.name), Math.Round(point.distance, 3), true);
				}
				else{
					tempButton.GetComponent<SubMenuButton>().setText(RemoveLastPartOfPOI(point.name), Math.Round(point.distance, 3), false);
				}
				tempButton.GetComponent<SubMenuButton>().point = point;
			}
        }

		buttonModel.GetComponent<Image>().enabled = false;
    }

    private string RemoveLastPartOfPOI(string text)
    {
        return "Visit: " + text.Substring(0, text.IndexOf(','));
    }
}
