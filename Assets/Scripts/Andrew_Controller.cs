using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Andrew_Controller : MonoBehaviour
{
    [SerializeField] GameObject RunningAndrew;
    [SerializeField] GameObject StandingAndrew;
    [SerializeField] float AndrewSpeed = 1f;
    [SerializeField] float JumpForce = 10f;
    bool isGrounded = true;
    public bool movingLeft = false;
    public bool movingRight = false;
    public bool jumped = false;
    // Start is called before the first frame update
    void Start()
    {
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A) || movingLeft)
        {
            Run("left");
        }
        else if (Input.GetKey(KeyCode.D) || movingRight)
        {
            Run("right");
        }
        else
        {
            RunningAndrew.SetActive(false);
            StandingAndrew.SetActive(true); 
        }
        if (Input.GetKeyDown(KeyCode.Space) || jumped)
        {
            Jump();
        }
    }

    public void Run(string dir)
    {
        if(dir == "left" && this.transform.position.x >= -12.6f)
        {
            RunningAndrew.SetActive(true);
            StandingAndrew.SetActive(false);
            this.transform.Translate(-transform.right * Time.deltaTime * 100 * AndrewSpeed);
            this.transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        if(dir == "right" && this.transform.position.x <= 12.6f)
        {
            RunningAndrew.SetActive(true);
            StandingAndrew.SetActive(false);
            this.transform.Translate(transform.right * Time.deltaTime * 100 * AndrewSpeed);
            this.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }

    public void Jump()
    {
        if (isGrounded)
        {
            isGrounded = false;
            this.GetComponent<Rigidbody2D>().AddForce(transform.up * JumpForce);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().AddScore(1);
        }
    }

}
