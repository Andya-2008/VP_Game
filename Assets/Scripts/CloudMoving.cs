using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMoving : MonoBehaviour
{
    [SerializeField] float CloudSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.x > -15)
        {
            this.transform.Translate(-CloudSpeed * 100 * Time.deltaTime, 0, 0);
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }
}
