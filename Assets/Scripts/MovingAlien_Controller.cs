using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingAlien_Controller : MonoBehaviour
{
    [SerializeField] public float moveSpeed = .1f;
    [SerializeField] bool right;
    [SerializeField] bool initEnemy;
    // Start is called before the first frame update
    void Start()
    {
        if(initEnemy)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().MovingEnemy = this.gameObject;
            GameObject.Find("GameManager").GetComponent<GameManager>().Enemies.Add(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(right)
        {
            this.transform.Translate(moveSpeed*Time.deltaTime*100,0,0);
        }
        if(!right)
        {
            this.transform.Translate(-moveSpeed*Time.deltaTime*100,0,0);
        }
        if(this.transform.position.x>=11.4)
        {
            right = false;
        }
        if (this.transform.position.x <= -11.4)
        {
            right = true;
        }
    }
}
