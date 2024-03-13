using UnityEngine;
using UnityEngine.EventSystems; // Required for UI event detection

public class MovingButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool isPointerOverButton = false;
    private bool isHolding = false;
    public bool button1; // Assign this in the inspector
    public bool button2;
    public bool button3;

    public void OnPointerEnter(PointerEventData eventData)
    {
        isPointerOverButton = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerOverButton = false;
    }

    void Update()
    {
        // Check if the left mouse button is held down
        if (isPointerOverButton && Input.GetMouseButton(0))
        {
            if (!isHolding)
            {
                // This block will run once when the button is first held down
                Debug.Log("Started Holding");
                isHolding = true;
                if (button1)
                {
                    GameObject.Find("Andrew").GetComponent<Andrew_Controller>().movingLeft = true;
                }
                if (button2)
                {
                    GameObject.Find("Andrew").GetComponent<Andrew_Controller>().movingRight = true;
                }
                if(button3)
                {
                    GameObject.Find("Andrew").GetComponent<Andrew_Controller>().jumped = true;
                }
            }
            // Continuous logic while holding can go here
        }
        else if (isHolding)
        {
            // This block will run once when the button is released
            Debug.Log("Stopped Holding");
            isHolding = false;
            // End your hold logic here
            GameObject.Find("Andrew").GetComponent<Andrew_Controller>().movingLeft = false;
            GameObject.Find("Andrew").GetComponent<Andrew_Controller>().movingRight = false;
            GameObject.Find("Andrew").GetComponent<Andrew_Controller>().jumped = false;
        }
    }
}/*

using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MovingButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public bool button1;
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
*/