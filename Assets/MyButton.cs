using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MyButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public bool button1;
    public bool button2;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (button1)
        {
            GameObject.Find("Andrew").GetComponent<Andrew_Controller>().movingLeft = true;
            GameObject.Find("Andrew").GetComponent<Andrew_Controller>().movingRight = false;
        }
        if (button2)
        {
            GameObject.Find("Andrew").GetComponent<Andrew_Controller>().movingRight = true;
            GameObject.Find("Andrew").GetComponent<Andrew_Controller>().movingLeft = false;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GameObject.Find("Andrew").GetComponent<Andrew_Controller>().movingLeft = false;
        GameObject.Find("Andrew").GetComponent<Andrew_Controller>().movingRight = false;
    }
}