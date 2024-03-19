using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] float cloudSpawnInterval;
    [SerializeField] GameObject Cloud;
    [SerializeField] GameObject CloudParent;
    float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - startTime >= cloudSpawnInterval)
        {
            startTime = Time.time;
            GameObject newCloud = Instantiate(Cloud, new Vector3(15.2f, Random.Range(1f, 4.38f), 0), Quaternion.identity);
            newCloud.transform.parent = CloudParent.transform;
        }
    }
}
