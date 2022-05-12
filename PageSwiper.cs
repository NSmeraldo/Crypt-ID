using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PageSwiper: MonoBehaviour, IDragHandler, IEndDragHandler
{

    //Initial panel location
    private Vector3 panelLocation;   
    //Gets the percent of the screen swiped
    public float percentThreshold = 0.2f;
    //easing factor to be able to seamlessly swipe across
    public float easing = 0.5f;
    //Gets the amount of children of the empty to determine the first and last page to avoid overswipping
    public int currentchild;

    // Start is called before the first frame update
    void Start()
    {
        panelLocation = transform.position;
    }
    
    //Checks when The player has started dragging the panels and checks how far they have gone
    public void OnDrag(PointerEventData data)
    {
        float difference = data.pressPosition.x - data.position.x;
        transform.position = panelLocation - new Vector3(difference, 0, 0);
    }
    
    //checks when the player has ended dragging and determines if it has crossed the threshold to go to the next panel
    public void OnEndDrag(PointerEventData data)
    {
        float percentage = (data.pressPosition.x - data.position.x) / Screen.width;
        if(Mathf.Abs(percentage) >= percentThreshold)
        {
            Vector3 newLocation = panelLocation;
            if(percentage > 0 && currentchild < transform.childCount-1)
            {
                newLocation += new Vector3(-Screen.width, 0, 0);
                currentchild++;
            }
            else if(percentage < 0 && currentchild > 0)
            {
                newLocation += new Vector3(Screen.width, 0, 0);
                currentchild--;
            }
            StartCoroutine(SmoothMove(transform.position, newLocation, easing));
            panelLocation = newLocation;
        }
        else
        {
            StartCoroutine(SmoothMove(transform.position, panelLocation, easing));
        }
    }
    
    //a corutine to be able to do the seamless transition between the panels so that it isn't choppy or rushed
    IEnumerator SmoothMove(Vector3 startpos, Vector3 endpos, float seconds)
    {
        float t = 0f;
        while(t <= 1.0)
        {
            t += Time.deltaTime / seconds;
            transform.position = Vector3.Lerp(startpos, endpos, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }
    }
}
