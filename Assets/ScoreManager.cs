using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] float score;
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
        text.text = "Score: " + score.ToString();
    }
}
