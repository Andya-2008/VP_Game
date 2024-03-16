using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public int Wave;
    public TextMeshProUGUI waveText;
    public GameObject MovingEnemy;
    [SerializeField] GameObject EnemyFab;
    [SerializeField] Transform EnemySpawnPoint;
    public List<GameObject> Enemies = new List<GameObject>(); 
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(GameObject.Find("CloudSpawner"));
        Wave = 1;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            ToGameScene();
        }
    }

    public void UpdateWave()
    {
        Wave++;
        GameObject.Find("HamburgerSpawner").GetComponent<HamburgerSpawner>().spawnInterval *= 0.8f;
        waveText.text = "Wave: " + Wave.ToString();
        if(Wave == 1)
        {
            //Nothing
        }
        else if(Wave == 2)
        {
            foreach(GameObject enemy in Enemies)
            {
                enemy.GetComponent<MovingAlien_Controller>().moveSpeed *= 1.5f;
                enemy.GetComponent<MovingAlien_DropBullet>().bulletDropInterval /= 2;
            }
        }
        else if (Wave == 3)
        {
            foreach (GameObject enemy in Enemies)
            {
                enemy.GetComponent<MovingAlien_Controller>().moveSpeed *= 1.2f;
                enemy.GetComponent<MovingAlien_DropBullet>().bulletDropInterval /= 2;
            }
        }
        else if (Wave >= 4)
        {
            GameObject newEnemy = Instantiate(EnemyFab, EnemySpawnPoint.position, Quaternion.identity);
            Enemies.Add(newEnemy);
            foreach (GameObject enemy in Enemies)
            {
                enemy.GetComponent<MovingAlien_Controller>().moveSpeed *= 1.05f;
                enemy.GetComponent<MovingAlien_DropBullet>().bulletDropInterval /= 1.2f;
            }
        }
    }

    public void ToGameScene()
    {
        Debug.Log("PlayAgain2");
        SceneManager.LoadScene("GameScene");
    }
}
