using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] public int Wave;
    [SerializeField] TextMeshProUGUI waveText;
    [SerializeField] GameObject MovingEnemy;
    [SerializeField] GameObject EnemyFab;
    [SerializeField] Transform EnemySpawnPoint;
    List<GameObject> Enemies = new List<GameObject>(); 
    // Start is called before the first frame update
    void Start()
    {
        Wave = 1;
        waveText.text = "Wave: " + Wave.ToString();
        Enemies.Add(MovingEnemy);
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
