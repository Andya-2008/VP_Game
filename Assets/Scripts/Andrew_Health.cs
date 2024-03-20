using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Andrew_Health : MonoBehaviour
{
    [SerializeField] public int health = 3;
    [SerializeField] int startHealth = 3;
    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            LoseHealth(1);
        }
        if(Input.GetKeyDown(KeyCode.H))
        {
            GainHealth(1);
        }
    }

    public void LoseHealth(int lostHealth)
    {
        GameObject.Find("Hurt").GetComponent<AudioSource>().Play();
        health -= lostHealth;
        GameObject.Find("HealthManager").GetComponent<HealthManager>().UpdateHealth(health);
    }
    public void GainHealth(int gainedHealth)
    {
        health += gainedHealth;
        if (health > startHealth)
        {
            health = startHealth;
        }
        GameObject.Find("HealthManager").GetComponent<HealthManager>().UpdateHealth(health);
    }
}
