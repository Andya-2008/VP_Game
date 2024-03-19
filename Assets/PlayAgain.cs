using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayAgain : MonoBehaviour
{

    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAgainButton()
    {
        gameManager.Wave = 1;
        gameManager.MovingEnemy = this.gameObject;
        gameManager.Enemies.Clear();
        Debug.Log("PlayAgain1");
        SceneManager.LoadScene("GameScene");
    }
    public void LeaderboardButton()
    {
        SceneManager.LoadScene("Leaderboard");
    }
}
