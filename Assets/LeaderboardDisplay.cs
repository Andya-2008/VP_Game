using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using Newtonsoft.Json.Linq;


public class LeaderboardDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI LeaderboardNames;
    [SerializeField] TextMeshProUGUI LeaderboardScores;
    HSController hsController;

    // Start is called before the first frame update
    void Start()
    {
        hsController = this.gameObject.GetComponent<HSController>();
        Debug.Log("test1");
        StartCoroutine(hsController.GetScore(printHighScores));

    }

    // Update is called once per frame
    void Update()
    {
        //hsController.GetScore()
    }

    void printHighScores(string result) {
        JArray jaHS = JArray.Parse(result);

        int i = 0;
        foreach (JObject hs in jaHS) {

            LeaderboardNames.text += hs["Name"] + "\n";
            LeaderboardScores.text += hs["Score"] + "\n";
            i++;
            if (i >= 5) {
                break;

            }

        }



    }
}
