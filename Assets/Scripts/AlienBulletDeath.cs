using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBulletDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }

        else if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Andrew_Health>().LoseHealth(1);
            Destroy(this.gameObject);
        }
    }
}
