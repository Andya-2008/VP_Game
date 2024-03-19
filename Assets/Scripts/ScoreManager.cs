using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] public float score;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int pointsAdded)
    {
        score += pointsAdded;
        if (score % 5 == 0)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().UpdateWave();
            GameObject.Find("Andrew").GetComponent<Andrew_Health>().GainHealth(1);
        }
        text.text = "Score: " + score.ToString();
    }
}
