using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthManager : MonoBehaviour
{
    [SerializeField] Image Heart1;
    [SerializeField] Image Heart1Cover;
    [SerializeField] Image Heart2;
    [SerializeField] Image Heart2Cover;
    [SerializeField] Image Heart3;
    [SerializeField] Image Heart3Cover;
    [SerializeField] Canvas GameOverCanvas;
    [SerializeField] Button PlayAgainButton;
    // Start is called before the first frame update
    void Start()
    {
        Heart1Cover.GetComponent<Image>().enabled = false;
        Heart2Cover.GetComponent<Image>().enabled = false;
        Heart3Cover.GetComponent<Image>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealth(int health)
    {
        if(health == 0)
        {
            Debug.Log("Game Over");
            Heart1Cover.GetComponent<Image>().enabled = true;
            Heart2Cover.GetComponent<Image>().enabled = true;
            Heart3Cover.GetComponent<Image>().enabled = true;
            PlayAgainButton.enabled = true;
            GameOverCanvas.enabled = true;
            GameObject.Find("Andrew").GetComponent<Andrew_Controller>().enabled = false;
        }
        if(health == 1)
        {
            Heart1Cover.GetComponent<Image>().enabled = true;
            Heart2Cover.GetComponent<Image>().enabled = true;
            Heart3Cover.GetComponent<Image>().enabled = false;
        }
        if (health == 2)
        {
            Heart1Cover.GetComponent<Image>().enabled = true;
            Heart2Cover.GetComponent<Image>().enabled = false;
            Heart3Cover.GetComponent<Image>().enabled = false;
        }
        if (health == 3)
        {
            Heart1Cover.GetComponent<Image>().enabled = false;
            Heart2Cover.GetComponent<Image>().enabled = false;
            Heart3Cover.GetComponent<Image>().enabled = false;
        }
        if(health >= 4)
        {
            health = 3;
        }
    }
}
