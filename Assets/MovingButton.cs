using UnityEngine;
using UnityEngine.EventSystems; // Required for UI event detection

public class MovingButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool button1; // Assign this in the inspector
    public bool button2;
    public bool button3;


    public void OnPointerDown(PointerEventData eventData)
    {
        if (button1)
        {
            GameObject.Find("Andrew").GetComponent<Andrew_Controller>().movingLeft = true;
        }
        if (button2)
        {
            GameObject.Find("Andrew").GetComponent<Andrew_Controller>().movingRight = true;
        }
        if (button3)
        {
            GameObject.Find("Andrew").GetComponent<Andrew_Controller>().jumped = true;
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        GameObject.Find("Andrew").GetComponent<Andrew_Controller>().movingLeft = false;
        GameObject.Find("Andrew").GetComponent<Andrew_Controller>().movingRight = false;
        GameObject.Find("Andrew").GetComponent<Andrew_Controller>().jumped = false;
    }
}