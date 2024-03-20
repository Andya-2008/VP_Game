using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScript : MonoBehaviour
{

    [SerializeField] TMP_InputField UserName;
    [SerializeField] GameObject saveButton;

    [SerializeField]
    ScoreManager sm;

    HSController hsController;

    void Start()
    {
        saveButton.SetActive(true);

    }
    public void SaveHighScore() {
        hsController = this.gameObject.GetComponent<HSController>();
        Debug.Log("test1");
        if (UserName.text.Length > 0 && UserName.text.Length < 15)
        {
            StartCoroutine(hsController.AddScore((decimal)sm.score, UserName.text));


            saveButton.SetActive(false);
        }
    }
}