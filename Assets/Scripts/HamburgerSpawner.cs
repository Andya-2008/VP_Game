using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamburgerSpawner : MonoBehaviour
{
    [SerializeField] GameObject Collectible;
    [SerializeField] public float spawnInterval = 5f;
    [SerializeField] List<GameObject> hamburgers = new List<GameObject>();
    float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - startTime > spawnInterval)
        {
            Vector2 randomPos;
            randomPos = new Vector2(Random.Range(-12f, 12f), Random.Range(-3.5f, 1f));
            GameObject newHamburger = Instantiate(Collectible, randomPos, Quaternion.identity);
            hamburgers.Add(newHamburger);
            startTime = Time.time;
        }
        if(hamburgers.Count >= 45)
        {
            foreach(GameObject hamburger in hamburgers)
            {
                Destroy(hamburger);
            }
            hamburgers.Clear();
        }
        foreach(GameObject hamburg in hamburgers)
        {
            if(hamburg == null)
            {
                hamburgers.Remove(hamburg);
            }
        }
    }
}
