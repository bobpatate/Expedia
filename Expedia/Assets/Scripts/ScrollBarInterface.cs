using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollBarInterface : MonoBehaviour {

    //ScrollBar Information
    public Image scrollBar;
    public Button buttonModel;
    private Vector3 scrollBarPos;

    //Button Variables
    public float offsetBetweenButton;

	void Start()
    {
        //Get the scroll bar Position
        scrollBarPos = scrollBar.transform.position;

        //Set offset with the height of the button + 10
        offsetBetweenButton = -(buttonModel.GetComponent<RectTransform>().rect.height - 3);

        //For Debuggging
        SetNumberOfButtons(5);
    }

    //Reset the exploration interface
    public void Restart()
    {
        ResetScrollBarPos();
    }

    //Reset the scroll bar to the top of the window
    void ResetScrollBarPos()
    {
        scrollBar.transform.position = scrollBarPos;
    }

    void SetNumberOfButtons(int number)
    {
        float currentPos = buttonModel.GetComponent<RectTransform>().localPosition.y;

        //Change the size in Y of the scrolling bar to accomodate more button
        float scrollBarSize = buttonModel.GetComponent<RectTransform>().rect.height * number; //The +2 is to accomodate the elastic effect when the scrolling arrives at the end
        scrollBar.GetComponent<RectTransform>().sizeDelta = new Vector2(475, scrollBarSize);
        

        for(int i=0; i < number; i++)
        {
            currentPos = currentPos + offsetBetweenButton;
            Button tempButton = Instantiate(buttonModel) as Button;
            tempButton.transform.SetParent(scrollBar.transform);
            tempButton.GetComponent<RectTransform>().localPosition = new Vector3(0, currentPos, 0);
            tempButton.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }
}
