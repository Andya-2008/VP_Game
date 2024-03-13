using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamburgerSpawner : MonoBehaviour
{
    [SerializeField] GameObject Collectible;
    [SerializeField] public float spawnInterval = 5f;
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
            Instantiate(Collectible, randomPos, Quaternion.identity);
            startTime = Time.time;
        }
    }
}
