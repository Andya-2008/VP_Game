using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI LeaderboardText;
    HSController hsController;
    // Start is called before the first frame update
    void Start()
    {
        hsController = GameObject.Find("LeaderboardManager").GetComponent<HSController>();
    }

    // Update is called once per frame
    void Update()
    {
        //hsController.GetScore()
    }
}
