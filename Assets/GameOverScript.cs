using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;

public class GameOverScript : MonoBehaviour
{

    [SerializeField] TMP_InputField UserName;
    [SerializeField] GameObject saveButton;
    [SerializeField] TMP_Dropdown ddYear;
    [SerializeField] TMP_Dropdown ddStudent;


    [SerializeField]
    ScoreManager sm;

    HSController hsController;

    void Start()
    {
        saveButton.SetActive(true);
        ddStudent.gameObject.SetActive(true);
        ddYear.gameObject.SetActive(true);
        List<string> years = new List<string>();
        years.Add("2025");
        years.Add("2026");
        years.Add("2027");
        ddYear.ClearOptions();
        ddYear.AddOptions(years);
        hsController = this.GetComponent<HSController>();
        StartCoroutine(hsController.GetStudents(ddYear.options[ddYear.value].text, populateStudents));
    }

    public void changeYear() {
        StartCoroutine(hsController.GetStudents(ddYear.options[ddYear.value].text, populateStudents));

    }

    public void populateStudents(string result) {
        Debug.Log(result);

        JArray jaHS = JArray.Parse(result);

        int i = 0;
        List<string> names = new List<string>();
        foreach (JObject hs in jaHS)
        {
            names.Add(hs["Name"].ToString());
        }
        ddStudent.ClearOptions();
        ddStudent.AddOptions(names);
    }


    public void SaveHighScore() {

        StartCoroutine(hsController.AddScore((decimal)sm.score, ddStudent.options[ddStudent.value].text));

        saveButton.SetActive(false);
        ddStudent.gameObject.SetActive(false);
        ddYear.gameObject.SetActive(false);

    }
}
