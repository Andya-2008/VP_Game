using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingAlien_DropBullet : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] public float bulletDropInterval;
    [SerializeField] Transform spawnPos;
    float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - startTime > bulletDropInterval)
        {
            startTime = Time.time;
            Instantiate(bullet, spawnPos.position, Quaternion.identity);
        }
    }
}
